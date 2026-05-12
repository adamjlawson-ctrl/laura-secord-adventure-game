using System;
using System.Collections.Generic;

namespace QueenstonWarning.NodeSystem.Data
{
    public enum CardinalDirection
    {
        N = 0,
        E = 1,
        S = 2,
        W = 3
    }

    [Serializable]
    public sealed class NodeViewData
    {
        public CardinalDirection Direction;
        public string PlaceholderVisualLabel;
        public List<HotspotData> Hotspots = new List<HotspotData>();
        public ExitData ForwardExit;
    }
}
