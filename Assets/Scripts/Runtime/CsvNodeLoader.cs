using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using QueenstonWarning.NodeSystem.Data;
using UnityEngine;

namespace QueenstonWarning.NodeSystem.Runtime
{
    public sealed class CsvLoadResult
    {
        public Dictionary<int, NodeData> NodesById { get; } = new Dictionary<int, NodeData>();
        public List<int> SortedNodeIds { get; } = new List<int>();
        public Dictionary<string, SceneData> ScenesById { get; } = new Dictionary<string, SceneData>();
        public List<string> Warnings { get; } = new List<string>();

        public bool HasNodes => SortedNodeIds.Count > 0;

        public int StartNodeId
        {
            get
            {
                if (NodesById.ContainsKey(1))
                {
                    return 1;
                }

                return HasNodes ? SortedNodeIds[0] : -1;
            }
        }
    }

    public sealed class CsvNodeLoader : MonoBehaviour
    {
        private const string ResourceCsvPath = "Data/nodes";

        private static readonly string[] RequiredHeaders =
        {
            "Node",
            "Scene",
            "Scene Name",
            "Approx Distance to DeCew",
            "Time Window",
            "Modern Approx Location",
            "Default/Forward View",
            "Leads To (Forward)",
            "Forward Node Direction",
            "Notes"
        };

        public CsvLoadResult LastLoadResult { get; private set; }

        public CsvLoadResult LoadFromResources()
        {
            var csvAsset = Resources.Load<TextAsset>(ResourceCsvPath);
            if (csvAsset == null)
            {
                var missingResult = new CsvLoadResult();
                missingResult.Warnings.Add($"CSV not found at Resources/{ResourceCsvPath}.csv");
                LogWarnings(missingResult.Warnings);
                LastLoadResult = missingResult;
                return missingResult;
            }

            var parsedResult = ParseCsv(csvAsset.text);
            LastLoadResult = parsedResult;
            LogWarnings(parsedResult.Warnings);
            return parsedResult;
        }

        private static CsvLoadResult ParseCsv(string csvText)
        {
            var result = new CsvLoadResult();
            if (string.IsNullOrWhiteSpace(csvText))
            {
                result.Warnings.Add("CSV text is empty.");
                return result;
            }

            var lines = csvText
                .Replace("\uFEFF", string.Empty)
                .Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            if (lines.Count < 2)
            {
                result.Warnings.Add("CSV must include a header row and at least one data row.");
                return result;
            }

            var headers = ParseCsvLine(lines[0]);
            var indexLookup = BuildHeaderLookup(headers);

            foreach (var required in RequiredHeaders)
            {
                if (!indexLookup.ContainsKey(required))
                {
                    result.Warnings.Add($"Missing required CSV column: {required}");
                }
            }

            for (var rowIndex = 1; rowIndex < lines.Count; rowIndex += 1)
            {
                var lineNumber = rowIndex + 1;
                var values = ParseCsvLine(lines[rowIndex]);
                var row = BuildRowObject(values, indexLookup);

                var nodeToken = GetField(row, "Node");
                if (!int.TryParse(nodeToken, out var nodeId))
                {
                    result.Warnings.Add($"Row {lineNumber}: invalid Node value '{nodeToken}'. Row skipped.");
                    continue;
                }

                if (result.NodesById.ContainsKey(nodeId))
                {
                    result.Warnings.Add($"Row {lineNumber}: duplicate Node {nodeId}. Row skipped.");
                    continue;
                }

                var nodeData = BuildNodeData(nodeId, row, lineNumber, result.Warnings);
                result.NodesById.Add(nodeId, nodeData);
            }

            result.SortedNodeIds.AddRange(result.NodesById.Keys.OrderBy(id => id));
            ResolveForwardLinks(result);
            BuildSceneBuckets(result);

            if (!result.HasNodes)
            {
                result.Warnings.Add("No valid nodes were created from the CSV.");
            }

            return result;
        }

        private static Dictionary<string, int> BuildHeaderLookup(List<string> headers)
        {
            var lookup = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (var index = 0; index < headers.Count; index += 1)
            {
                var header = headers[index]?.Trim() ?? string.Empty;
                if (!lookup.ContainsKey(header))
                {
                    lookup.Add(header, index);
                }
            }

            return lookup;
        }

        private static Dictionary<string, string> BuildRowObject(List<string> values, Dictionary<string, int> headers)
        {
            var row = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var pair in headers)
            {
                var safeValue = pair.Value < values.Count ? values[pair.Value] : string.Empty;
                row[pair.Key] = safeValue?.Trim() ?? string.Empty;
            }

            return row;
        }

        private static NodeData BuildNodeData(
            int nodeId,
            Dictionary<string, string> row,
            int lineNumber,
            ICollection<string> warnings)
        {
            var node = new NodeData
            {
                NodeId = nodeId,
                SceneId = GetField(row, "Scene"),
                SceneName = GetField(row, "Scene Name"),
                ApproxDistanceToDecew = GetField(row, "Approx Distance to DeCew"),
                TimeWindow = GetField(row, "Time Window"),
                ModernApproxLocation = GetField(row, "Modern Approx Location"),
                RawForwardView = GetField(row, "Default/Forward View"),
                RawLeadsTo = GetField(row, "Leads To (Forward)"),
                RawForwardNodeDirection = GetField(row, "Forward Node Direction"),
                Notes = GetField(row, "Notes")
            };

            if (TryParseDirection(node.RawForwardNodeDirection, out var explicitDirection))
            {
                node.DefaultForwardView = explicitDirection;
            }
            else if (TryParseDirection(node.RawForwardView, out var inferredDirection))
            {
                node.DefaultForwardView = inferredDirection;
            }
            else
            {
                node.DefaultForwardView = CardinalDirection.N;
                warnings.Add($"Row {lineNumber}: no valid direction found, defaulting Node {nodeId} to N.");
                node.CsvRowStatus = "direction-defaulted-to-N";
            }

            foreach (CardinalDirection direction in Enum.GetValues(typeof(CardinalDirection)))
            {
                node.Views[direction] = new NodeViewData
                {
                    Direction = direction,
                    PlaceholderVisualLabel = $"Node {node.NodeId} - {direction} View"
                };
            }

            node.ForwardExit = new ExitData
            {
                Id = $"node-{node.NodeId}-forward",
                Type = ExitType.Forward,
                Label = "Forward"
            };

            node.Alternates.Add(new AlternateContentData
            {
                Id = $"node-{node.NodeId}-danger-alt",
                Type = "danger-alternate",
                Title = "Danger alternate placeholder",
                Notes = "Reserved for future hazard branches.",
                Enabled = false
            });

            node.Alternates.Add(new AlternateContentData
            {
                Id = $"node-{node.NodeId}-cutscene",
                Type = "cutscene",
                Title = "Cutscene placeholder",
                Notes = "Reserved for future cinematic transitions.",
                Enabled = false
            });

            return node;
        }

        private static void ResolveForwardLinks(CsvLoadResult result)
        {
            foreach (var nodeId in result.SortedNodeIds)
            {
                var node = result.NodesById[nodeId];
                var candidates = ExtractNodeReferences(node.RawLeadsTo)
                    .Where(candidate => result.NodesById.ContainsKey(candidate) && candidate != nodeId)
                    .Distinct()
                    .ToList();

                int? forwardTarget = null;
                var source = "terminal";

                if (candidates.Count == 1)
                {
                    forwardTarget = candidates[0];
                    source = "explicit";
                    node.CsvRowStatus = "ok";
                }
                else
                {
                    var nextSequential = result.SortedNodeIds.FirstOrDefault(candidate => candidate > nodeId);
                    if (nextSequential > nodeId)
                    {
                        forwardTarget = nextSequential;
                        source = candidates.Count > 1 ? "sequential-fallback-ambiguous" : "sequential-fallback";
                        node.CsvRowStatus = source;
                    }
                    else
                    {
                        node.CsvRowStatus = "terminal";
                    }
                }

                node.ForwardExit.ToNodeId = forwardTarget;
                node.ForwardExit.Label = forwardTarget.HasValue
                    ? $"Forward to Node {forwardTarget.Value}"
                    : "Forward unavailable";
                node.ForwardExit.ResolutionSource = source;

                var defaultView = node.GetView(node.DefaultForwardView);
                if (defaultView != null)
                {
                    defaultView.ForwardExit = node.ForwardExit;
                }
            }
        }

        private static void BuildSceneBuckets(CsvLoadResult result)
        {
            foreach (var nodeId in result.SortedNodeIds)
            {
                var node = result.NodesById[nodeId];
                var sceneId = string.IsNullOrWhiteSpace(node.SceneId) ? "Unassigned Scene" : node.SceneId;

                if (!result.ScenesById.TryGetValue(sceneId, out var sceneData))
                {
                    sceneData = new SceneData
                    {
                        SceneId = sceneId,
                        SceneName = string.IsNullOrWhiteSpace(node.SceneName) ? "Untitled Scene" : node.SceneName
                    };
                    result.ScenesById.Add(sceneId, sceneData);
                }

                sceneData.NodeIds.Add(node.NodeId);
            }
        }

        private static List<int> ExtractNodeReferences(string rawLeadsTo)
        {
            var matches = Regex.Matches(rawLeadsTo ?? string.Empty, @"Node\s*(\d+)", RegexOptions.IgnoreCase);
            var refs = new List<int>();

            foreach (Match match in matches)
            {
                if (!match.Success)
                {
                    continue;
                }

                if (int.TryParse(match.Groups[1].Value, out var nodeId))
                {
                    refs.Add(nodeId);
                }
            }

            return refs;
        }

        private static bool TryParseDirection(string raw, out CardinalDirection direction)
        {
            direction = CardinalDirection.N;
            if (string.IsNullOrWhiteSpace(raw))
            {
                return false;
            }

            var match = Regex.Match(raw.ToUpperInvariant(), "[NESW]");
            if (!match.Success)
            {
                return false;
            }

            switch (match.Value)
            {
                case "N":
                    direction = CardinalDirection.N;
                    return true;
                case "E":
                    direction = CardinalDirection.E;
                    return true;
                case "S":
                    direction = CardinalDirection.S;
                    return true;
                case "W":
                    direction = CardinalDirection.W;
                    return true;
                default:
                    return false;
            }
        }

        private static string GetField(Dictionary<string, string> row, string key)
        {
            return row.TryGetValue(key, out var value) ? value : string.Empty;
        }

        private static List<string> ParseCsvLine(string line)
        {
            var values = new List<string>();
            var current = string.Empty;
            var inQuotes = false;

            for (var index = 0; index < line.Length; index += 1)
            {
                var currentChar = line[index];
                var nextChar = index + 1 < line.Length ? line[index + 1] : '\0';

                if (currentChar == '"')
                {
                    if (inQuotes && nextChar == '"')
                    {
                        current += '"';
                        index += 1;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }

                    continue;
                }

                if (currentChar == ',' && !inQuotes)
                {
                    values.Add(current.Trim());
                    current = string.Empty;
                    continue;
                }

                current += currentChar;
            }

            values.Add(current.Trim());
            return values;
        }

        private static void LogWarnings(IEnumerable<string> warnings)
        {
            foreach (var warning in warnings)
            {
                Debug.LogWarning($"[CsvNodeLoader] {warning}");
            }
        }
    }
}
