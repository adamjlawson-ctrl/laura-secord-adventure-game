using System;

namespace PrototypeFirstRoom
{
    [Serializable]
    public class HotspotData
    {
        public string id;
        public string label;
        public string actionType;
        public string responseText;
        public bool setsFlag;
        public string flagName;
        public bool flagValue;
        public string targetViewId;
    }
}
