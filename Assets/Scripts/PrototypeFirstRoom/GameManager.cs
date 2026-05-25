using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeFirstRoom
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [Header("Debug")]
        [SerializeField] private bool enableDebugJumpToScene2 = true;
        [SerializeField] private KeyCode debugJumpToScene2Key = KeyCode.F10;
        [SerializeField] private bool enableDebugJumpToScene3 = true;
        [SerializeField] private KeyCode debugJumpToScene3Key = KeyCode.F9;
    #if UNITY_EDITOR || DEVELOPMENT_BUILD
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private bool enableDebugJumpToScene4 = true;
        [SerializeField] private KeyCode debugJumpToScene4Key = KeyCode.F4;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene4Node11Key = KeyCode.F5;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene4Node12Key = KeyCode.F6;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene5Node13Key = KeyCode.F7;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene5Node14Key = KeyCode.F8;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene6Node15Key = KeyCode.F9;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene6Node16Key = KeyCode.F10;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene6Node17Key = KeyCode.F11;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene7Node18Key = KeyCode.F12;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene7Node19FallbackKey = KeyCode.Alpha9;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene7Node20FallbackKey = KeyCode.Alpha0;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene8Node21FallbackKey = KeyCode.Alpha1;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene8Node22FallbackKey = KeyCode.Alpha2;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene8Node23FallbackKey = KeyCode.Alpha3;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node24FallbackKey = KeyCode.Alpha4;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node25FallbackKey = KeyCode.Alpha5;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node25AlternateKey = KeyCode.Keypad5;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node26FallbackKey = KeyCode.Alpha6;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node27FallbackKey = KeyCode.Alpha7;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToScene9Node27AlternateKey = KeyCode.Keypad7;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene1Node28FallbackKey = KeyCode.Alpha8;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene1Node29FallbackKey = KeyCode.Alpha9;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene1Node30FallbackKey = KeyCode.Alpha0;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene1Node30AlternateKey = KeyCode.Keypad0;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene2Node31FallbackKey = KeyCode.Alpha1;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene2Node32FallbackKey = KeyCode.Alpha2;
        // TEMP DEV SHORTCUT — remove before release
        [SerializeField] private KeyCode debugJumpToAct3Scene2Node33FallbackKey = KeyCode.Alpha3;
    #endif

        private Dictionary<string, NodeViewData> views;
        private Dictionary<string, bool> storyFlags;
        private string currentViewId;
        private bool cutsceneActive;
        private NodeViewData activeCutsceneView;
        private List<DialogueLine> currentDialogueSequence;
        private int currentDialogueIndex;

        private void Awake()
        {
            if (uiManager == null)
            {
                uiManager = FindObjectOfType<UIManager>();
            }
        }

        private void Start()
        {
            views = FirstRoomData.Build();
            storyFlags = new Dictionary<string, bool>();
            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = false;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = false;
            storyFlags[FirstRoomData.JamesWarnedFlag] = false;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = false;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = false;
            storyFlags[FirstRoomData.Scene2StartedFlag] = false;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = false;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = false;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;
            storyFlags[FirstRoomData.Alt4SeenFlag] = false;
            storyFlags[FirstRoomData.Alt5SeenFlag] = false;
            storyFlags[FirstRoomData.Alt6SeenFlag] = false;
            storyFlags[FirstRoomData.Alt8SeenFlag] = false;
            storyFlags[FirstRoomData.Alt9SeenFlag] = false;
            storyFlags[FirstRoomData.Alt11SeenFlag] = false;
            storyFlags[FirstRoomData.Alt14SeenFlag] = false;
            storyFlags[FirstRoomData.Alt17SeenFlag] = false;
            storyFlags[FirstRoomData.Alt20SeenFlag] = false;
            storyFlags[FirstRoomData.Alt22SeenFlag] = false;
            currentViewId = FirstRoomData.StartViewId;
            RefreshCurrentView();
        }

        private void Update()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            // TEMP DEV SHORTCUT — remove before release
            if (enableDebugJumpToScene4 && !cutsceneActive)
            {
                if (Input.GetKeyDown(debugJumpToScene7Node18Key))
                {
                    var shiftHeldForNode19 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                    if (shiftHeldForNode19)
                    {
                        DebugJumpToScene7Node19();
                    }
                    else
                    {
                        DebugJumpToScene7Node18();
                    }

                    return;
                }

                var ctrlHeldForScene7Shortcuts = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
                var shiftHeldForAct3Scene1Node30 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                var altHeldForAct3Scene1Node30 = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
                if ((ctrlHeldForScene7Shortcuts &&
                     shiftHeldForAct3Scene1Node30 &&
                     Input.GetKeyDown(debugJumpToAct3Scene1Node30FallbackKey)) ||
                    (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToAct3Scene1Node30AlternateKey)) ||
                    (altHeldForAct3Scene1Node30 && Input.GetKeyDown(debugJumpToAct3Scene1Node30FallbackKey)))
                {
                    DebugJumpToAct3Scene1Node30();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    shiftHeldForAct3Scene1Node30 &&
                    Input.GetKeyDown(debugJumpToAct3Scene2Node31FallbackKey))
                {
                    DebugJumpToAct3Scene2Node31();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    shiftHeldForAct3Scene1Node30 &&
                    Input.GetKeyDown(debugJumpToAct3Scene2Node32FallbackKey))
                {
                    DebugJumpToAct3Scene2Node32();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    shiftHeldForAct3Scene1Node30 &&
                    Input.GetKeyDown(debugJumpToAct3Scene2Node33FallbackKey))
                {
                    DebugJumpToAct3Scene2Node33();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    Input.GetKeyDown(debugJumpToAct3Scene1Node29FallbackKey))
                {
                    DebugJumpToAct3Scene1Node29();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    Input.GetKeyDown(debugJumpToAct3Scene1Node28FallbackKey))
                {
                    DebugJumpToAct3Scene1Node28();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts &&
                    (Input.GetKeyDown(debugJumpToScene9Node27FallbackKey) ||
                     Input.GetKeyDown(debugJumpToScene9Node27AlternateKey)))
                {
                    DebugJumpToScene9Node27();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene9Node26FallbackKey))
                {
                    DebugJumpToScene9Node26();
                    return;
                }

                var shiftHeldForScene9Node25 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                if (ctrlHeldForScene7Shortcuts &&
                    ((shiftHeldForScene9Node25 && Input.GetKeyDown(debugJumpToScene9Node25FallbackKey)) ||
                     Input.GetKeyDown(debugJumpToScene9Node25AlternateKey)))
                {
                    DebugJumpToScene9Node25();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene9Node24FallbackKey))
                {
                    DebugJumpToScene9Node24();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene8Node23FallbackKey))
                {
                    DebugJumpToScene8Node23();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene8Node22FallbackKey))
                {
                    DebugJumpToScene8Node22();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene8Node21FallbackKey))
                {
                    DebugJumpToScene8Node21();
                    return;
                }

                if (ctrlHeldForScene7Shortcuts && Input.GetKeyDown(debugJumpToScene7Node20FallbackKey))
                {
                    DebugJumpToScene7Node20();
                    return;
                }

                var shiftHeldForScene7Node19 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                if (ctrlHeldForScene7Shortcuts && shiftHeldForScene7Node19 && Input.GetKeyDown(debugJumpToScene7Node19FallbackKey))
                {
                    DebugJumpToScene7Node19();
                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene6Node17Key))
                {
                    DebugJumpToScene6Node17();
                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene6Node16Key))
                {
                    var shiftHeldForNode16 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                    if (shiftHeldForNode16)
                    {
                        DebugJumpToScene6Node17();
                    }
                    else
                    {
                        DebugJumpToScene6Node16();
                    }

                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene6Node15Key))
                {
                    var shiftHeldForNode15 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                    if (shiftHeldForNode15)
                    {
                        DebugJumpToScene6Node16();
                    }
                    else
                    {
                        DebugJumpToScene6Node15();
                    }

                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene5Node14Key))
                {
                    DebugJumpToScene5Node14();
                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene5Node13Key))
                {
                    var shiftHeldForNode13 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                    if (shiftHeldForNode13)
                    {
                        DebugJumpToScene5Node14();
                    }
                    else
                    {
                        DebugJumpToScene5Node13();
                    }

                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene4Node12Key))
                {
                    DebugJumpToScene4Node12();
                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene4Node11Key))
                {
                    DebugJumpToScene4Node11();
                    return;
                }

                if (Input.GetKeyDown(debugJumpToScene4Key))
                {
                    var shiftHeld = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
                    if (shiftHeld)
                    {
                        DebugJumpToScene4Node11();
                    }
                    else
                    {
                        DebugJumpToScene4();
                    }

                    return;
                }
            }
#endif

            if (enableDebugJumpToScene2 && Input.GetKeyDown(debugJumpToScene2Key))
            {
                DebugJumpToScene2();
                return;
            }

            if (enableDebugJumpToScene3 && Input.GetKeyDown(debugJumpToScene3Key))
            {
                DebugJumpToScene3();
            }
        }

        [ContextMenu("Debug Jump To Scene 2 (4E)")]
        public void DebugJumpToScene2()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node4FrontYardEntryViewId;
            RefreshCurrentView();

            Debug.Log("Debug jump executed: moved to Scene 2 Node 4E.");
        }

        [ContextMenu("Debug Jump To Scene 3 (7W)")]
        public void DebugJumpToScene3()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node7EntryViewId;
            RefreshCurrentView();

            Debug.Log("Debug jump executed: moved to Scene 3 Node 7W.");
        }

        [ContextMenu("Debug Jump To Scene 4 (10W)")]
        public void DebugJumpToScene4()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node10EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 4 Node 10W.");
        }

        [ContextMenu("Debug Jump To Scene 4 (11W)")]
        public void DebugJumpToScene4Node11()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node11EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 4 Node 11W.");
        }

        [ContextMenu("Debug Jump To Scene 4 (12W)")]
        public void DebugJumpToScene4Node12()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node12EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 4 Node 12W.");
        }

        [ContextMenu("Debug Jump To Scene 5 (13W)")]
        public void DebugJumpToScene5Node13()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node13EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 5 Node 13W.");
        }

        [ContextMenu("Debug Jump To Scene 5 (14W)")]
        public void DebugJumpToScene5Node14()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node14EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 5 Node 14W.");
        }

        [ContextMenu("Debug Jump To Scene 6 (15W)")]
        public void DebugJumpToScene6Node15()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node15EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 6 Node 15W.");
        }

        [ContextMenu("Debug Jump To Scene 6 (16W)")]
        public void DebugJumpToScene6Node16()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node16EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 6 Node 16W.");
        }

        [ContextMenu("Debug Jump To Scene 6 (17W)")]
        public void DebugJumpToScene6Node17()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node17EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 6 Node 17W.");
        }

        [ContextMenu("Debug Jump To Scene 7 (18W)")]
        public void DebugJumpToScene7Node18()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node18EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 7 Node 18W.");
        }

        [ContextMenu("Debug Jump To Scene 7 (19W)")]
        public void DebugJumpToScene7Node19()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node19EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 7 Node 19W.");
        }

        [ContextMenu("Debug Jump To Scene 7 (20W)")]
        public void DebugJumpToScene7Node20()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node20EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 7 Node 20W.");
        }

        [ContextMenu("Debug Jump To Scene 8 (21W)")]
        public void DebugJumpToScene8Node21()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node21EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 8 Node 21W.");
        }

        [ContextMenu("Debug Jump To Scene 8 (22W)")]
        public void DebugJumpToScene8Node22()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node22EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 8 Node 22W.");
        }

        [ContextMenu("Debug Jump To Scene 8 (23W)")]
        public void DebugJumpToScene8Node23()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node23EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 8 Node 23W.");
        }

        [ContextMenu("Debug Jump To Scene 9 (24W)")]
        public void DebugJumpToScene9Node24()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node24EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 9 Node 24W.");
        }

        [ContextMenu("Debug Jump To Scene 9 (25W)")]
        public void DebugJumpToScene9Node25()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node25EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 9 Node 25W.");
        }

        [ContextMenu("Debug Jump To Scene 9 (26W)")]
        public void DebugJumpToScene9Node26()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node26EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 9 Node 26W.");
        }

        [ContextMenu("Debug Jump To Scene 9 (27W)")]
        public void DebugJumpToScene9Node27()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node27EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Scene 9 Node 27W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 1 (28W)")]
        public void DebugJumpToAct3Scene1Node28()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = false;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node28EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 1 Node 28W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 1 (29W)")]
        public void DebugJumpToAct3Scene1Node29()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = false;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node29EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 1 Node 29W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 1 (30W)")]
        public void DebugJumpToAct3Scene1Node30()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = false;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node30EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 1 Node 30W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 2 (31W)")]
        public void DebugJumpToAct3Scene2Node31()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node31EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 2 Node 31W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 2 (32W)")]
        public void DebugJumpToAct3Scene2Node32()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = false;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node32EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 2 Node 32W.");
        }

        [ContextMenu("Debug Jump To Act III Scene 2 (33W)")]
        public void DebugJumpToAct3Scene2Node33()
        {
            if (views == null)
            {
                views = FirstRoomData.Build();
            }

            if (storyFlags == null)
            {
                storyFlags = new Dictionary<string, bool>();
            }

            storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
            storyFlags[FirstRoomData.EavesdropCompleteFlag] = true;
            storyFlags[FirstRoomData.JamesWarnedFlag] = true;
            storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            storyFlags[FirstRoomData.MeetingCompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Act3Scene2WarningDeliveredFlag] = true;

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            currentViewId = FirstRoomData.Node33EntryViewId;
            RefreshCurrentView();

            Debug.Log("DEV SHORTCUT: Jumped to Act III Scene 2 Node 33W.");
        }

        private void RefreshCurrentView()
        {
            if (uiManager == null)
            {
                Debug.LogError("GameManager is missing a UIManager reference.");
                return;
            }

            if (!views.TryGetValue(currentViewId, out var currentView))
            {
                Debug.LogError($"View '{currentViewId}' was not found in FirstRoomData.");
                return;
            }

            if (!currentView.isCutscene && ShouldTriggerJamesWarningCutscene(currentView.viewId))
            {
                EnterCutscene(FirstRoomData.Node1WarningCutsceneViewId);
                return;
            }

            var displayView = GetContextualView(currentView);
            uiManager.DisplayView(displayView, OnHotspotClicked, OnNavigateRequested);

            if (displayView.isCutscene)
            {
                StartCutscene(displayView);
                return;
            }

            uiManager.ShowInfo(GetContextualInfoText(displayView));
        }

        private void OnNavigateRequested(NavigationDirection direction)
        {
            if (cutsceneActive)
            {
                return;
            }

            if (!views.TryGetValue(currentViewId, out var currentView))
            {
                return;
            }

            if (HandleBedroomDepartureNavigation(currentView.viewId, direction))
            {
                return;
            }

            if (ShouldSuppressExploration() && HandleSuppressedNavigation(currentView.viewId, direction))
            {
                return;
            }

            var targetViewId = GetNavigationTarget(currentView.navigation, direction);
            TryNavigateTo(targetViewId);
        }

        private static string GetNavigationTarget(NavigationTargets navigation, NavigationDirection direction)
        {
            if (navigation == null)
            {
                return string.Empty;
            }

            switch (direction)
            {
                case NavigationDirection.Left:
                    return navigation.left;
                case NavigationDirection.Right:
                    return navigation.right;
                case NavigationDirection.Back:
                    return navigation.back;
                case NavigationDirection.Forward:
                    return navigation.forward;
                default:
                    return string.Empty;
            }
        }

        private void TryNavigateTo(string targetViewId)
        {
            if (string.IsNullOrWhiteSpace(targetViewId))
            {
                uiManager.ShowInfo("There is no path in that direction.");
                return;
            }

            if (targetViewId == FirstRoomData.Node31EntryViewId &&
                !GetFlagValue(FirstRoomData.Act3Scene1CompleteFlag) &&
                GetNodeNumber(currentViewId) != 31)
            {
                uiManager.ShowInfo("The door has not opened yet. I must knock first.");
                return;
            }

            if (targetViewId == FirstRoomData.Node3BEavesdropViewId && !GetFlagValue(FirstRoomData.ChimneyCrackHeardFlag))
            {
                uiManager.ShowInfo("I need to listen more carefully through the chimney crack first.");
                return;
            }

            if (targetViewId == FirstRoomData.Node27MeetingCutsceneViewId)
            {
                StartMeetingCutscene();
                return;
            }

            if (targetViewId == FirstRoomData.Node33WarningCutsceneViewId)
            {
                StartWarningDeliveredCutscene();
                return;
            }

            if (targetViewId == FirstRoomData.Node34PlaceholderTarget)
            {
                uiManager.ShowInfo(FirstRoomData.Node34PlaceholderMessage);
                return;
            }

            NodeViewData targetView;
            if (views.TryGetValue(targetViewId, out targetView) && targetView.isCutscene)
            {
                EnterCutscene(targetViewId);
                return;
            }

            if (views.ContainsKey(targetViewId))
            {
                currentViewId = targetViewId;
                RefreshCurrentView();
                return;
            }

            uiManager.ShowInfo($"Target '{targetViewId}' is not implemented in this prototype.");
        }

        private void StartMeetingCutscene()
        {
            if (GetFlagValue(FirstRoomData.MeetingCompleteFlag))
            {
                currentViewId = FirstRoomData.Node27EntryViewId;
                RefreshCurrentView();
                return;
            }

            EnterCutscene(FirstRoomData.Node27MeetingCutsceneViewId);
        }

        private void StartThresholdCutscene()
        {
            if (GetFlagValue(FirstRoomData.Act3Scene1CompleteFlag))
            {
                uiManager.ShowInfo("The warning has been received at the threshold. The next step is inside.");
                return;
            }

            EnterCutscene(FirstRoomData.Node30ThresholdCutsceneViewId);
        }

        private void StartWarningDeliveredCutscene()
        {
            if (GetFlagValue(FirstRoomData.Act3Scene2WarningDeliveredFlag))
            {
                currentViewId = FirstRoomData.Node33EntryViewId;
                RefreshCurrentView();
                return;
            }

            EnterCutscene(FirstRoomData.Node33WarningCutsceneViewId);
        }

        private void OnHotspotClicked(HotspotData hotspot)
        {
            if (cutsceneActive || hotspot == null)
            {
                return;
            }

            if (hotspot.id == FirstRoomData.ChimneyCrackHotspotId)
            {
                Debug.Log("Chimney crack clicked.");

                var hasHeardCrack = GetFlagValue(FirstRoomData.ChimneyCrackHeardFlag);
                var eavesdropComplete = GetFlagValue(FirstRoomData.EavesdropCompleteFlag);

                if (!hasHeardCrack)
                {
                    storyFlags[FirstRoomData.ChimneyCrackHeardFlag] = true;
                    Debug.Log("CHIMNEY_CRACK_HEARD set to true.");

                    if (!string.IsNullOrWhiteSpace(hotspot.responseText))
                    {
                        uiManager.ShowInfo(hotspot.responseText);
                    }

                    return;
                }

                if (!eavesdropComplete)
                {
                    EnterCutscene(FirstRoomData.Node3BEavesdropViewId);
                    return;
                }

                uiManager.ShowInfo("I have heard enough. James must be warned.");
                return;
            }

            if (hotspot.id == FirstRoomData.ShawlHotspotId)
            {
                if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && !GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
                {
                    storyFlags[FirstRoomData.ReadyToLeaveFlag] = true;
                    uiManager.ShowInfo("I pull the shawl close around my shoulders. It is not armor, but it is what I have.\nObjective: Leave the bedroom quietly.");
                    return;
                }

                if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
                {
                    uiManager.ShowInfo("The shawl is already around my shoulders.");
                    return;
                }
            }

            if (hotspot.id == FirstRoomData.Node30KnockHotspotId)
            {
                if (!GetFlagValue(FirstRoomData.Act3Scene1CompleteFlag) && !string.IsNullOrWhiteSpace(hotspot.responseText))
                {
                    uiManager.ShowInfo(hotspot.responseText);
                }

                StartThresholdCutscene();
                return;
            }

            if (hotspot.id == FirstRoomData.Node30EnterHotspotId && !GetFlagValue(FirstRoomData.Act3Scene1CompleteFlag))
            {
                uiManager.ShowInfo("The door has not opened yet. I must knock first.");
                return;
            }

            if (ShouldSuppressExploration() && HandleSuppressedHotspot(currentViewId, hotspot))
            {
                return;
            }

            if (HandleBedroomDepartureHotspot(currentViewId, hotspot))
            {
                return;
            }

            if (hotspot.setsFlag && !string.IsNullOrWhiteSpace(hotspot.flagName))
            {
                storyFlags[hotspot.flagName] = hotspot.flagValue;
            }

            if (!string.IsNullOrWhiteSpace(hotspot.responseText))
            {
                uiManager.ShowInfo(hotspot.responseText);
            }

            if (!string.Equals(hotspot.actionType, "Exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(hotspot.targetViewId))
            {
                return;
            }

            TryNavigateTo(hotspot.targetViewId);
        }

        private void StartCutscene(NodeViewData cutsceneView)
        {
            cutsceneActive = true;
            activeCutsceneView = cutsceneView;
            currentDialogueSequence = cutsceneView.dialogueLines ?? new List<DialogueLine>();
            currentDialogueIndex = 0;

            if (cutsceneView.viewId == FirstRoomData.Node3BEavesdropViewId)
            {
                Debug.Log("3B-N dialogue line count: " + currentDialogueSequence.Count);
            }

            if (currentDialogueSequence.Count == 0)
            {
                CompleteCutscene();
                return;
            }

            ShowCurrentDialogueLine();
        }

        private void AdvanceCutscene()
        {
            if (!cutsceneActive || activeCutsceneView == null)
            {
                return;
            }

            Debug.Log("Continue clicked. Current dialogue index: " + currentDialogueIndex);

            currentDialogueIndex++;
            if (currentDialogueSequence == null || currentDialogueIndex >= currentDialogueSequence.Count)
            {
                CompleteCutscene();
                return;
            }

            ShowCurrentDialogueLine();
        }

        private void ShowCurrentDialogueLine()
        {
            if (!cutsceneActive || currentDialogueSequence == null)
            {
                return;
            }

            if (currentDialogueIndex < 0 || currentDialogueIndex >= currentDialogueSequence.Count)
            {
                CompleteCutscene();
                return;
            }

            var line = currentDialogueSequence[currentDialogueIndex];
            Debug.Log("Showing dialogue line " + (currentDialogueIndex + 1) + " of " + currentDialogueSequence.Count + ": " + line.speaker);
            uiManager.ShowCutsceneDialogue(line, AdvanceCutscene);
        }

        private void CompleteCutscene()
        {
            if (!cutsceneActive || activeCutsceneView == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(activeCutsceneView.cutsceneCompleteFlagName))
            {
                storyFlags[activeCutsceneView.cutsceneCompleteFlagName] = true;

                if (activeCutsceneView.cutsceneCompleteFlagName == FirstRoomData.EavesdropCompleteFlag)
                {
                    Debug.Log("EAVESDROP_COMPLETE set to true.");
                }
            }

            Debug.Log("Eavesdrop sequence complete.");

            var completionText = activeCutsceneView.cutsceneCompleteMessage;
            if (string.IsNullOrWhiteSpace(completionText))
            {
                completionText = "Laura has heard enough. James must be warned.";
            }

            var completionButtonLabel = activeCutsceneView.cutsceneCompleteButtonLabel;
            if (string.IsNullOrWhiteSpace(completionButtonLabel))
            {
                completionButtonLabel = activeCutsceneView.viewId == FirstRoomData.Node3BEavesdropViewId
                    ? "Return to Kitchen"
                    : "Continue";
            }

            uiManager.ShowCutsceneConclusion(completionText, completionButtonLabel, ReturnFromCutscene);
        }

        private void ReturnFromCutscene()
        {
            var returnViewId = string.Empty;
            if (activeCutsceneView != null)
            {
                returnViewId = activeCutsceneView.cutsceneReturnViewId;
            }

            cutsceneActive = false;
            activeCutsceneView = null;
            currentDialogueSequence = null;
            currentDialogueIndex = 0;

            TryNavigateTo(returnViewId);
        }

        private void EnterCutscene(string cutsceneViewId)
        {
            if (string.IsNullOrWhiteSpace(cutsceneViewId))
            {
                return;
            }

            NodeViewData cutsceneView;
            if (!views.TryGetValue(cutsceneViewId, out cutsceneView) || !cutsceneView.isCutscene)
            {
                Debug.LogError($"Cutscene view '{cutsceneViewId}' is missing or not marked as cutscene.");
                return;
            }

            if (cutsceneViewId == FirstRoomData.Node3BEavesdropViewId)
            {
                Debug.Log("Entering parlour eavesdrop cutscene.");
            }

            currentViewId = cutsceneViewId;
            RefreshCurrentView();
        }

        public bool GetFlagValue(string flagName)
        {
            if (storyFlags == null || string.IsNullOrWhiteSpace(flagName))
            {
                return false;
            }

            bool value;
            return storyFlags.TryGetValue(flagName, out value) && value;
        }

        private bool ShouldSuppressExploration()
        {
            return GetFlagValue(FirstRoomData.EavesdropCompleteFlag) && !GetFlagValue(FirstRoomData.JamesWarnedFlag);
        }

        private bool IsPreparingToLeaveBedroom()
        {
            return GetFlagValue(FirstRoomData.JamesWarnedFlag) && !GetFlagValue(FirstRoomData.ReadyToLeaveFlag);
        }

        private bool ShouldTriggerJamesWarningCutscene(string viewId)
        {
            if (viewId != "1N")
            {
                return false;
            }

            return GetFlagValue(FirstRoomData.EavesdropCompleteFlag) && !GetFlagValue(FirstRoomData.JamesWarnedFlag);
        }

        private bool HandleSuppressedNavigation(string viewId, NavigationDirection direction)
        {
            switch (viewId)
            {
                case "2N":
                    if (direction == NavigationDirection.Back)
                    {
                        return false;
                    }

                    uiManager.ShowInfo("Not now. James must hear what I have learned.");
                    return true;

                case "3E":
                    if (direction == NavigationDirection.Back)
                    {
                        return false;
                    }

                    if (direction == NavigationDirection.Forward)
                    {
                        uiManager.ShowInfo("No. I have heard enough. Back upstairs - quickly.");
                        return true;
                    }

                    uiManager.ShowInfo("Eyes forward. Don't draw attention - straight to the stairs.");
                    return true;

                case "3W":
                    if (direction == NavigationDirection.Forward)
                    {
                        return false;
                    }

                    uiManager.ShowInfo("Not now. The warning matters more than anything in this hall.");
                    return true;

                case "1A-S":
                    if (direction == NavigationDirection.Right)
                    {
                        return false;
                    }

                    if (direction == NavigationDirection.Back)
                    {
                        uiManager.ShowInfo("The bedroom is close. James must hear every word.");
                        return false;
                    }

                    if (direction == NavigationDirection.Forward)
                    {
                        uiManager.ShowInfo("No. Back toward the bedroom.");
                        return true;
                    }

                    if (direction == NavigationDirection.Left)
                    {
                        uiManager.ShowInfo("Not now. Keep moving.");
                        return true;
                    }

                    return false;

                case "1W":
                    if (direction == NavigationDirection.Right)
                    {
                        return false;
                    }

                    uiManager.ShowInfo("Turn back to James. He must know.");
                    return true;

                default:
                    return false;
            }
        }

        private bool HandleSuppressedHotspot(string viewId, HotspotData hotspot)
        {
            switch (viewId)
            {
                case "2N":
                    uiManager.ShowInfo("Not now. James must hear what I have learned.");
                    return true;

                case "3E":
                    if (hotspot.id == "3E_EXIT_01")
                    {
                        uiManager.ShowInfo("No. James must hear this now.");
                        return true;
                    }

                    uiManager.ShowInfo("Not now. Every second matters.");
                    return true;

                case "3W":
                    uiManager.ShowInfo("Not now. The warning matters more than anything in this hall.");
                    return true;

                case "1A-S":
                    uiManager.ShowInfo("Not now. Keep moving.");
                    return true;

                case "1A-W":
                    if (hotspot.id == "1A_W_BEDROOM_01")
                    {
                        TryNavigateTo("1N");
                        return true;
                    }

                    uiManager.ShowInfo("Not now. Keep moving.");
                    return true;

                default:
                    return false;
            }
        }

        private bool HandleBedroomDepartureNavigation(string viewId, NavigationDirection direction)
        {
            if (viewId != "1W" || direction != NavigationDirection.Forward)
            {
                return false;
            }

            if (IsPreparingToLeaveBedroom())
            {
                uiManager.ShowInfo("Not yet. I should take my shawl first.");
                return true;
            }

            if (!GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
            {
                return false;
            }

            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            TryNavigateTo(FirstRoomData.Node4FrontYardEntryViewId);
            return true;
        }

        private bool HandleBedroomDepartureHotspot(string viewId, HotspotData hotspot)
        {
            if (viewId != "1W")
            {
                return false;
            }

            if (!string.Equals(hotspot.actionType, "Exit", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (IsPreparingToLeaveBedroom())
            {
                uiManager.ShowInfo("Not yet. I should take my shawl first.");
                return true;
            }

            if (!GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
            {
                return false;
            }

            storyFlags[FirstRoomData.Scene1CompleteFlag] = true;
            storyFlags[FirstRoomData.Scene2StartedFlag] = true;
            TryNavigateTo(FirstRoomData.Node4FrontYardEntryViewId);
            return true;
        }

        private NodeViewData GetContextualView(NodeViewData sourceView)
        {
            if (sourceView == null)
            {
                return null;
            }

            return new NodeViewData
            {
                viewId = sourceView.viewId,
                title = sourceView.title,
                description = sourceView.description,
                backgroundKey = sourceView.backgroundKey,
                autoLine = GetContextualAutoLine(sourceView.viewId, sourceView.autoLine),
                hotspots = sourceView.hotspots,
                navigation = sourceView.navigation,
                facingDirection = sourceView.facingDirection,
                cameraBearing = sourceView.cameraBearing,
                showCompass = sourceView.showCompass,
                historicalDate = ResolveHistoricalDate(sourceView),
                localTimeWindow = ResolveLocalTimeWindow(sourceView),
                showHistoricalTime = !sourceView.isCutscene,
                isCutscene = sourceView.isCutscene,
                dialogueLines = sourceView.dialogueLines,
                cutsceneReturnViewId = sourceView.cutsceneReturnViewId,
                cutsceneCompleteFlagName = sourceView.cutsceneCompleteFlagName,
                cutsceneCompleteMessage = sourceView.cutsceneCompleteMessage,
                cutsceneCompleteButtonLabel = sourceView.cutsceneCompleteButtonLabel
            };
        }

        private static string ResolveHistoricalDate(NodeViewData sourceView)
        {
            if (sourceView != null && !string.IsNullOrWhiteSpace(sourceView.historicalDate))
            {
                return sourceView.historicalDate;
            }

            return "June 22, 1813";
        }

        private static string ResolveLocalTimeWindow(NodeViewData sourceView)
        {
            if (sourceView != null && !string.IsNullOrWhiteSpace(sourceView.localTimeWindow))
            {
                return sourceView.localTimeWindow;
            }

            var nodeNumber = GetNodeNumber(sourceView != null ? sourceView.viewId : string.Empty);
            if (nodeNumber >= 4 && nodeNumber <= 6)
            {
                return "04:40–05:40 a.m.";
            }

            if (nodeNumber >= 7 && nodeNumber <= 9)
            {
                return "06:15–08:30 a.m.";
            }

            if (nodeNumber >= 10 && nodeNumber <= 12)
            {
                return "08:30–10:45 a.m.";
            }

            if (nodeNumber >= 13 && nodeNumber <= 14)
            {
                return "10:45 a.m.–12:15 p.m.";
            }

            if (nodeNumber >= 15 && nodeNumber <= 17)
            {
                return "12:15–2:00 p.m.";
            }

            if (nodeNumber == 18)
            {
                return "2:00–2:30 p.m.";
            }

            if (nodeNumber == 19)
            {
                return "2:30–3:00 p.m.";
            }

            if (nodeNumber == 20)
            {
                return "3:00–3:30 p.m.";
            }

            if (nodeNumber == 21)
            {
                return "3:30–4:00 p.m.";
            }

            if (nodeNumber == 22)
            {
                return "4:00–4:30 p.m.";
            }

            if (nodeNumber == 23)
            {
                return "4:30–5:00 p.m.";
            }

            if (nodeNumber == 24)
            {
                return "5:45–6:20 p.m.";
            }

            if (nodeNumber == 25)
            {
                return "6:20–7:10 p.m.";
            }

            if (nodeNumber == 26)
            {
                return "7:10–8:00 p.m.";
            }

            if (nodeNumber == 27)
            {
                return "8:00–8:45 p.m.";
            }

            if (nodeNumber == 28)
            {
                return "8:45–9:20 p.m.";
            }

            if (nodeNumber == 29)
            {
                return "9:20–9:45 p.m.";
            }

            if (nodeNumber == 30)
            {
                return "9:45–10:00 p.m.";
            }

            if (nodeNumber == 31)
            {
                return "10:00–10:05 p.m.";
            }

            if (nodeNumber == 32)
            {
                return "10:05–10:12 p.m.";
            }

            if (nodeNumber == 33)
            {
                return "10:12–10:20 p.m.";
            }

            if (nodeNumber >= 1 && nodeNumber <= 3)
            {
                return "04:00–04:40 a.m.";
            }

            return "2:00–2:30 p.m.";
        }

        private static int GetNodeNumber(string viewId)
        {
            if (string.IsNullOrWhiteSpace(viewId))
            {
                return -1;
            }

            var index = 0;
            while (index < viewId.Length && char.IsDigit(viewId[index]))
            {
                index++;
            }

            if (index == 0)
            {
                return -1;
            }

            int nodeNumber;
            return int.TryParse(viewId.Substring(0, index), out nodeNumber) ? nodeNumber : -1;
        }

        private string GetContextualAutoLine(string viewId, string defaultAutoLine)
        {
            if (ShouldSuppressExploration())
            {
                switch (viewId)
                {
                    case "2N":
                        return "No time to linger - James must hear this at once.";
                    case "3E":
                        return "Eyes forward. Don't draw attention - straight to the stairs.";
                    case "3W":
                        return "The stairs are ahead. Move quietly - do not wake the soldiers below.";
                    case "1A-S":
                        return "Slow now. Each stair complains beneath me.";
                    case "1W":
                        return "James is just inside. Tell him now.";
                }
            }

            if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && viewId == "1N")
            {
                return "The warning has been spoken. Now I must prepare to leave.";
            }

            if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && !GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
            {
                switch (viewId)
                {
                    case "1E":
                        return "My shawl. If I leave by the fields, I will need it before dawn breaks fully.";
                    case "1W":
                        return "I cannot leave yet. I need my shawl.";
                }
            }

            if (GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
            {
                switch (viewId)
                {
                    case "1E":
                        return "The shawl is secure. Now to the door.";
                    case "1W":
                        return "The house waits in silence. I must leave before courage has time to falter.";
                }
            }

            return defaultAutoLine;
        }

        private string GetContextualInfoText(NodeViewData view)
        {
            if (view == null)
            {
                return string.Empty;
            }

            if (ShouldSuppressExploration())
            {
                switch (view.viewId)
                {
                    case "2N":
                        return "No time to linger - James must hear this at once.";
                    case "3E":
                        return "Eyes forward. Don't draw attention - straight to the stairs.";
                    case "3W":
                        return "The stairs are ahead. Move quietly - do not wake the soldiers below.";
                    case "1A-S":
                        return "The bedroom is close. James must hear every word.";
                    case "1W":
                        return "Turn back to James. He must know.";
                }
            }

            if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && view.viewId == "1N")
            {
                if (!GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
                {
                    return "Objective: Take your shawl before leaving.";
                }

                if (!GetFlagValue(FirstRoomData.Scene1CompleteFlag))
                {
                    return "Objective: Leave the bedroom quietly.";
                }

                return "Scene 1 complete. Next: Leaving Queenston.";
            }

            if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && view.viewId == "1E")
            {
                if (!GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
                {
                    return "Objective: Take your shawl before leaving.";
                }

                return "Objective: Leave the bedroom quietly.";
            }

            if (GetFlagValue(FirstRoomData.JamesWarnedFlag) && view.viewId == "1W")
            {
                if (!GetFlagValue(FirstRoomData.ReadyToLeaveFlag))
                {
                    return "Objective: Take your shawl before leaving.";
                }

                if (!GetFlagValue(FirstRoomData.Scene1CompleteFlag))
                {
                    return "Objective: Leave the bedroom quietly.";
                }

                return "Scene 1 complete. Next: Leaving Queenston.";
            }

            if (view.viewId == FirstRoomData.Node30EntryViewId)
            {
                if (GetFlagValue(FirstRoomData.Act3Scene1CompleteFlag))
                {
                    return "Objective: Enter DeCew House.";
                }

                return "Objective: Knock at the door.";
            }

            return view.description;
        }
    }
}
