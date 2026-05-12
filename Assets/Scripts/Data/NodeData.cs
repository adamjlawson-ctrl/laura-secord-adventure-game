using System;
using System.Collections.Generic;

namespace QueenstonWarning.NodeSystem.Data
{
    [Serializable]
    public sealed class AlternateContentData
    {
        public string Id;
        public string Type;
        public string Title;
        public string Notes;
        public bool Enabled;
    }

    [Serializable]
    public sealed class NodeData
    {
        public int NodeId;
        public string SceneId;
        public string SceneName;

        public string ApproxDistanceToDecew;
        public string TimeWindow;
        public string ModernApproxLocation;

        public CardinalDirection DefaultForwardView = CardinalDirection.N;
        public string RawForwardView;
        public string RawLeadsTo;
        public string RawForwardNodeDirection;

        public string Notes;
        public string CsvRowStatus = "ok";
        public bool HasFutureRichContentPending = true;

        public Dictionary<CardinalDirection, NodeViewData> Views = new Dictionary<CardinalDirection, NodeViewData>();
        public ExitData ForwardExit;
        public List<AlternateContentData> Alternates = new List<AlternateContentData>();

        public NodeViewData GetView(CardinalDirection direction)
        {
            if (Views.TryGetValue(direction, out var view))
            {
                return view;
            }

            return Views.TryGetValue(DefaultForwardView, out var fallback) ? fallback : null;
        }
    }
}
