using System;

namespace QueenstonWarning.NodeSystem.Data
{
    public enum ExitType
    {
        Forward
    }

    [Serializable]
    public sealed class ExitData
    {
        public string Id;
        public ExitType Type = ExitType.Forward;
        public int? ToNodeId;
        public string Label;
        public string ResolutionSource;
    }
}
