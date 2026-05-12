using System;
using System.Collections.Generic;

namespace QueenstonWarning.NodeSystem.Data
{
    [Serializable]
    public sealed class SceneData
    {
        public string SceneId;
        public string SceneName;
        public List<int> NodeIds = new List<int>();
    }
}
