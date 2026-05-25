using System;
using UnityEngine;

namespace PrototypeFirstRoom
{
    public enum ScreenHotspotType
    {
        Look,
        Listen,
        Exit,
        TurnLeft,
        TurnRight,
        Back
    }

    [Serializable]
    public class ScreenHotspot
    {
        public string id;
        public string label;
        public ScreenHotspotType hotspotType;
        public Rect normalizedRect;
        public string legacyHotspotId;
        public string targetViewId;
        public string responseText;
        public int priority;
    }
}
