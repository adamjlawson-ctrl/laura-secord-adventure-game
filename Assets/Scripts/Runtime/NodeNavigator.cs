using System;
using System.Collections.Generic;
using QueenstonWarning.NodeSystem.Data;
using UnityEngine;

namespace QueenstonWarning.NodeSystem.Runtime
{
    public sealed class NodeNavigator : MonoBehaviour
    {
        public event Action StateChanged;

        public CsvLoadResult Route { get; private set; }
        public int CurrentNodeId { get; private set; } = -1;
        public CardinalDirection CurrentDirection { get; private set; } = CardinalDirection.N;

        public NodeData CurrentNode
        {
            get
            {
                if (Route == null || !Route.NodesById.TryGetValue(CurrentNodeId, out var node))
                {
                    return null;
                }

                return node;
            }
        }

        public void Initialize(CsvLoadResult route)
        {
            Route = route;
            if (route == null || !route.HasNodes)
            {
                CurrentNodeId = -1;
                CurrentDirection = CardinalDirection.N;
                NotifyStateChanged();
                return;
            }

            CurrentNodeId = route.StartNodeId;
            CurrentDirection = CurrentNode != null ? CurrentNode.DefaultForwardView : CardinalDirection.N;
            NotifyStateChanged();
        }

        public void TurnLeft()
        {
            Rotate(-1);
        }

        public void TurnRight()
        {
            Rotate(1);
        }

        public void TurnBack()
        {
            Rotate(2);
        }

        public int? GetForwardTarget()
        {
            return CurrentNode?.ForwardExit?.ToNodeId;
        }

        public bool CanMoveForward()
        {
            var node = CurrentNode;
            if (node == null)
            {
                return false;
            }

            if (CurrentDirection != node.DefaultForwardView)
            {
                return false;
            }

            var target = node.ForwardExit?.ToNodeId;
            return target.HasValue && Route != null && Route.NodesById.ContainsKey(target.Value);
        }

        public bool MoveForward()
        {
            if (!CanMoveForward())
            {
                return false;
            }

            var target = CurrentNode.ForwardExit.ToNodeId;
            if (!target.HasValue || Route == null || !Route.NodesById.ContainsKey(target.Value))
            {
                return false;
            }

            CurrentNodeId = target.Value;
            var nextNode = CurrentNode;
            CurrentDirection = nextNode != null ? nextNode.DefaultForwardView : CurrentDirection;
            NotifyStateChanged();
            return true;
        }

        public string BuildTraversalStatus()
        {
            if (Route == null || !Route.HasNodes)
            {
                return "No route loaded.";
            }

            var visited = new HashSet<int>();
            var count = 0;
            var cursor = Route.StartNodeId;

            while (cursor > 0)
            {
                if (!Route.NodesById.TryGetValue(cursor, out var node))
                {
                    return $"Broken route: Node {cursor} missing.";
                }

                if (!visited.Add(cursor))
                {
                    return $"Loop detected at Node {cursor}.";
                }

                count += 1;

                if (!node.ForwardExit.ToNodeId.HasValue)
                {
                    return $"OK: {count} nodes traversed, terminal Node {cursor}.";
                }

                cursor = node.ForwardExit.ToNodeId.Value;
            }

            return "Route ended unexpectedly.";
        }

        private void Rotate(int offset)
        {
            if (CurrentNode == null)
            {
                return;
            }

            var raw = ((int)CurrentDirection + offset + 4) % 4;
            CurrentDirection = (CardinalDirection)raw;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
