using System;
using System.Collections.Generic;

namespace PrototypeFirstRoom
{
    [Serializable]
    public class NodeViewData
    {
        public string viewId;
        public string title;
        public string description;
        public string backgroundKey;
        public string autoLine;
        public List<HotspotData> hotspots;
        public NavigationTargets navigation;
        public string facingDirection;
        public int cameraBearing;
        public bool showCompass;
        public string historicalDate;
        public string localTimeWindow;
        public bool showHistoricalTime;
        public bool isCutscene;
        public List<DialogueLine> dialogueLines;
        public string cutsceneReturnViewId;
        public string cutsceneCompleteFlagName;
        public string cutsceneCompleteMessage;
        public string cutsceneCompleteButtonLabel;
    }
}
