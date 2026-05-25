using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PrototypeFirstRoom
{
    public class UIManager : MonoBehaviour
    {
        [Header("Background")]
        public UnityEngine.UI.Image backgroundPanel;
        [SerializeField] private UnityEngine.UI.Image lightingMoodOverlayPanel;
        public Component backgroundLabelText;
        public BackgroundLibrary backgroundLibrary;
        [SerializeField] private bool hideBackgroundLabelWhenSpritePresent = true;
        [SerializeField] private bool preserveBackgroundSpriteAspect = true;
        [SerializeField] private bool logMissingBackgroundSprites = true;
        [SerializeField] private bool enableScene1Node1CompositionOverlay = false;
        [SerializeField] private bool preferScene1Node1CompositionOverlayOverSprites = false;

        [Header("Text")]
        [SerializeField] private Component viewTitleText;
        [SerializeField] private Component autoLineText;
        [SerializeField] private Component infoPanelText;

        [Header("Hotspots")]
        [SerializeField] private Transform hotspotContainer;
        [SerializeField] private Button hotspotButtonPrefab;

        [Header("Navigation Buttons")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Button forwardButton;

        [Header("Cutscene")]
        [SerializeField] private GameObject hotspotPanelRoot;
        [SerializeField] private GameObject navigationPanelRoot;
        [SerializeField] private GameObject cutscenePanelRoot;
        [SerializeField] private Component cutsceneSpeakerText;
        [SerializeField] private Component cutsceneDialogueText;
        [SerializeField] private UnityEngine.UI.Image cutscenePortraitImage;
        [SerializeField] private bool hideCutscenePortraitWhenSpriteMissing = true;
        [SerializeField] private Button cutsceneAdvanceButton;
        [SerializeField] private Component cutsceneAdvanceButtonLabelText;

        [Header("Compass")]
        [SerializeField] private GameObject compassPanel;
        [SerializeField] private TMP_Text compassDirectionText;
        [SerializeField] private TMP_Text compassBearingText;

        [Header("Historical Time HUD")]
        [SerializeField] private GameObject historicalTimePanel;
        [SerializeField] private TMP_Text historicalDateText;
        [SerializeField] private TMP_Text historicalLocalTimeText;

        [Header("Mapped Hotspots (Scene 1 Node 1)")]
        [SerializeField] private bool enableMappedNode1Hotspots = true;
        [SerializeField] private KeyCode toggleLegacyButtonsKey = KeyCode.H;
        // TEMP HOTSPOT DEBUG: keep hidden in release builds unless needed for tuning.
        [SerializeField] private KeyCode toggleMappedHotspotDebugKey = KeyCode.J;

        private readonly List<Button> spawnedHotspotButtons = new List<Button>();
        private readonly HashSet<string> missingBackgroundSpriteKeys = new HashSet<string>();
        private readonly List<GameObject> scene1Node1CompositionObjects = new List<GameObject>();
        private readonly List<ScreenHotspot> activeMappedScreenHotspots = new List<ScreenHotspot>();
        private readonly List<GameObject> mappedHotspotDebugObjects = new List<GameObject>();
        private static readonly Dictionary<string, List<ScreenHotspot>> Scene1Node1MappedHotspotMap =
            CreateScene1Node1MappedHotspotMap();
        private Button fallbackCutsceneButton;
        private bool hasLoggedCutsceneWiringWarning;
        private RectTransform scene1Node1CompositionRoot;
        private RectTransform mappedHotspotDebugRoot;
        private string activeScene1Node1CompositionViewId;
        private NodeViewData activeMappedHotspotView;
        private Action<HotspotData> activeMappedHotspotCallback;
        private Action<NavigationDirection> activeMappedNavigationCallback;
        private TMP_Text mappedHotspotHoverLabel;
        private bool showLegacyButtonsForDebug;
        private bool showMappedHotspotDebug;
        private MappedCursorState mappedCursorState = MappedCursorState.Default;

        private enum MappedCursorState
        {
            Default,
            Look,
            Listen,
            Exit,
            TurnLeft,
            TurnRight,
            Back
        }

        private void Awake()
        {
            if (backgroundLibrary == null)
            {
                backgroundLibrary = FindObjectOfType<BackgroundLibrary>();
            }
        }

        private void Update()
        {
            HandleMappedHotspotToggleInput();
            HandleMappedHotspotPointer();

            if (showMappedHotspotDebug)
            {
                RefreshMappedHotspotDebugVisuals();
            }
        }

        public void DisplayView(
            NodeViewData viewData,
            Action<HotspotData> onHotspotClicked,
            Action<NavigationDirection> onNavigate)
        {
            if (viewData == null)
            {
                return;
            }

            if (viewTitleText != null)
            {
                SetText(viewTitleText, viewData.title);
            }

            if (autoLineText != null)
            {
                SetText(autoLineText, viewData.autoLine);
            }

            UpdateBackground(viewData);
            UpdateLightingMoodOverlay(viewData);
            UpdateCompass(viewData);
            UpdateHistoricalTime(viewData);

            if (viewData.isCutscene)
            {
                ShowCutsceneMode();
                ClearHotspotButtons();
                return;
            }

            ShowNormalMode();
            BuildHotspotButtons(viewData.hotspots, onHotspotClicked);
            ConfigureNavigation(viewData.navigation, onNavigate);
            ConfigureMappedHotspots(viewData, onHotspotClicked, onNavigate);
        }

        public void ShowCutsceneDialogue(DialogueLine line, Action onContinue)
        {
            ShowCutsceneMode();

            if (line != null)
            {
                var speakerTarget = cutsceneSpeakerText != null ? cutsceneSpeakerText : viewTitleText;
                var dialogueTarget = cutsceneDialogueText != null ? cutsceneDialogueText : infoPanelText;

                SetText(speakerTarget, line.speaker);
                SetText(dialogueTarget, line.text);
                UpdateCutscenePortrait(ResolveDialoguePortraitKey(line));
            }
            else
            {
                UpdateCutscenePortrait(null);
            }

            ConfigureCutsceneButton("Continue", onContinue);
        }

        public void ShowCutsceneConclusion(string message, string buttonLabel, Action onReturn)
        {
            ShowCutsceneMode();

            var speakerTarget = cutsceneSpeakerText != null ? cutsceneSpeakerText : viewTitleText;
            var dialogueTarget = cutsceneDialogueText != null ? cutsceneDialogueText : infoPanelText;

            SetText(speakerTarget, string.Empty);
            SetText(dialogueTarget, message ?? string.Empty);
            UpdateCutscenePortrait(null);
            ConfigureCutsceneButton(buttonLabel, onReturn);
        }

        public void ShowInfo(string message)
        {
            if (infoPanelText != null)
            {
                SetText(infoPanelText, message ?? string.Empty);
            }
        }

        public void UpdateCompass(NodeViewData viewData)
        {
            if (viewData == null || viewData.isCutscene || !viewData.showCompass)
            {
                SetPanelActive(compassPanel, false);
                return;
            }

            if (!EnsureCompassUiReferences())
            {
                return;
            }

            compassPanel.SetActive(true);

            if (compassDirectionText != null)
            {
                var facingDirection = string.IsNullOrWhiteSpace(viewData.facingDirection) ? "?" : viewData.facingDirection;
                compassDirectionText.text = "Facing: " + facingDirection;
            }

            if (compassBearingText != null)
            {
                compassBearingText.text = viewData.cameraBearing + "°";
            }
        }

        public void UpdateHistoricalTime(NodeViewData viewData)
        {
            if (viewData == null || viewData.isCutscene || !viewData.showHistoricalTime)
            {
                SetPanelActive(historicalTimePanel, false);
                return;
            }

            if (!EnsureHistoricalTimeUiReferences())
            {
                return;
            }

            historicalTimePanel.SetActive(true);
            historicalDateText.text = string.IsNullOrWhiteSpace(viewData.historicalDate)
                ? "June 22, 1813"
                : viewData.historicalDate;
            historicalLocalTimeText.text = "Local Time: " + (string.IsNullOrWhiteSpace(viewData.localTimeWindow)
                ? "Unknown"
                : viewData.localTimeWindow);
        }

        private bool EnsureCompassUiReferences()
        {
            if (compassPanel != null && compassDirectionText != null && compassBearingText != null)
            {
                return true;
            }

            if (compassPanel == null)
            {
                var existingCompassPanel = transform.Find("CompassPanel");
                if (existingCompassPanel != null)
                {
                    compassPanel = existingCompassPanel.gameObject;
                }
            }

            if (compassPanel == null)
            {
                var existingCompassPanelObject = GameObject.Find("CompassPanel");
                if (existingCompassPanelObject != null)
                {
                    compassPanel = existingCompassPanelObject;
                }
            }

            if (compassPanel == null)
            {
                var compassParent = GetCompassParent();
                if (compassParent == null)
                {
                    return false;
                }

                compassPanel = CreateCompassPanel(compassParent);
            }

            if (compassPanel == null)
            {
                return false;
            }

            if (compassDirectionText == null)
            {
                compassDirectionText = FindOrCreateCompassText(
                    compassPanel.transform,
                    "CompassDirectionText",
                    new Vector2(10f, -8f),
                    18,
                    FontStyles.Bold);
            }

            if (compassBearingText == null)
            {
                compassBearingText = FindOrCreateCompassText(
                    compassPanel.transform,
                    "CompassBearingText",
                    new Vector2(10f, -34f),
                    16,
                    FontStyles.Normal);
            }

            return compassDirectionText != null && compassBearingText != null;
        }

        private bool EnsureHistoricalTimeUiReferences()
        {
            if (historicalTimePanel != null && historicalDateText != null && historicalLocalTimeText != null)
            {
                return true;
            }

            if (historicalTimePanel == null)
            {
                var existingPanel = transform.Find("HistoricalTimePanel");
                if (existingPanel != null)
                {
                    historicalTimePanel = existingPanel.gameObject;
                }
            }

            if (historicalTimePanel == null)
            {
                var existingPanelObject = GameObject.Find("HistoricalTimePanel");
                if (existingPanelObject != null)
                {
                    historicalTimePanel = existingPanelObject;
                }
            }

            if (historicalTimePanel == null)
            {
                var hudParent = GetCompassParent();
                if (hudParent == null)
                {
                    return false;
                }

                historicalTimePanel = CreateHistoricalTimePanel(hudParent);
            }

            if (historicalTimePanel == null)
            {
                return false;
            }

            if (historicalDateText == null)
            {
                historicalDateText = FindOrCreateCompassText(
                    historicalTimePanel.transform,
                    "HistoricalDateText",
                    new Vector2(10f, -8f),
                    18,
                    FontStyles.Bold);
            }

            if (historicalLocalTimeText == null)
            {
                historicalLocalTimeText = FindOrCreateCompassText(
                    historicalTimePanel.transform,
                    "HistoricalLocalTimeText",
                    new Vector2(10f, -34f),
                    16,
                    FontStyles.Normal);
            }

            return historicalDateText != null && historicalLocalTimeText != null;
        }

        private Transform GetCompassParent()
        {
            var parentCanvas = GetComponentInParent<Canvas>();
            if (parentCanvas != null)
            {
                return parentCanvas.transform;
            }

            var fallbackCanvas = FindObjectOfType<Canvas>();
            if (fallbackCanvas != null)
            {
                return fallbackCanvas.transform;
            }

            return transform;
        }

        private static GameObject CreateCompassPanel(Transform parent)
        {
            var panelObject = new GameObject("CompassPanel", typeof(RectTransform), typeof(Image));
            panelObject.transform.SetParent(parent, false);

            var panelRect = panelObject.GetComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(1f, 1f);
            panelRect.anchorMax = new Vector2(1f, 1f);
            panelRect.pivot = new Vector2(1f, 1f);
            panelRect.anchoredPosition = new Vector2(-20f, -20f);
            panelRect.sizeDelta = new Vector2(170f, 64f);

            var panelImage = panelObject.GetComponent<Image>();
            panelImage.color = new Color(0f, 0f, 0f, 0.45f);

            return panelObject;
        }

        private static GameObject CreateHistoricalTimePanel(Transform parent)
        {
            var panelObject = new GameObject("HistoricalTimePanel", typeof(RectTransform), typeof(Image));
            panelObject.transform.SetParent(parent, false);

            var panelRect = panelObject.GetComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(0f, 1f);
            panelRect.anchorMax = new Vector2(0f, 1f);
            panelRect.pivot = new Vector2(0f, 1f);
            panelRect.anchoredPosition = new Vector2(20f, -20f);
            panelRect.sizeDelta = new Vector2(250f, 64f);

            var panelImage = panelObject.GetComponent<Image>();
            panelImage.color = new Color(0f, 0f, 0f, 0.45f);

            return panelObject;
        }

        private static TMP_Text FindOrCreateCompassText(
            Transform panelTransform,
            string objectName,
            Vector2 anchoredPosition,
            int fontSize,
            FontStyles fontStyle)
        {
            var existingChild = panelTransform.Find(objectName);
            if (existingChild != null)
            {
                var existingText = existingChild.GetComponent<TMP_Text>();
                if (existingText != null)
                {
                    return existingText;
                }
            }

            var existingTexts = panelTransform.GetComponentsInChildren<TMP_Text>(true);
            foreach (var existingText in existingTexts)
            {
                if (existingText != null && existingText.gameObject.name == objectName)
                {
                    return existingText;
                }
            }

            var textObject = new GameObject(objectName, typeof(RectTransform), typeof(TextMeshProUGUI));
            textObject.transform.SetParent(panelTransform, false);

            var textRect = textObject.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(0f, 1f);
            textRect.anchorMax = new Vector2(0f, 1f);
            textRect.pivot = new Vector2(0f, 1f);
            textRect.anchoredPosition = anchoredPosition;
            textRect.sizeDelta = new Vector2(150f, 24f);

            var textComponent = textObject.GetComponent<TextMeshProUGUI>();
            textComponent.alignment = TextAlignmentOptions.Left;
            textComponent.fontSize = fontSize;
            textComponent.fontStyle = fontStyle;
            textComponent.enableWordWrapping = false;
            textComponent.color = Color.white;
            textComponent.text = string.Empty;

            return textComponent;
        }

        private void UpdateBackground(NodeViewData viewData)
        {
            var backgroundKey = viewData != null ? viewData.backgroundKey : string.Empty;
            var backgroundSprite = ResolveBackgroundSprite(backgroundKey);
            var hasBackgroundSprite = backgroundSprite != null;
            var showScene1Node1CompositionOverlay = ShouldShowScene1Node1CompositionOverlay(viewData, hasBackgroundSprite);
            var overlayLabel = showScene1Node1CompositionOverlay
                ? GetScene1Node1CompositionLabel(viewData.viewId)
                : null;

            UpdateBackgroundLabel(backgroundKey, hasBackgroundSprite, showScene1Node1CompositionOverlay, overlayLabel);

            if (backgroundPanel == null)
            {
                HideScene1Node1CompositionOverlay();
                LogMissingBackgroundSpriteIfNeeded(backgroundKey, hasBackgroundSprite);
                return;
            }

            if (hasBackgroundSprite && !showScene1Node1CompositionOverlay)
            {
                HideScene1Node1CompositionOverlay();
                backgroundPanel.overrideSprite = backgroundSprite;
                backgroundPanel.preserveAspect = preserveBackgroundSpriteAspect;
                backgroundPanel.color = Color.white;
                return;
            }

            backgroundPanel.overrideSprite = null;
            backgroundPanel.preserveAspect = false;
            LogMissingBackgroundSpriteIfNeeded(backgroundKey, hasBackgroundSprite);

            if (showScene1Node1CompositionOverlay)
            {
                ShowScene1Node1CompositionOverlay(viewData.viewId);
            }
            else
            {
                HideScene1Node1CompositionOverlay();
            }

            switch (viewData.viewId)
            {
                case "1N":
                case "1N-WARN":
                    backgroundPanel.color = new Color(0.30f, 0.33f, 0.40f);
                    break;
                case "1E":
                    backgroundPanel.color = new Color(0.38f, 0.30f, 0.24f);
                    break;
                case "3B-N":
                    backgroundPanel.color = new Color(0.22f, 0.22f, 0.27f);
                    break;
                case "4E":
                    backgroundPanel.color = new Color(0.32f, 0.38f, 0.33f);
                    break;
                case "4N":
                    backgroundPanel.color = new Color(0.34f, 0.40f, 0.35f);
                    break;
                case "4S":
                    backgroundPanel.color = new Color(0.36f, 0.34f, 0.30f);
                    break;
                case "4W":
                    backgroundPanel.color = new Color(0.28f, 0.34f, 0.36f);
                    break;
                case "ALT4":
                    backgroundPanel.color = new Color(0.20f, 0.23f, 0.25f);
                    break;
                case "5N":
                    backgroundPanel.color = new Color(0.36f, 0.35f, 0.31f);
                    break;
                case "5E":
                    backgroundPanel.color = new Color(0.35f, 0.31f, 0.28f);
                    break;
                case "5S":
                    backgroundPanel.color = new Color(0.32f, 0.33f, 0.36f);
                    break;
                case "5W":
                    backgroundPanel.color = new Color(0.27f, 0.30f, 0.30f);
                    break;
                case "ALT5":
                    backgroundPanel.color = new Color(0.24f, 0.24f, 0.24f);
                    break;
                case "6N":
                    backgroundPanel.color = new Color(0.42f, 0.44f, 0.36f);
                    break;
                case "6E":
                    backgroundPanel.color = new Color(0.40f, 0.36f, 0.32f);
                    break;
                case "6S":
                    backgroundPanel.color = new Color(0.37f, 0.38f, 0.41f);
                    break;
                case "6W":
                    backgroundPanel.color = new Color(0.35f, 0.41f, 0.35f);
                    break;
                case "ALT6":
                    backgroundPanel.color = new Color(0.26f, 0.25f, 0.23f);
                    break;
                case "7W":
                    backgroundPanel.color = new Color(0.46f, 0.43f, 0.30f);
                    break;
                case "7N":
                    backgroundPanel.color = new Color(0.48f, 0.45f, 0.32f);
                    break;
                case "7E":
                    backgroundPanel.color = new Color(0.41f, 0.42f, 0.36f);
                    break;
                case "7S":
                    backgroundPanel.color = new Color(0.35f, 0.40f, 0.33f);
                    break;
                case "8W":
                    backgroundPanel.color = new Color(0.33f, 0.39f, 0.43f);
                    break;
                case "8N":
                    backgroundPanel.color = new Color(0.36f, 0.38f, 0.41f);
                    break;
                case "8E":
                    backgroundPanel.color = new Color(0.40f, 0.42f, 0.34f);
                    break;
                case "8S":
                    backgroundPanel.color = new Color(0.29f, 0.34f, 0.30f);
                    break;
                case "ALT8":
                    backgroundPanel.color = new Color(0.22f, 0.27f, 0.30f);
                    break;
                case "9W":
                    backgroundPanel.color = new Color(0.34f, 0.38f, 0.30f);
                    break;
                case "9N":
                    backgroundPanel.color = new Color(0.43f, 0.44f, 0.32f);
                    break;
                case "9E":
                    backgroundPanel.color = new Color(0.31f, 0.37f, 0.34f);
                    break;
                case "9S":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.28f);
                    break;
                case "ALT9":
                    backgroundPanel.color = new Color(0.20f, 0.25f, 0.22f);
                    break;
                case "10W":
                    backgroundPanel.color = new Color(0.39f, 0.37f, 0.31f);
                    break;
                case "10N":
                    backgroundPanel.color = new Color(0.44f, 0.42f, 0.33f);
                    break;
                case "10E":
                    backgroundPanel.color = new Color(0.34f, 0.39f, 0.34f);
                    break;
                case "10S":
                    backgroundPanel.color = new Color(0.32f, 0.34f, 0.36f);
                    break;
                case "11W":
                    backgroundPanel.color = new Color(0.36f, 0.35f, 0.30f);
                    break;
                case "11N":
                    backgroundPanel.color = new Color(0.38f, 0.40f, 0.34f);
                    break;
                case "11E":
                    backgroundPanel.color = new Color(0.34f, 0.36f, 0.35f);
                    break;
                case "11S":
                    backgroundPanel.color = new Color(0.31f, 0.33f, 0.35f);
                    break;
                case "ALT11":
                    backgroundPanel.color = new Color(0.22f, 0.24f, 0.23f);
                    break;
                case "12W":
                    backgroundPanel.color = new Color(0.46f, 0.44f, 0.36f);
                    break;
                case "12N":
                    backgroundPanel.color = new Color(0.38f, 0.41f, 0.39f);
                    break;
                case "12E":
                    backgroundPanel.color = new Color(0.42f, 0.40f, 0.34f);
                    break;
                case "12S":
                    backgroundPanel.color = new Color(0.43f, 0.39f, 0.33f);
                    break;
                case "13W":
                    backgroundPanel.color = new Color(0.45f, 0.42f, 0.35f);
                    break;
                case "13N":
                    backgroundPanel.color = new Color(0.39f, 0.41f, 0.37f);
                    break;
                case "13E":
                    backgroundPanel.color = new Color(0.41f, 0.40f, 0.34f);
                    break;
                case "13S":
                    backgroundPanel.color = new Color(0.40f, 0.37f, 0.32f);
                    break;
                case "14W":
                    backgroundPanel.color = new Color(0.47f, 0.43f, 0.33f);
                    break;
                case "14N":
                    backgroundPanel.color = new Color(0.41f, 0.40f, 0.35f);
                    break;
                case "14E":
                    backgroundPanel.color = new Color(0.44f, 0.41f, 0.34f);
                    break;
                case "14S":
                    backgroundPanel.color = new Color(0.31f, 0.33f, 0.30f);
                    break;
                case "ALT14":
                    backgroundPanel.color = new Color(0.30f, 0.27f, 0.24f);
                    break;
                case "15W":
                    backgroundPanel.color = new Color(0.36f, 0.38f, 0.32f);
                    break;
                case "15N":
                    backgroundPanel.color = new Color(0.33f, 0.36f, 0.35f);
                    break;
                case "15E":
                    backgroundPanel.color = new Color(0.35f, 0.37f, 0.34f);
                    break;
                case "15S":
                    backgroundPanel.color = new Color(0.34f, 0.35f, 0.31f);
                    break;
                case "16W":
                    backgroundPanel.color = new Color(0.30f, 0.35f, 0.31f);
                    break;
                case "16N":
                    backgroundPanel.color = new Color(0.28f, 0.34f, 0.32f);
                    break;
                case "16E":
                    backgroundPanel.color = new Color(0.29f, 0.36f, 0.34f);
                    break;
                case "16S":
                    backgroundPanel.color = new Color(0.31f, 0.35f, 0.30f);
                    break;
                case "17W":
                    backgroundPanel.color = new Color(0.34f, 0.36f, 0.31f);
                    break;
                case "17N":
                    backgroundPanel.color = new Color(0.30f, 0.34f, 0.33f);
                    break;
                case "17E":
                    backgroundPanel.color = new Color(0.32f, 0.35f, 0.34f);
                    break;
                case "17S":
                    backgroundPanel.color = new Color(0.31f, 0.34f, 0.30f);
                    break;
                case "ALT17":
                    backgroundPanel.color = new Color(0.24f, 0.26f, 0.23f);
                    break;
                case "18W":
                    backgroundPanel.color = new Color(0.30f, 0.35f, 0.28f);
                    break;
                case "18N":
                    backgroundPanel.color = new Color(0.33f, 0.36f, 0.31f);
                    break;
                case "18E":
                    backgroundPanel.color = new Color(0.29f, 0.34f, 0.27f);
                    break;
                case "18S":
                    backgroundPanel.color = new Color(0.35f, 0.37f, 0.30f);
                    break;
                case "19W":
                    backgroundPanel.color = new Color(0.26f, 0.31f, 0.24f);
                    break;
                case "19N":
                    backgroundPanel.color = new Color(0.28f, 0.33f, 0.26f);
                    break;
                case "19E":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.25f);
                    break;
                case "19S":
                    backgroundPanel.color = new Color(0.30f, 0.33f, 0.27f);
                    break;
                case "20W":
                    backgroundPanel.color = new Color(0.29f, 0.34f, 0.26f);
                    break;
                case "20N":
                    backgroundPanel.color = new Color(0.32f, 0.35f, 0.28f);
                    break;
                case "20E":
                    backgroundPanel.color = new Color(0.30f, 0.33f, 0.25f);
                    break;
                case "20S":
                    backgroundPanel.color = new Color(0.28f, 0.32f, 0.24f);
                    break;
                case "ALT20":
                    backgroundPanel.color = new Color(0.23f, 0.25f, 0.21f);
                    break;
                case "21W":
                    backgroundPanel.color = new Color(0.27f, 0.32f, 0.25f);
                    break;
                case "21N":
                    backgroundPanel.color = new Color(0.30f, 0.34f, 0.27f);
                    break;
                case "21E":
                    backgroundPanel.color = new Color(0.25f, 0.29f, 0.24f);
                    break;
                case "21S":
                    backgroundPanel.color = new Color(0.28f, 0.31f, 0.26f);
                    break;
                case "22W":
                    backgroundPanel.color = new Color(0.26f, 0.31f, 0.23f);
                    break;
                case "22N":
                    backgroundPanel.color = new Color(0.29f, 0.33f, 0.26f);
                    break;
                case "22E":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.23f);
                    break;
                case "22S":
                    backgroundPanel.color = new Color(0.27f, 0.30f, 0.25f);
                    break;
                case "ALT22":
                    backgroundPanel.color = new Color(0.21f, 0.23f, 0.20f);
                    break;
                case "23W":
                    backgroundPanel.color = new Color(0.31f, 0.35f, 0.27f);
                    break;
                case "23N":
                    backgroundPanel.color = new Color(0.29f, 0.33f, 0.28f);
                    break;
                case "23E":
                    backgroundPanel.color = new Color(0.25f, 0.29f, 0.24f);
                    break;
                case "23S":
                    backgroundPanel.color = new Color(0.30f, 0.34f, 0.29f);
                    break;
                case "24W":
                    backgroundPanel.color = new Color(0.33f, 0.36f, 0.28f);
                    break;
                case "24N":
                    backgroundPanel.color = new Color(0.30f, 0.34f, 0.29f);
                    break;
                case "24E":
                    backgroundPanel.color = new Color(0.27f, 0.30f, 0.26f);
                    break;
                case "24S":
                    backgroundPanel.color = new Color(0.34f, 0.33f, 0.27f);
                    break;
                case "25W":
                    backgroundPanel.color = new Color(0.28f, 0.31f, 0.24f);
                    break;
                case "25N":
                    backgroundPanel.color = new Color(0.27f, 0.30f, 0.25f);
                    break;
                case "25E":
                    backgroundPanel.color = new Color(0.26f, 0.29f, 0.24f);
                    break;
                case "25S":
                    backgroundPanel.color = new Color(0.29f, 0.30f, 0.23f);
                    break;
                case "26W":
                    backgroundPanel.color = new Color(0.26f, 0.30f, 0.24f);
                    break;
                case "26N":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.26f);
                    break;
                case "26E":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.25f);
                    break;
                case "26S":
                    backgroundPanel.color = new Color(0.25f, 0.29f, 0.24f);
                    break;
                case "27-MEET":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.24f);
                    break;
                case "27W":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.26f);
                    break;
                case "27N":
                    backgroundPanel.color = new Color(0.28f, 0.32f, 0.27f);
                    break;
                case "27E":
                    backgroundPanel.color = new Color(0.25f, 0.29f, 0.25f);
                    break;
                case "27S":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.23f);
                    break;
                case "28W":
                    backgroundPanel.color = new Color(0.29f, 0.33f, 0.28f);
                    break;
                case "28N":
                    backgroundPanel.color = new Color(0.26f, 0.30f, 0.27f);
                    break;
                case "28E":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.26f);
                    break;
                case "28S":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.27f);
                    break;
                case "29W":
                    backgroundPanel.color = new Color(0.31f, 0.33f, 0.29f);
                    break;
                case "29N":
                    backgroundPanel.color = new Color(0.26f, 0.30f, 0.28f);
                    break;
                case "29E":
                    backgroundPanel.color = new Color(0.24f, 0.28f, 0.27f);
                    break;
                case "29S":
                    backgroundPanel.color = new Color(0.29f, 0.31f, 0.28f);
                    break;
                case "30W":
                    backgroundPanel.color = new Color(0.30f, 0.32f, 0.29f);
                    break;
                case "30N":
                    backgroundPanel.color = new Color(0.26f, 0.29f, 0.28f);
                    break;
                case "30E":
                    backgroundPanel.color = new Color(0.24f, 0.27f, 0.27f);
                    break;
                case "30S":
                    backgroundPanel.color = new Color(0.28f, 0.30f, 0.28f);
                    break;
                case "31W":
                    backgroundPanel.color = new Color(0.38f, 0.33f, 0.24f);
                    break;
                case "31N":
                    backgroundPanel.color = new Color(0.35f, 0.31f, 0.23f);
                    break;
                case "31E":
                    backgroundPanel.color = new Color(0.32f, 0.29f, 0.24f);
                    break;
                case "31S":
                    backgroundPanel.color = new Color(0.34f, 0.30f, 0.22f);
                    break;
                case "32W":
                    backgroundPanel.color = new Color(0.36f, 0.31f, 0.23f);
                    break;
                case "32N":
                    backgroundPanel.color = new Color(0.33f, 0.29f, 0.22f);
                    break;
                case "32E":
                    backgroundPanel.color = new Color(0.30f, 0.27f, 0.22f);
                    break;
                case "32S":
                    backgroundPanel.color = new Color(0.34f, 0.30f, 0.24f);
                    break;
                case "33-WARN":
                    backgroundPanel.color = new Color(0.29f, 0.26f, 0.20f);
                    break;
                case "33W":
                    backgroundPanel.color = new Color(0.35f, 0.30f, 0.22f);
                    break;
                case "33N":
                    backgroundPanel.color = new Color(0.33f, 0.28f, 0.21f);
                    break;
                case "33E":
                    backgroundPanel.color = new Color(0.29f, 0.26f, 0.21f);
                    break;
                case "33S":
                    backgroundPanel.color = new Color(0.34f, 0.29f, 0.23f);
                    break;
                case "34W":
                    backgroundPanel.color = new Color(0.37f, 0.31f, 0.22f);
                    break;
                case "34N":
                    backgroundPanel.color = new Color(0.34f, 0.29f, 0.22f);
                    break;
                case "34E":
                    backgroundPanel.color = new Color(0.30f, 0.27f, 0.22f);
                    break;
                case "34S":
                    backgroundPanel.color = new Color(0.35f, 0.30f, 0.23f);
                    break;
                case "35W":
                    backgroundPanel.color = new Color(0.30f, 0.33f, 0.27f);
                    break;
                case "35N":
                    backgroundPanel.color = new Color(0.32f, 0.35f, 0.29f);
                    break;
                case "35E":
                    backgroundPanel.color = new Color(0.28f, 0.32f, 0.28f);
                    break;
                case "35S":
                    backgroundPanel.color = new Color(0.31f, 0.34f, 0.28f);
                    break;
                case "36W":
                    backgroundPanel.color = new Color(0.27f, 0.31f, 0.26f);
                    break;
                case "36N":
                    backgroundPanel.color = new Color(0.26f, 0.30f, 0.27f);
                    break;
                case "36E":
                    backgroundPanel.color = new Color(0.28f, 0.31f, 0.27f);
                    break;
                case "36S":
                    backgroundPanel.color = new Color(0.29f, 0.32f, 0.27f);
                    break;
                case "1S":
                    backgroundPanel.color = new Color(0.34f, 0.31f, 0.25f);
                    break;
                case "1W":
                    backgroundPanel.color = new Color(0.26f, 0.28f, 0.33f);
                    break;
                default:
                    backgroundPanel.color = new Color(0.30f, 0.30f, 0.30f);
                    break;
            }
        }

        private bool ShouldShowScene1Node1CompositionOverlay(NodeViewData viewData, bool hasBackgroundSprite)
        {
            if (!enableScene1Node1CompositionOverlay || viewData == null)
            {
                return false;
            }

            if (!IsScene1Node1CompositionView(viewData.viewId))
            {
                return false;
            }

            // Always prefer real imported sprites when they exist.
            if (hasBackgroundSprite)
            {
                return false;
            }

            return true;
        }

        private void UpdateLightingMoodOverlay(NodeViewData viewData)
        {
            if (viewData == null)
            {
                SetLightingMoodOverlayActive(false);
                return;
            }

            var overlayOpacity = Mathf.Clamp01(viewData.overlayOpacity);
            if (overlayOpacity <= 0f)
            {
                SetLightingMoodOverlayActive(false);
                return;
            }

            if (!EnsureLightingMoodOverlayPanel())
            {
                return;
            }

            var overlayColor = viewData.overlayColor;
            overlayColor.a = overlayOpacity;
            lightingMoodOverlayPanel.color = overlayColor;
            SetLightingMoodOverlayActive(true);
        }

        private bool EnsureLightingMoodOverlayPanel()
        {
            if (lightingMoodOverlayPanel != null)
            {
                return true;
            }

            if (backgroundPanel == null)
            {
                return false;
            }

            var existingOverlay = backgroundPanel.transform.Find("LightingMoodOverlay");
            if (existingOverlay != null)
            {
                lightingMoodOverlayPanel = existingOverlay.GetComponent<Image>();
            }

            if (lightingMoodOverlayPanel == null)
            {
                var overlayObject = new GameObject("LightingMoodOverlay", typeof(RectTransform), typeof(Image));
                overlayObject.transform.SetParent(backgroundPanel.transform, false);

                var overlayRect = overlayObject.GetComponent<RectTransform>();
                overlayRect.anchorMin = Vector2.zero;
                overlayRect.anchorMax = Vector2.one;
                overlayRect.offsetMin = Vector2.zero;
                overlayRect.offsetMax = Vector2.zero;

                lightingMoodOverlayPanel = overlayObject.GetComponent<Image>();
            }

            if (lightingMoodOverlayPanel == null)
            {
                return false;
            }

            lightingMoodOverlayPanel.raycastTarget = false;
            lightingMoodOverlayPanel.transform.SetAsLastSibling();
            return true;
        }

        private void SetLightingMoodOverlayActive(bool isActive)
        {
            if (lightingMoodOverlayPanel != null)
            {
                lightingMoodOverlayPanel.gameObject.SetActive(isActive);
            }
        }

        private static bool IsScene1Node1CompositionView(string viewId)
        {
            return string.Equals(viewId, "1N", StringComparison.Ordinal) ||
                   string.Equals(viewId, "1E", StringComparison.Ordinal) ||
                   string.Equals(viewId, "1S", StringComparison.Ordinal) ||
                   string.Equals(viewId, "1W", StringComparison.Ordinal);
        }

        private static string GetScene1Node1CompositionLabel(string viewId)
        {
            switch (viewId)
            {
                case "1N":
                    return "1N — James Resting / Candlelit Bed";
                case "1E":
                    return "1E — Wardrobe & Shawl";
                case "1S":
                    return "1S — Children's Keepsakes";
                case "1W":
                    return "1W — Bedroom Doorway";
                default:
                    return viewId;
            }
        }

        private void EnsureScene1Node1CompositionRoot()
        {
            if (scene1Node1CompositionRoot != null || backgroundPanel == null)
            {
                return;
            }

            var rootObject = new GameObject("Scene1Node1CompositionOverlay", typeof(RectTransform));
            scene1Node1CompositionRoot = rootObject.GetComponent<RectTransform>();
            scene1Node1CompositionRoot.SetParent(backgroundPanel.transform, false);
            scene1Node1CompositionRoot.anchorMin = Vector2.zero;
            scene1Node1CompositionRoot.anchorMax = Vector2.one;
            scene1Node1CompositionRoot.offsetMin = Vector2.zero;
            scene1Node1CompositionRoot.offsetMax = Vector2.zero;
            rootObject.SetActive(false);
        }

        private void ShowScene1Node1CompositionOverlay(string viewId)
        {
            EnsureScene1Node1CompositionRoot();
            if (scene1Node1CompositionRoot == null)
            {
                return;
            }

            if (string.Equals(activeScene1Node1CompositionViewId, viewId, StringComparison.Ordinal) &&
                scene1Node1CompositionRoot.gameObject.activeSelf)
            {
                return;
            }

            ClearScene1Node1CompositionOverlay();
            BuildScene1Node1CompositionOverlay(viewId);
            activeScene1Node1CompositionViewId = viewId;
            scene1Node1CompositionRoot.gameObject.SetActive(true);
        }

        private void HideScene1Node1CompositionOverlay()
        {
            if (scene1Node1CompositionRoot != null)
            {
                scene1Node1CompositionRoot.gameObject.SetActive(false);
            }
        }

        private void BuildScene1Node1CompositionOverlay(string viewId)
        {
            if (scene1Node1CompositionRoot == null)
            {
                return;
            }

            AddCompositionRect("VignetteTop", new Vector2(0f, 0.82f), new Vector2(1f, 1f), new Color(0f, 0f, 0f, 0.25f));
            AddCompositionRect("VignetteBottom", new Vector2(0f, 0f), new Vector2(1f, 0.15f), new Color(0f, 0f, 0f, 0.20f));

            switch (viewId)
            {
                case "1N":
                    BuildScene1Node1Composition1N();
                    break;
                case "1E":
                    BuildScene1Node1Composition1E();
                    break;
                case "1S":
                    BuildScene1Node1Composition1S();
                    break;
                case "1W":
                    BuildScene1Node1Composition1W();
                    break;
            }
        }

        private void BuildScene1Node1Composition1N()
        {
            AddCompositionRect("WallBackground", Vector2.zero, Vector2.one, new Color(0.15f, 0.17f, 0.22f, 1.0f));
            AddCompositionText("ViewLabel", "BEDROOM - NORTH (1N)", new Vector2(0.3f, 0.85f), new Vector2(0.7f, 0.95f), 32, FontStyles.Bold, TextAlignmentOptions.Center, new Color(1f, 1f, 1f, 0.5f));
            AddCompositionRect("BedSilhouette", new Vector2(0.52f, 0.17f), new Vector2(0.94f, 0.37f), new Color(0.10f, 0.11f, 0.15f, 0.90f));
            AddCompositionRect("JamesSilhouette", new Vector2(0.62f, 0.29f), new Vector2(0.84f, 0.42f), new Color(0.06f, 0.07f, 0.10f, 0.88f));
            AddCompositionRect("BedPillow", new Vector2(0.54f, 0.31f), new Vector2(0.63f, 0.38f), new Color(0.18f, 0.18f, 0.22f, 0.70f));
            AddCompositionRect("TableSilhouette", new Vector2(0.10f, 0.16f), new Vector2(0.35f, 0.29f), new Color(0.12f, 0.09f, 0.07f, 0.86f));
            AddCompositionRect("CandleBase", new Vector2(0.18f, 0.28f), new Vector2(0.20f, 0.36f), new Color(0.30f, 0.24f, 0.18f, 0.95f));
            AddCompositionText("CandleGlow", "●", new Vector2(0.15f, 0.33f), new Vector2(0.23f, 0.47f), 96, FontStyles.Normal, TextAlignmentOptions.Center, new Color(1.00f, 0.73f, 0.32f, 0.24f));
            AddCompositionText("TableLabel", "Medicine / Water Pitcher", new Vector2(0.11f, 0.20f), new Vector2(0.36f, 0.28f), 22, FontStyles.Italic, TextAlignmentOptions.Left, new Color(0.92f, 0.92f, 0.90f, 0.80f));
        }

        private void BuildScene1Node1Composition1E()
        {
            AddCompositionRect("WallBackground", Vector2.zero, Vector2.one, new Color(0.22f, 0.18f, 0.15f, 1.0f));
            AddCompositionText("ViewLabel", "BEDROOM - EAST (1E)", new Vector2(0.3f, 0.85f), new Vector2(0.7f, 0.95f), 32, FontStyles.Bold, TextAlignmentOptions.Center, new Color(1f, 1f, 1f, 0.5f));
            AddCompositionRect("WardrobeSilhouette", new Vector2(0.10f, 0.20f), new Vector2(0.34f, 0.80f), new Color(0.09f, 0.08f, 0.07f, 0.92f));
            AddCompositionRect("WardrobeDoorLine", new Vector2(0.215f, 0.23f), new Vector2(0.225f, 0.78f), new Color(0.22f, 0.17f, 0.14f, 0.70f));
            AddCompositionRect("ShawlShape", new Vector2(0.25f, 0.50f), new Vector2(0.35f, 0.69f), new Color(0.34f, 0.23f, 0.18f, 0.82f));
            AddCompositionRect("MendingTable", new Vector2(0.50f, 0.18f), new Vector2(0.84f, 0.33f), new Color(0.12f, 0.09f, 0.07f, 0.86f));
            AddCompositionRect("MendingKit", new Vector2(0.58f, 0.28f), new Vector2(0.68f, 0.33f), new Color(0.24f, 0.22f, 0.19f, 0.86f));
            AddCompositionRect("EmberGlow", new Vector2(0.36f, 0.00f), new Vector2(0.94f, 0.18f), new Color(0.60f, 0.26f, 0.10f, 0.20f));
        }

        private void BuildScene1Node1Composition1S()
        {
            AddCompositionRect("WallBackground", Vector2.zero, Vector2.one, new Color(0.18f, 0.16f, 0.14f, 1.0f));
            AddCompositionText("ViewLabel", "BEDROOM - SOUTH (1S)", new Vector2(0.3f, 0.85f), new Vector2(0.7f, 0.95f), 32, FontStyles.Bold, TextAlignmentOptions.Center, new Color(1f, 1f, 1f, 0.5f));
            AddCompositionRect("DrawingArea", new Vector2(0.10f, 0.50f), new Vector2(0.42f, 0.80f), new Color(0.16f, 0.14f, 0.12f, 0.82f));
            AddCompositionRect("DrawingSheet", new Vector2(0.16f, 0.56f), new Vector2(0.33f, 0.74f), new Color(0.86f, 0.83f, 0.72f, 0.48f));
            AddCompositionText("DrawingMark", "Children's Drawing", new Vector2(0.16f, 0.58f), new Vector2(0.33f, 0.64f), 18, FontStyles.Normal, TextAlignmentOptions.Center, new Color(0.14f, 0.14f, 0.14f, 0.80f));
            AddCompositionRect("KeepsakeBox", new Vector2(0.54f, 0.18f), new Vector2(0.72f, 0.30f), new Color(0.14f, 0.10f, 0.08f, 0.90f));
            AddCompositionRect("RagDollBody", new Vector2(0.76f, 0.17f), new Vector2(0.82f, 0.31f), new Color(0.26f, 0.20f, 0.17f, 0.86f));
            AddCompositionText("RagDollHead", "●", new Vector2(0.76f, 0.29f), new Vector2(0.82f, 0.37f), 42, FontStyles.Normal, TextAlignmentOptions.Center, new Color(0.35f, 0.28f, 0.24f, 0.88f));
            AddCompositionRect("ShoeLeft", new Vector2(0.14f, 0.10f), new Vector2(0.20f, 0.14f), new Color(0.08f, 0.07f, 0.06f, 0.90f));
            AddCompositionRect("ShoeRight", new Vector2(0.205f, 0.10f), new Vector2(0.265f, 0.14f), new Color(0.08f, 0.07f, 0.06f, 0.90f));
        }

        private void BuildScene1Node1Composition1W()
        {
            AddCompositionRect("WallBackground", Vector2.zero, Vector2.one, new Color(0.12f, 0.11f, 0.10f, 1.0f));
            AddCompositionText("ViewLabel", "BEDROOM - WEST (1W)", new Vector2(0.3f, 0.85f), new Vector2(0.7f, 0.95f), 32, FontStyles.Bold, TextAlignmentOptions.Center, new Color(1f, 1f, 1f, 0.5f));
            AddCompositionRect("DoorFrame", new Vector2(0.35f, 0.12f), new Vector2(0.64f, 0.82f), new Color(0.12f, 0.10f, 0.09f, 0.88f));
            AddCompositionRect("HallShadow", new Vector2(0.40f, 0.16f), new Vector2(0.59f, 0.76f), new Color(0.03f, 0.04f, 0.06f, 0.94f));
            AddCompositionRect("ShadowSpill", new Vector2(0.30f, 0.00f), new Vector2(0.70f, 0.20f), new Color(0.02f, 0.03f, 0.05f, 0.45f));
            AddCompositionRect("DoorSideWall", new Vector2(0.64f, 0.13f), new Vector2(0.78f, 0.80f), new Color(0.20f, 0.18f, 0.16f, 0.45f));
            AddCompositionRect("ShoeNearDoor", new Vector2(0.29f, 0.11f), new Vector2(0.35f, 0.15f), new Color(0.09f, 0.07f, 0.06f, 0.90f));
            AddCompositionText("PosyNearDoor", "✿", new Vector2(0.66f, 0.10f), new Vector2(0.71f, 0.16f), 28, FontStyles.Normal, TextAlignmentOptions.Center, new Color(0.70f, 0.60f, 0.52f, 0.65f));
        }

        private Image AddCompositionRect(string name, Vector2 anchorMin, Vector2 anchorMax, Color color)
        {
            if (scene1Node1CompositionRoot == null)
            {
                return null;
            }

            var element = new GameObject(name, typeof(RectTransform), typeof(Image));
            var rectTransform = element.GetComponent<RectTransform>();
            rectTransform.SetParent(scene1Node1CompositionRoot, false);
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            var image = element.GetComponent<Image>();
            image.color = color;
            image.raycastTarget = false;

            scene1Node1CompositionObjects.Add(element);
            return image;
        }

        private TextMeshProUGUI AddCompositionText(
            string name,
            string text,
            Vector2 anchorMin,
            Vector2 anchorMax,
            int fontSize,
            FontStyles style,
            TextAlignmentOptions alignment,
            Color color)
        {
            if (scene1Node1CompositionRoot == null)
            {
                return null;
            }

            var element = new GameObject(name, typeof(RectTransform), typeof(TextMeshProUGUI));
            var rectTransform = element.GetComponent<RectTransform>();
            rectTransform.SetParent(scene1Node1CompositionRoot, false);
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;

            var textComponent = element.GetComponent<TextMeshProUGUI>();
            textComponent.text = text;
            textComponent.fontSize = fontSize;
            textComponent.fontStyle = style;
            textComponent.alignment = alignment;
            textComponent.color = color;
            textComponent.raycastTarget = false;
            textComponent.enableWordWrapping = false;

            scene1Node1CompositionObjects.Add(element);
            return textComponent;
        }

        private void ClearScene1Node1CompositionOverlay()
        {
            foreach (var overlayObject in scene1Node1CompositionObjects)
            {
                if (overlayObject != null)
                {
                    Destroy(overlayObject);
                }
            }

            scene1Node1CompositionObjects.Clear();
        }

        private Sprite ResolveBackgroundSprite(string backgroundKey)
        {
            if (string.IsNullOrWhiteSpace(backgroundKey))
            {
                return null;
            }

            if (backgroundLibrary == null)
            {
                backgroundLibrary = FindObjectOfType<BackgroundLibrary>();
            }

            var sprite = backgroundLibrary != null
                ? backgroundLibrary.GetSprite(backgroundKey)
                : BackgroundLibrary.LoadDefaultResourceSprite(backgroundKey);

            return sprite;
        }

        private void UpdateBackgroundLabel(
            string backgroundKey,
            bool hasBackgroundSprite,
            bool showScene1Node1CompositionOverlay,
            string compositionLabel)
        {
            if (backgroundLabelText == null)
            {
                return;
            }

            if (showScene1Node1CompositionOverlay)
            {
                SetComponentActive(backgroundLabelText, true);
                SetText(backgroundLabelText, string.IsNullOrWhiteSpace(compositionLabel) ? backgroundKey ?? string.Empty : compositionLabel);
                return;
            }

            if (hasBackgroundSprite && hideBackgroundLabelWhenSpritePresent)
            {
                if (backgroundPanel != null && backgroundLabelText.gameObject == backgroundPanel.gameObject)
                {
                    SetText(backgroundLabelText, string.Empty);
                    return;
                }

                SetComponentActive(backgroundLabelText, false);
                return;
            }

            SetComponentActive(backgroundLabelText, true);
            SetText(backgroundLabelText, backgroundKey ?? string.Empty);
        }

        private void LogMissingBackgroundSpriteIfNeeded(string backgroundKey, bool hasBackgroundSprite)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (!logMissingBackgroundSprites || hasBackgroundSprite || string.IsNullOrWhiteSpace(backgroundKey))
            {
                return;
            }

            var trackedByLibrary = backgroundLibrary != null && backgroundLibrary.HasEntry(backgroundKey);
            var trackedByDefaultMap = BackgroundLibrary.HasDefaultResourceMapping(backgroundKey);
            if (!trackedByLibrary && !trackedByDefaultMap)
            {
                return;
            }

            if (missingBackgroundSpriteKeys.Add(backgroundKey))
            {
                Debug.LogWarning("Missing background sprite for key: " + backgroundKey);
            }
#endif
        }

        private void ConfigureMappedHotspots(
            NodeViewData viewData,
            Action<HotspotData> onHotspotClicked,
            Action<NavigationDirection> onNavigate)
        {
            activeMappedHotspotView = viewData;
            activeMappedHotspotCallback = onHotspotClicked;
            activeMappedNavigationCallback = onNavigate;

            activeMappedScreenHotspots.Clear();

            if (enableMappedNode1Hotspots &&
                viewData != null &&
                Scene1Node1MappedHotspotMap.TryGetValue(viewData.viewId, out var mappedHotspots) &&
                mappedHotspots != null)
            {
                activeMappedScreenHotspots.AddRange(mappedHotspots);
            }

            RefreshLegacyButtonVisibility();
            RefreshMappedHotspotDebugVisuals();

            if (!IsMappedHotspotInteractionEnabled())
            {
                ClearMappedHotspotHoverLabel();
            }
        }

        private void DeactivateMappedHotspots()
        {
            activeMappedHotspotView = null;
            activeMappedHotspotCallback = null;
            activeMappedNavigationCallback = null;
            activeMappedScreenHotspots.Clear();
            ClearMappedHotspotHoverLabel();
            ClearMappedHotspotDebugVisuals();

            if (mappedHotspotDebugRoot != null)
            {
                mappedHotspotDebugRoot.gameObject.SetActive(false);
            }
        }

        private void HandleMappedHotspotToggleInput()
        {
            if (Input.GetKeyDown(toggleLegacyButtonsKey))
            {
                showLegacyButtonsForDebug = !showLegacyButtonsForDebug;
                RefreshLegacyButtonVisibility();
            }

            if (Input.GetKeyDown(toggleMappedHotspotDebugKey))
            {
                showMappedHotspotDebug = !showMappedHotspotDebug;
                RefreshMappedHotspotDebugVisuals();
            }
        }

        private void HandleMappedHotspotPointer()
        {
            if (!IsMappedHotspotInteractionEnabled())
            {
                ClearMappedHotspotHoverLabel();
                return;
            }

            if (!TryGetPointerPositionInBackground(out var normalizedPosition))
            {
                ClearMappedHotspotHoverLabel();
                return;
            }

            if (!TryFindHoveredMappedHotspot(normalizedPosition, out var hoveredHotspot))
            {
                ClearMappedHotspotHoverLabel();
                return;
            }

            UpdateMappedHotspotHoverLabel(hoveredHotspot);

            if (Input.GetMouseButtonDown(0))
            {
                HandleMappedHotspotClicked(hoveredHotspot);
            }
        }

        private bool HasMappedHotspotsForCurrentView()
        {
            return activeMappedHotspotView != null && !activeMappedHotspotView.isCutscene && activeMappedScreenHotspots.Count > 0;
        }

        private bool IsMappedHotspotInteractionEnabled()
        {
            return HasMappedHotspotsForCurrentView() && !showLegacyButtonsForDebug;
        }

        private bool TryFindHoveredMappedHotspot(Vector2 normalizedPosition, out ScreenHotspot hoveredHotspot)
        {
            hoveredHotspot = null;
            var bestScore = float.MinValue;

            foreach (var hotspot in activeMappedScreenHotspots)
            {
                if (hotspot == null || !hotspot.normalizedRect.Contains(normalizedPosition) || !IsMappedHotspotAvailable(hotspot))
                {
                    continue;
                }

                var area = hotspot.normalizedRect.width * hotspot.normalizedRect.height;
                var score = (hotspot.priority * 1000f) - area;

                if (score <= bestScore)
                {
                    continue;
                }

                bestScore = score;
                hoveredHotspot = hotspot;
            }

            return hoveredHotspot != null;
        }

        private bool IsMappedHotspotAvailable(ScreenHotspot hotspot)
        {
            if (hotspot == null || activeMappedHotspotView == null)
            {
                return false;
            }

            switch (hotspot.hotspotType)
            {
                case ScreenHotspotType.TurnLeft:
                    return HasNavigationTargetForDirection(NavigationDirection.Left);
                case ScreenHotspotType.TurnRight:
                    return HasNavigationTargetForDirection(NavigationDirection.Right);
                case ScreenHotspotType.Back:
                    return HasNavigationTargetForDirection(NavigationDirection.Back);
                case ScreenHotspotType.Exit:
                {
                    var legacyHotspot = ResolveMappedHotspotData(hotspot);
                    if (legacyHotspot != null)
                    {
                        return !string.IsNullOrWhiteSpace(legacyHotspot.targetViewId);
                    }

                    return !string.IsNullOrWhiteSpace(hotspot.targetViewId);
                }
                default:
                    return true;
            }
        }

        private void HandleMappedHotspotClicked(ScreenHotspot hotspot)
        {
            if (hotspot == null)
            {
                return;
            }

            switch (hotspot.hotspotType)
            {
                case ScreenHotspotType.TurnLeft:
                    if (HasNavigationTargetForDirection(NavigationDirection.Left))
                    {
                        activeMappedNavigationCallback?.Invoke(NavigationDirection.Left);
                    }

                    return;

                case ScreenHotspotType.TurnRight:
                    if (HasNavigationTargetForDirection(NavigationDirection.Right))
                    {
                        activeMappedNavigationCallback?.Invoke(NavigationDirection.Right);
                    }

                    return;

                case ScreenHotspotType.Back:
                    if (HasNavigationTargetForDirection(NavigationDirection.Back))
                    {
                        activeMappedNavigationCallback?.Invoke(NavigationDirection.Back);
                    }

                    return;
            }

            var resolvedHotspotData = ResolveMappedHotspotData(hotspot) ?? BuildSyntheticHotspotData(hotspot);
            if (resolvedHotspotData != null)
            {
                activeMappedHotspotCallback?.Invoke(resolvedHotspotData);
            }
        }

        private HotspotData ResolveMappedHotspotData(ScreenHotspot hotspot)
        {
            if (activeMappedHotspotView == null || activeMappedHotspotView.hotspots == null || hotspot == null)
            {
                return null;
            }

            var lookupId = string.IsNullOrWhiteSpace(hotspot.legacyHotspotId)
                ? hotspot.id
                : hotspot.legacyHotspotId;

            foreach (var viewHotspot in activeMappedHotspotView.hotspots)
            {
                if (viewHotspot != null && string.Equals(viewHotspot.id, lookupId, StringComparison.Ordinal))
                {
                    return viewHotspot;
                }
            }

            return null;
        }

        private static HotspotData BuildSyntheticHotspotData(ScreenHotspot hotspot)
        {
            if (hotspot == null)
            {
                return null;
            }

            var actionType = hotspot.hotspotType == ScreenHotspotType.Listen
                ? "Listen"
                : (hotspot.hotspotType == ScreenHotspotType.Exit ? "Exit" : "Look");

            if (string.IsNullOrWhiteSpace(hotspot.responseText) &&
                (hotspot.hotspotType != ScreenHotspotType.Exit || string.IsNullOrWhiteSpace(hotspot.targetViewId)))
            {
                return null;
            }

            return new HotspotData
            {
                id = hotspot.id,
                label = hotspot.label,
                actionType = actionType,
                responseText = hotspot.responseText,
                targetViewId = hotspot.targetViewId
            };
        }

        private bool HasNavigationTargetForDirection(NavigationDirection direction)
        {
            if (activeMappedHotspotView == null)
            {
                return false;
            }

            var navigation = activeMappedHotspotView.navigation;
            if (navigation == null)
            {
                return false;
            }

            switch (direction)
            {
                case NavigationDirection.Left:
                    return !string.IsNullOrWhiteSpace(navigation.left);
                case NavigationDirection.Right:
                    return !string.IsNullOrWhiteSpace(navigation.right);
                case NavigationDirection.Back:
                    return !string.IsNullOrWhiteSpace(navigation.back);
                case NavigationDirection.Forward:
                    return !string.IsNullOrWhiteSpace(navigation.forward);
                default:
                    return false;
            }
        }

        private string GetMappedHotspotHoverText(ScreenHotspot hotspot)
        {
            if (hotspot == null)
            {
                return string.Empty;
            }

            switch (hotspot.hotspotType)
            {
                case ScreenHotspotType.TurnLeft:
                    return "Turn Left";
                case ScreenHotspotType.TurnRight:
                    return "Turn Right";
                case ScreenHotspotType.Back:
                    return "Back";
                case ScreenHotspotType.Exit:
                    return string.IsNullOrWhiteSpace(hotspot.label) ? "Exit" : "Exit: " + hotspot.label;
                case ScreenHotspotType.Listen:
                    return string.IsNullOrWhiteSpace(hotspot.label) ? "Listen" : "Listen: " + hotspot.label;
                default:
                    return string.IsNullOrWhiteSpace(hotspot.label) ? "Look" : "Look: " + hotspot.label;
            }
        }

        private void UpdateMappedHotspotHoverLabel(ScreenHotspot hotspot)
        {
            if (!EnsureMappedHotspotHoverLabel())
            {
                return;
            }

            var hoverText = GetMappedHotspotHoverText(hotspot);
            mappedCursorState = GetCursorStateForMappedHotspot(hotspot);
            mappedHotspotHoverLabel.text = hoverText;
            mappedHotspotHoverLabel.gameObject.SetActive(!string.IsNullOrWhiteSpace(hoverText));
            mappedHotspotHoverLabel.transform.SetAsLastSibling();
        }

        private void ClearMappedHotspotHoverLabel()
        {
            mappedCursorState = MappedCursorState.Default;

            if (mappedHotspotHoverLabel != null)
            {
                mappedHotspotHoverLabel.text = string.Empty;
                mappedHotspotHoverLabel.gameObject.SetActive(false);
            }
        }

        private static MappedCursorState GetCursorStateForMappedHotspot(ScreenHotspot hotspot)
        {
            if (hotspot == null)
            {
                return MappedCursorState.Default;
            }

            switch (hotspot.hotspotType)
            {
                case ScreenHotspotType.Listen:
                    return MappedCursorState.Listen;
                case ScreenHotspotType.Exit:
                    return MappedCursorState.Exit;
                case ScreenHotspotType.TurnLeft:
                    return MappedCursorState.TurnLeft;
                case ScreenHotspotType.TurnRight:
                    return MappedCursorState.TurnRight;
                case ScreenHotspotType.Back:
                    return MappedCursorState.Back;
                default:
                    return MappedCursorState.Look;
            }
        }

        private bool EnsureMappedHotspotHoverLabel()
        {
            if (mappedHotspotHoverLabel != null)
            {
                return true;
            }

            if (backgroundPanel == null)
            {
                return false;
            }

            var labelObject = new GameObject("MappedHotspotHoverLabel", typeof(RectTransform), typeof(TextMeshProUGUI));
            labelObject.transform.SetParent(backgroundPanel.transform, false);

            var labelRect = labelObject.GetComponent<RectTransform>();
            labelRect.anchorMin = new Vector2(0.5f, 0f);
            labelRect.anchorMax = new Vector2(0.5f, 0f);
            labelRect.pivot = new Vector2(0.5f, 0f);
            labelRect.anchoredPosition = new Vector2(0f, 12f);
            labelRect.sizeDelta = new Vector2(680f, 40f);

            mappedHotspotHoverLabel = labelObject.GetComponent<TextMeshProUGUI>();
            mappedHotspotHoverLabel.alignment = TextAlignmentOptions.Center;
            mappedHotspotHoverLabel.fontSize = 24f;
            mappedHotspotHoverLabel.color = new Color(0.95f, 0.93f, 0.86f, 0.96f);
            mappedHotspotHoverLabel.enableWordWrapping = false;
            mappedHotspotHoverLabel.raycastTarget = false;
            mappedHotspotHoverLabel.text = string.Empty;
            mappedHotspotHoverLabel.gameObject.SetActive(false);

            return true;
        }

        private void RefreshLegacyButtonVisibility()
        {
            if (cutscenePanelRoot != null && cutscenePanelRoot.activeSelf)
            {
                return;
            }

            var shouldShowLegacyButtons = !HasMappedHotspotsForCurrentView() || showLegacyButtonsForDebug;
            SetPanelActive(hotspotPanelRoot != null ? hotspotPanelRoot : (hotspotContainer != null ? hotspotContainer.gameObject : null), shouldShowLegacyButtons);
            SetPanelActive(navigationPanelRoot != null ? navigationPanelRoot : GetNavigationPanelFallback(), shouldShowLegacyButtons);
        }

        private bool EnsureMappedHotspotDebugRoot()
        {
            if (mappedHotspotDebugRoot != null)
            {
                return true;
            }

            if (backgroundPanel == null)
            {
                return false;
            }

            var debugRootObject = new GameObject("MappedHotspotDebugRoot", typeof(RectTransform));
            mappedHotspotDebugRoot = debugRootObject.GetComponent<RectTransform>();
            mappedHotspotDebugRoot.SetParent(backgroundPanel.transform, false);
            mappedHotspotDebugRoot.anchorMin = Vector2.zero;
            mappedHotspotDebugRoot.anchorMax = Vector2.one;
            mappedHotspotDebugRoot.offsetMin = Vector2.zero;
            mappedHotspotDebugRoot.offsetMax = Vector2.zero;

            return true;
        }

        private void ClearMappedHotspotDebugVisuals()
        {
            foreach (var debugObject in mappedHotspotDebugObjects)
            {
                if (debugObject != null)
                {
                    Destroy(debugObject);
                }
            }

            mappedHotspotDebugObjects.Clear();
        }

        private void RefreshMappedHotspotDebugVisuals()
        {
            if (!showMappedHotspotDebug || !HasMappedHotspotsForCurrentView())
            {
                ClearMappedHotspotDebugVisuals();

                if (mappedHotspotDebugRoot != null)
                {
                    mappedHotspotDebugRoot.gameObject.SetActive(false);
                }

                return;
            }

            if (!EnsureMappedHotspotDebugRoot() || !TryGetDisplayedBackgroundRect(out var displayedRect))
            {
                return;
            }

            mappedHotspotDebugRoot.gameObject.SetActive(true);
            mappedHotspotDebugRoot.transform.SetAsLastSibling();

            ClearMappedHotspotDebugVisuals();

            foreach (var hotspot in activeMappedScreenHotspots)
            {
                if (hotspot == null)
                {
                    continue;
                }

                AddMappedHotspotDebugVisual(hotspot, displayedRect, IsMappedHotspotAvailable(hotspot));
            }
        }

        private void AddMappedHotspotDebugVisual(ScreenHotspot hotspot, Rect displayedRect, bool isAvailable)
        {
            if (mappedHotspotDebugRoot == null)
            {
                return;
            }

            var xMin = displayedRect.xMin + (hotspot.normalizedRect.xMin * displayedRect.width);
            var yMin = displayedRect.yMin + (hotspot.normalizedRect.yMin * displayedRect.height);
            var width = hotspot.normalizedRect.width * displayedRect.width;
            var height = hotspot.normalizedRect.height * displayedRect.height;

            var debugObject = new GameObject("HotspotDebug_" + hotspot.id, typeof(RectTransform), typeof(Image));
            debugObject.transform.SetParent(mappedHotspotDebugRoot, false);

            var debugRect = debugObject.GetComponent<RectTransform>();
            debugRect.anchorMin = new Vector2(0.5f, 0.5f);
            debugRect.anchorMax = new Vector2(0.5f, 0.5f);
            debugRect.pivot = new Vector2(0.5f, 0.5f);
            debugRect.anchoredPosition = new Vector2(xMin + (width * 0.5f), yMin + (height * 0.5f));
            debugRect.sizeDelta = new Vector2(width, height);

            var image = debugObject.GetComponent<Image>();
            var debugColor = GetMappedHotspotDebugColor(hotspot.hotspotType);
            if (!isAvailable)
            {
                debugColor = new Color(debugColor.r, debugColor.g, debugColor.b, 0.08f);
            }

            image.color = debugColor;
            image.raycastTarget = false;

            var labelObject = new GameObject("Label", typeof(RectTransform), typeof(TextMeshProUGUI));
            labelObject.transform.SetParent(debugObject.transform, false);

            var labelRect = labelObject.GetComponent<RectTransform>();
            labelRect.anchorMin = new Vector2(0f, 1f);
            labelRect.anchorMax = new Vector2(1f, 1f);
            labelRect.pivot = new Vector2(0.5f, 0f);
            labelRect.anchoredPosition = new Vector2(0f, 2f);
            labelRect.sizeDelta = new Vector2(0f, 18f);

            var labelText = labelObject.GetComponent<TextMeshProUGUI>();
            labelText.fontSize = 13f;
            labelText.alignment = TextAlignmentOptions.Center;
            labelText.enableWordWrapping = false;
            labelText.raycastTarget = false;
            labelText.color = new Color(0.96f, 0.96f, 0.96f, 0.96f);
            labelText.text = hotspot.id;

            mappedHotspotDebugObjects.Add(debugObject);
        }

        private static Color GetMappedHotspotDebugColor(ScreenHotspotType hotspotType)
        {
            switch (hotspotType)
            {
                case ScreenHotspotType.Exit:
                    return new Color(0.88f, 0.21f, 0.16f, 0.24f);
                case ScreenHotspotType.Listen:
                    return new Color(0.22f, 0.71f, 0.95f, 0.24f);
                case ScreenHotspotType.Back:
                    return new Color(0.97f, 0.75f, 0.19f, 0.24f);
                case ScreenHotspotType.TurnLeft:
                case ScreenHotspotType.TurnRight:
                    return new Color(0.24f, 0.87f, 0.49f, 0.20f);
                default:
                    return new Color(0.94f, 0.87f, 0.20f, 0.24f);
            }
        }

        private bool TryGetPointerPositionInBackground(out Vector2 normalizedPosition)
        {
            normalizedPosition = Vector2.zero;

            if (backgroundPanel == null)
            {
                return false;
            }

            if (!TryGetDisplayedBackgroundRect(out var displayedRect))
            {
                return false;
            }

            var canvas = backgroundPanel.canvas;
            Camera eventCamera = null;
            if (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                eventCamera = canvas.worldCamera;
            }

            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    backgroundPanel.rectTransform,
                    Input.mousePosition,
                    eventCamera,
                    out var localPoint))
            {
                return false;
            }

            if (!displayedRect.Contains(localPoint))
            {
                return false;
            }

            normalizedPosition.x = Mathf.InverseLerp(displayedRect.xMin, displayedRect.xMax, localPoint.x);
            normalizedPosition.y = Mathf.InverseLerp(displayedRect.yMin, displayedRect.yMax, localPoint.y);
            return true;
        }

        private bool TryGetDisplayedBackgroundRect(out Rect displayedRect)
        {
            displayedRect = default;

            if (backgroundPanel == null)
            {
                return false;
            }

            var panelRect = backgroundPanel.rectTransform.rect;
            if (panelRect.width <= 0f || panelRect.height <= 0f)
            {
                return false;
            }

            displayedRect = panelRect;

            if (!preserveBackgroundSpriteAspect || backgroundPanel.overrideSprite == null)
            {
                return true;
            }

            var spriteRect = backgroundPanel.overrideSprite.rect;
            if (spriteRect.width <= 0f || spriteRect.height <= 0f)
            {
                return true;
            }

            var panelAspect = panelRect.width / panelRect.height;
            var spriteAspect = spriteRect.width / spriteRect.height;

            if (spriteAspect > panelAspect)
            {
                var fittedHeight = panelRect.width / spriteAspect;
                var yOffset = (panelRect.height - fittedHeight) * 0.5f;
                displayedRect = new Rect(panelRect.xMin, panelRect.yMin + yOffset, panelRect.width, fittedHeight);
                return true;
            }

            var fittedWidth = panelRect.height * spriteAspect;
            var xOffset = (panelRect.width - fittedWidth) * 0.5f;
            displayedRect = new Rect(panelRect.xMin + xOffset, panelRect.yMin, fittedWidth, panelRect.height);
            return true;
        }

        private static Dictionary<string, List<ScreenHotspot>> CreateScene1Node1MappedHotspotMap()
        {
            return new Dictionary<string, List<ScreenHotspot>>(StringComparer.Ordinal)
            {
                ["1N"] = CreateNode1NorthMappedHotspots(),
                ["1E"] = CreateNode1EastMappedHotspots(),
                ["1S"] = CreateNode1SouthMappedHotspots(),
                ["1W"] = CreateNode1WestMappedHotspots(),
                ["1A-S"] = CreateNode1ASouthMappedHotspots(),
                ["1A-N"] = CreateNode1ANorthMappedHotspots(),
                ["1A-W"] = CreateNode1AWestMappedHotspots(),
                ["2N"] = CreateNode2NorthMappedHotspots(),
                ["2E"] = CreateNode2EastMappedHotspots(),
                ["2S"] = CreateNode2SouthMappedHotspots(),
                ["2W"] = CreateNode2WestMappedHotspots(),
                ["3E"] = CreateNode3EastMappedHotspots(),
                ["3N"] = CreateNode3NorthMappedHotspots(),
                ["3S"] = CreateNode3SouthMappedHotspots(),
                ["3W"] = CreateNode3WestMappedHotspots()
            };
        }

        private static List<ScreenHotspot> CreateNode1NorthMappedHotspots()
        {
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1N_MED_01", "Bandages & Medicine", ScreenHotspotType.Look, 0.08f, 0.26f, 0.14f, 0.18f, "1N_MED_01"),
                CreateMappedHotspot("1N_BIB_01", "Bible / Cross", ScreenHotspotType.Look, 0.26f, 0.32f, 0.10f, 0.12f, "1N_BIB_01"),
                CreateMappedHotspot("1N_WAT_01", "Water Pitcher", ScreenHotspotType.Look, 0.21f, 0.24f, 0.12f, 0.14f, "1N_WAT_01"),
                CreateMappedHotspot("1N_QUILT_01", "Threadbare Quilt", ScreenHotspotType.Look, 0.55f, 0.17f, 0.31f, 0.28f, "1N_QUILT_01"),
                CreateMappedHotspot("1N_JAMES_01", "James Resting", ScreenHotspotType.Look, 0.62f, 0.24f, 0.22f, 0.16f, "1N_QUILT_01")
            };

            AddNode1RotationAndBackZones(hotspots, "1N");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1EastMappedHotspots()
        {
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1E_SHAWL_01", "Shawl", ScreenHotspotType.Look, 0.16f, 0.44f, 0.16f, 0.27f, "1E_SHAWL_01"),
                CreateMappedHotspot("1E_MEND_01", "Mending Kit", ScreenHotspotType.Look, 0.52f, 0.18f, 0.30f, 0.20f, "1E_MEND_01"),
                CreateMappedHotspot("1E_SHEET_01", "Folded Sheet", ScreenHotspotType.Look, 0.65f, 0.38f, 0.15f, 0.14f, "1E_SHEET_01"),
                CreateMappedHotspot("1E_COMB_01", "Broken Comb", ScreenHotspotType.Look, 0.70f, 0.22f, 0.11f, 0.10f, "1E_COMB_01"),
                CreateMappedHotspot("1E_WARDROBE_01", "Wardrobe", ScreenHotspotType.Look, 0.08f, 0.20f, 0.26f, 0.62f)
            };

            AddNode1RotationAndBackZones(hotspots, "1E");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1SouthMappedHotspots()
        {
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1W_DRAW_01", "Children's Drawings", ScreenHotspotType.Look, 0.12f, 0.48f, 0.24f, 0.30f, "1W_DRAW_01"),
                CreateMappedHotspot("1W_BOX_01", "Keepsake Box", ScreenHotspotType.Look, 0.50f, 0.19f, 0.22f, 0.16f, "1W_BOX_01"),
                CreateMappedHotspot("1W_DOLL_01", "Rag Doll", ScreenHotspotType.Look, 0.74f, 0.16f, 0.11f, 0.24f, "1W_DOLL_01"),
                CreateMappedHotspot("1X_CANDLE_01", "Candle Ends", ScreenHotspotType.Look, 0.34f, 0.22f, 0.12f, 0.14f, "1X_CANDLE_01"),
                CreateMappedHotspot("1X_TEA_01", "Tea Tin", ScreenHotspotType.Look, 0.42f, 0.22f, 0.14f, 0.12f, "1X_TEA_01"),
                CreateMappedHotspot("1W_SOLES_01", "Worn Shoes", ScreenHotspotType.Look, 0.13f, 0.08f, 0.18f, 0.10f, "1W_SOLES_01"),
                CreateMappedHotspot("1S_DESK_01", "Small Desk", ScreenHotspotType.Look, 0.57f, 0.30f, 0.24f, 0.16f)
            };

            AddNode1RotationAndBackZones(hotspots, "1S");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1WestMappedHotspots()
        {
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot(
                    "1W_EXIT_01",
                    "Bedroom Doorway",
                    ScreenHotspotType.Exit,
                    0.40f,
                    0.12f,
                    0.22f,
                    0.62f,
                    "1S_EXIT_01",
                    FirstRoomData.Node1ATopOfStairsViewId,
                    "The landing lies ahead. I need to move quietly."),
                CreateMappedHotspot(
                    "1W_LISTEN_01",
                    "Doorframe Listen",
                    ScreenHotspotType.Listen,
                    0.30f,
                    0.12f,
                    0.09f,
                    0.62f,
                    "1S_LISTEN_01",
                    null,
                    null,
                    430),
                CreateMappedHotspot("1W_SHOES_01", "Children's Shoes", ScreenHotspotType.Look, 0.27f, 0.09f, 0.11f, 0.09f, "1S_SHOES_01"),
                CreateMappedHotspot("1W_POSY_01", "Dried Posy", ScreenHotspotType.Look, 0.64f, 0.10f, 0.10f, 0.12f, "1S_POSY_01")
            };

            AddNode1RotationAndBackZones(hotspots, "1W");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1ASouthMappedHotspots()
        {
            // 1A-S continuity anchor:
            // This view must read as just outside 1W, facing south toward the stairwell.
            // Rectangles below are tuned to current imported art and should be re-tuned if composition changes.
            // Art guardrail: do not imply a large hallway, modern staircase, or extra bedroom.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1A_S_STAIR_01", "Stairwell Shadows", ScreenHotspotType.Look, 0.42f, 0.19f, 0.40f, 0.57f, "1A_S_STAIR_01"),
                CreateMappedHotspot("1A_S_CANDLE_01", "Candle Stub", ScreenHotspotType.Look, 0.30f, 0.50f, 0.10f, 0.19f, "1A_S_CANDLE_01"),
                CreateMappedHotspot("1A_S_SEW_01", "Sewing Basket", ScreenHotspotType.Look, 0.14f, 0.09f, 0.22f, 0.22f, "1A_S_SEW_01"),
                CreateMappedHotspot("1A_S_RUM_01", "Rum Smell", ScreenHotspotType.Listen, 0.58f, 0.17f, 0.22f, 0.31f, "1A_S_RUM_01"),
                CreateMappedHotspot(
                    "1A_S_EXIT_01",
                    "Exit Downstairs",
                    ScreenHotspotType.Exit,
                    0.39f,
                    0.08f,
                    0.48f,
                    0.76f,
                    "1A_S_EXIT_01",
                    FirstRoomData.Node3FrontHallEntryViewId)
            };

            AddNode1RotationAndBackZones(hotspots, "1A-S");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1ANorthMappedHotspots()
        {
            // 1A-N reverse view:
            // This should feel like a turn-around on the same landing, facing north toward children's rooms.
            // Rectangles below are tuned to current imported art and should be re-tuned if composition changes.
            // Art guardrail: do not imply a large hallway, modern staircase, or extra bedroom.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1A_N_KIDS_01", "Children's Door", ScreenHotspotType.Look, 0.27f, 0.28f, 0.47f, 0.48f, "1A_N_KIDS_01"),
                CreateMappedHotspot("1A_N_TOY_01", "Toy", ScreenHotspotType.Look, 0.53f, 0.25f, 0.09f, 0.12f, "1A_N_TOY_01"),
                CreateMappedHotspot("1A_N_FLOOR_01", "Floorboard", ScreenHotspotType.Listen, 0.42f, 0.14f, 0.23f, 0.11f, "1A_N_FLOOR_01")
            };

            AddNode1RotationAndBackZones(hotspots, "1A-N");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode1AWestMappedHotspots()
        {
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("1A_WALL_01", "Wall Plaster", ScreenHotspotType.Look, 0.20f, 0.15f, 0.55f, 0.55f, "1A_WALL_01"),
                CreateMappedHotspot("1A_WALL_LIGHT_01", "Lantern Spill", ScreenHotspotType.Look, 0.05f, 0.30f, 0.25f, 0.35f, "1A_WALL_LIGHT_01")
            };

            AddNode1RotationAndBackZones(hotspots, "1A-W");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode2NorthMappedHotspots()
        {
            // Tuned against final kitchen 2N composition (hearth/chimney dominant, dark doorway at left).
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("2N_HEARTH_01", "Hearth", ScreenHotspotType.Look, 0.41f, 0.23f, 0.36f, 0.58f, "2N_HEARTH_01"),
                CreateMappedHotspot("2N_HEARTH_02", "Hearth Stones", ScreenHotspotType.Look, 0.44f, 0.66f, 0.35f, 0.20f, "2N_HEARTH_02"),
                CreateMappedHotspot("2N_KETTLE_01", "Kettle", ScreenHotspotType.Look, 0.54f, 0.46f, 0.19f, 0.20f, "2N_KETTLE_01"),
                CreateMappedHotspot("2N_CRACK_01", "Chimney Crack", ScreenHotspotType.Listen, 0.80f, 0.24f, 0.05f, 0.38f, FirstRoomData.ChimneyCrackHotspotId, null, null, 620),
                CreateMappedHotspot("2N_CRACK_02", "Chimney Shadow Line", ScreenHotspotType.Listen, 0.78f, 0.25f, 0.03f, 0.33f, "2N_CRACK_02", null, null, 620),
                CreateMappedHotspot("2N_SHADOWS_01", "Parlour Shadows", ScreenHotspotType.Look, 0.08f, 0.18f, 0.24f, 0.54f, "2N_SHADOWS_01")
            };

            AddNode1RotationAndBackZones(hotspots, "2N");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode2EastMappedHotspots()
        {
            // Tuned against final kitchen 2E composition (occupation table foreground, hall door at left).
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("2E_TINS_01", "Mess Tins", ScreenHotspotType.Look, 0.56f, 0.45f, 0.31f, 0.23f, "2E_TINS_01"),
                CreateMappedHotspot("2E_CUP_01", "Tin Cup", ScreenHotspotType.Look, 0.48f, 0.56f, 0.13f, 0.22f, "2E_CUP_01"),
                CreateMappedHotspot("2E_CUP_02", "Cup Ring", ScreenHotspotType.Look, 0.56f, 0.66f, 0.12f, 0.10f, "2E_CUP_02"),
                CreateMappedHotspot("2E_RATION_01", "Ration Slip", ScreenHotspotType.Look, 0.58f, 0.72f, 0.18f, 0.13f, "2E_RATION_01"),
                CreateMappedHotspot("2E_RATION_02", "Folded Ration Stub", ScreenHotspotType.Look, 0.70f, 0.64f, 0.12f, 0.10f, "2E_RATION_02"),
                CreateMappedHotspot("2E_CRUMBS_01", "Crumbs", ScreenHotspotType.Look, 0.49f, 0.57f, 0.36f, 0.24f, "2E_CRUMBS_01"),
                CreateMappedHotspot("2E_HALL_01", "Return to Hall", ScreenHotspotType.Exit, 0.09f, 0.14f, 0.23f, 0.67f, "2E_HALL_01", FirstRoomData.Node3FrontHallEntryViewId)
            };

            AddNode1RotationAndBackZones(hotspots, "2E");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode2SouthMappedHotspots()
        {
            // Tuned against final kitchen 2S composition (center doorway with sideboard/shelves on the right).
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("2S_SIDEBOARD_01", "Sideboard", ScreenHotspotType.Look, 0.70f, 0.32f, 0.28f, 0.30f, "2S_SIDEBOARD_01"),
                CreateMappedHotspot("2S_SHELVES_01", "Shelves", ScreenHotspotType.Look, 0.69f, 0.08f, 0.29f, 0.24f, "2S_SHELVES_01"),
                CreateMappedHotspot("2S_DOORWAY_01", "Doorway Edge", ScreenHotspotType.Look, 0.34f, 0.12f, 0.32f, 0.60f, "2S_DOORWAY_01")
            };

            AddNode1RotationAndBackZones(hotspots, "2S");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode2WestMappedHotspots()
        {
            // Tuned against final kitchen 2W composition (open back door and hazardous exterior).
            // Back door remains blocked in Act I: this is an Exit hotspot with no target.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("2W_DOOR_01", "Back Door", ScreenHotspotType.Exit, 0.09f, 0.11f, 0.19f, 0.78f, "2W_DOOR_01", null, null, 480),
                CreateMappedHotspot("2W_FOG_01", "Fogged Window", ScreenHotspotType.Look, 0.25f, 0.16f, 0.22f, 0.58f, "2W_FOG_01"),
                CreateMappedHotspot("2W_YARD_01", "Yard Sounds", ScreenHotspotType.Listen, 0.28f, 0.30f, 0.23f, 0.44f, "2W_YARD_01"),
                CreateMappedHotspot("2W_SOLDIERS_01", "Distant Soldiers", ScreenHotspotType.Listen, 0.35f, 0.12f, 0.21f, 0.20f, "2W_SOLDIERS_01")
            };

            AddNode1RotationAndBackZones(hotspots, "2W");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode3EastMappedHotspots()
        {
            // Placeholder rectangles for front hall 3E until final Node 3 art is imported.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("3E_COAT_01", "Officer's Coat", ScreenHotspotType.Look, 0.14f, 0.28f, 0.17f, 0.45f, "3E_COAT_01"),
                CreateMappedHotspot("3E_SACK_01", "Haversack", ScreenHotspotType.Look, 0.33f, 0.34f, 0.14f, 0.24f, "3E_SACK_01"),
                CreateMappedHotspot("3E_WINDOW_01", "Window Smudges", ScreenHotspotType.Look, 0.60f, 0.33f, 0.24f, 0.30f, "3E_WINDOW_01"),
                CreateMappedHotspot("3E_TABLE_01", "Table with Rations", ScreenHotspotType.Look, 0.45f, 0.13f, 0.33f, 0.18f, "3E_TABLE_01"),
                CreateMappedHotspot("3E_EXIT_01", "Kitchen Exit", ScreenHotspotType.Exit, 0.04f, 0.18f, 0.14f, 0.62f, "3E_EXIT_01", FirstRoomData.Node2KitchenEntryViewId)
            };

            AddNode1RotationAndBackZones(hotspots, "3E");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode3NorthMappedHotspots()
        {
            // Placeholder rectangles for front hall 3N until final Node 3 art is imported.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("3N_STAIR_01", "Stair Shadow", ScreenHotspotType.Look, 0.30f, 0.14f, 0.38f, 0.58f, "3N_STAIR_01"),
                CreateMappedHotspot("3N_CREAK_01", "Wall / Floor Creak", ScreenHotspotType.Listen, 0.56f, 0.12f, 0.24f, 0.18f, "3N_CREAK_01")
            };

            AddNode1RotationAndBackZones(hotspots, "3N");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode3SouthMappedHotspots()
        {
            // Placeholder rectangles for front hall 3S until final Node 3 art is imported.
            // This view should suggest danger and voices only; eavesdrop remains gated by chimney crack flow.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("3S_PARLOUR_01", "Parlour Side", ScreenHotspotType.Listen, 0.24f, 0.24f, 0.28f, 0.50f, "3S_PARLOUR_01"),
                CreateMappedHotspot("3S_VOICES_01", "Door Crack / Low Voices", ScreenHotspotType.Listen, 0.56f, 0.29f, 0.26f, 0.33f, "3S_VOICES_01")
            };

            AddNode1RotationAndBackZones(hotspots, "3S");
            return hotspots;
        }

        private static List<ScreenHotspot> CreateNode3WestMappedHotspots()
        {
            // Placeholder rectangles for front hall 3W until final Node 3 art is imported.
            var hotspots = new List<ScreenHotspot>
            {
                CreateMappedHotspot("3W_KITCHEN_01", "Kitchen Passage", ScreenHotspotType.Look, 0.28f, 0.22f, 0.30f, 0.48f, "3W_KITCHEN_01"),
                CreateMappedHotspot("3W_FLOOR_01", "Floorboards", ScreenHotspotType.Look, 0.40f, 0.08f, 0.26f, 0.16f, "3W_FLOOR_01"),
                CreateMappedHotspot("3W_EXIT_01", "Kitchen Exit", ScreenHotspotType.Exit, 0.06f, 0.16f, 0.14f, 0.60f, "3W_EXIT_01", FirstRoomData.Node2KitchenEntryViewId),
                // Provide a visible mapped path back upstairs while Node 3 uses placeholder art.
                CreateMappedHotspot("3W_STAIRS_UP_01", "Stairs Up", ScreenHotspotType.Exit, 0.78f, 0.12f, 0.16f, 0.66f, null, FirstRoomData.Node1ATopOfStairsViewId)
            };

            AddNode1RotationAndBackZones(hotspots, "3W");
            return hotspots;
        }

        private static void AddNode1RotationAndBackZones(List<ScreenHotspot> hotspots, string viewPrefix)
        {
            hotspots.Add(CreateMappedHotspot(viewPrefix + "_TURN_LEFT", "Turn Left", ScreenHotspotType.TurnLeft, 0.00f, 0.12f, 0.08f, 0.76f));
            hotspots.Add(CreateMappedHotspot(viewPrefix + "_TURN_RIGHT", "Turn Right", ScreenHotspotType.TurnRight, 0.92f, 0.12f, 0.08f, 0.76f));
            hotspots.Add(CreateMappedHotspot(viewPrefix + "_BACK", "Step Back", ScreenHotspotType.Back, 0.24f, 0.08f, 0.52f, 0.14f));
        }

        private static ScreenHotspot CreateMappedHotspot(
            string id,
            string label,
            ScreenHotspotType hotspotType,
            float x,
            float y,
            float width,
            float height,
            string legacyHotspotId = null,
            string targetViewId = null,
            string responseText = null,
            int priority = 0)
        {
            return new ScreenHotspot
            {
                id = id,
                label = label,
                hotspotType = hotspotType,
                normalizedRect = new Rect(x, y, width, height),
                legacyHotspotId = legacyHotspotId,
                targetViewId = targetViewId,
                responseText = responseText,
                priority = priority > 0 ? priority : GetDefaultMappedHotspotPriority(hotspotType)
            };
        }

        private static int GetDefaultMappedHotspotPriority(ScreenHotspotType hotspotType)
        {
            switch (hotspotType)
            {
                case ScreenHotspotType.Look:
                case ScreenHotspotType.Listen:
                    return 500;
                case ScreenHotspotType.Exit:
                    return 450;
                case ScreenHotspotType.Back:
                    return 300;
                case ScreenHotspotType.TurnLeft:
                case ScreenHotspotType.TurnRight:
                    return 200;
                default:
                    return 100;
            }
        }

        private void BuildHotspotButtons(List<HotspotData> hotspots, Action<HotspotData> onHotspotClicked)
        {
            ClearHotspotButtons();

            if (hotspotContainer == null || hotspotButtonPrefab == null || hotspots == null)
            {
                return;
            }

            foreach (var hotspot in hotspots)
            {
                var buttonInstance = Instantiate(hotspotButtonPrefab, hotspotContainer);
                buttonInstance.gameObject.SetActive(true);
                buttonInstance.onClick.RemoveAllListeners();

                var capturedHotspot = hotspot;
                buttonInstance.onClick.AddListener(() => onHotspotClicked?.Invoke(capturedHotspot));

                SetButtonLabel(buttonInstance, hotspot.label);
                spawnedHotspotButtons.Add(buttonInstance);
            }
        }

        private static void SetButtonLabel(Button button, string label)
        {
            var legacyText = button.GetComponentInChildren<Text>(true);
            if (legacyText != null)
            {
                legacyText.text = label;
                return;
            }

            var components = button.GetComponentsInChildren<Component>(true);
            foreach (var component in components)
            {
                if (component == null)
                {
                    continue;
                }

                if (!HasWritableTextProperty(component))
                {
                    continue;
                }

                SetText(component, label);
                return;
            }
        }

        private void ConfigureCutsceneButton(string label, Action callback)
        {
            if (cutsceneAdvanceButton != null)
            {
                cutsceneAdvanceButton.gameObject.SetActive(true);
                cutsceneAdvanceButton.interactable = true;
                cutsceneAdvanceButton.onClick.RemoveAllListeners();
                ApplyCutsceneButtonLayout(cutsceneAdvanceButton, false);

                if (callback != null)
                {
                    cutsceneAdvanceButton.onClick.AddListener(() => callback());
                }

                if (cutsceneAdvanceButtonLabelText != null)
                {
                    SetText(cutsceneAdvanceButtonLabelText, label);
                }
                else
                {
                    SetButtonLabel(cutsceneAdvanceButton, label);
                }

                return;
            }

            var button = EnsureFallbackCutsceneButton();
            if (button == null)
            {
                LogMissingCutsceneWiring();
                return;
            }

            button.gameObject.SetActive(true);
            button.interactable = true;
            button.onClick.RemoveAllListeners();
            ApplyCutsceneButtonLayout(button, true);

            if (callback != null)
            {
                button.onClick.AddListener(() => callback());
            }

            SetButtonLabel(button, label);
        }

        private void ShowCutsceneMode()
        {
            DeactivateMappedHotspots();
            LogMissingCutsceneWiring();

            var usingFallbackCutsceneButton = cutsceneAdvanceButton == null && hotspotContainer != null && hotspotButtonPrefab != null;

            SetPanelActive(hotspotPanelRoot != null ? hotspotPanelRoot : (hotspotContainer != null ? hotspotContainer.gameObject : null), usingFallbackCutsceneButton);
            SetPanelActive(navigationPanelRoot != null ? navigationPanelRoot : GetNavigationPanelFallback(), false);
            SetPanelActive(cutscenePanelRoot, true);
            SetPanelActive(compassPanel, false);
            SetPanelActive(historicalTimePanel, false);

            ConfigureNavigationButton(leftButton, string.Empty, NavigationDirection.Left, null);
            ConfigureNavigationButton(rightButton, string.Empty, NavigationDirection.Right, null);
            ConfigureNavigationButton(backButton, string.Empty, NavigationDirection.Back, null);
            ConfigureNavigationButton(forwardButton, string.Empty, NavigationDirection.Forward, null);
        }

        private void ShowNormalMode()
        {
            SetPanelActive(hotspotPanelRoot != null ? hotspotPanelRoot : (hotspotContainer != null ? hotspotContainer.gameObject : null), true);
            SetPanelActive(navigationPanelRoot != null ? navigationPanelRoot : GetNavigationPanelFallback(), true);
            SetPanelActive(cutscenePanelRoot, false);
            HideCutscenePortrait();
            RefreshLegacyButtonVisibility();

            if (cutsceneAdvanceButton != null)
            {
                cutsceneAdvanceButton.onClick.RemoveAllListeners();
            }

            if (fallbackCutsceneButton != null)
            {
                fallbackCutsceneButton.onClick.RemoveAllListeners();
            }
        }

        private void UpdateCutscenePortrait(string portraitKey)
        {
            var portraitImage = EnsureCutscenePortraitImage();
            if (portraitImage == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(portraitKey))
            {
                HideCutscenePortrait();
                return;
            }

            var portraitSprite = ResolveCutscenePortraitSprite(portraitKey);
            if (portraitSprite == null)
            {
                HideCutscenePortrait();
                return;
            }

            portraitImage.sprite = portraitSprite;
            portraitImage.overrideSprite = null;
            portraitImage.preserveAspect = true;
            portraitImage.raycastTarget = false;
            portraitImage.color = Color.white;
            portraitImage.transform.SetAsLastSibling();
            portraitImage.gameObject.SetActive(true);
        }

        private void HideCutscenePortrait()
        {
            if (cutscenePortraitImage == null)
            {
                return;
            }

            cutscenePortraitImage.sprite = null;
            cutscenePortraitImage.overrideSprite = null;
            if (hideCutscenePortraitWhenSpriteMissing)
            {
                cutscenePortraitImage.gameObject.SetActive(false);
            }
        }

        private UnityEngine.UI.Image EnsureCutscenePortraitImage()
        {
            if (cutscenePortraitImage != null)
            {
                var desiredParent = ResolveCutscenePortraitParent();
                if (desiredParent != null && cutscenePortraitImage.transform.parent != desiredParent)
                {
                    cutscenePortraitImage.transform.SetParent(desiredParent, false);
                    var existingRect = cutscenePortraitImage.rectTransform;
                    ConfigureCutscenePortraitRect(existingRect);
                }

                cutscenePortraitImage.transform.SetAsLastSibling();
                return cutscenePortraitImage;
            }

            var portraitParent = ResolveCutscenePortraitParent();
            if (portraitParent == null)
            {
                return null;
            }

            var existingPortrait = portraitParent.Find("CutscenePortraitImage");
            if (existingPortrait != null)
            {
                cutscenePortraitImage = existingPortrait.GetComponent<UnityEngine.UI.Image>();
                if (cutscenePortraitImage != null)
                {
                    return cutscenePortraitImage;
                }
            }

            var portraitObject = new GameObject("CutscenePortraitImage", typeof(RectTransform), typeof(UnityEngine.UI.Image));
            portraitObject.transform.SetParent(portraitParent, false);
            portraitObject.transform.SetAsLastSibling();

            var portraitRect = portraitObject.GetComponent<RectTransform>();
            ConfigureCutscenePortraitRect(portraitRect);

            cutscenePortraitImage = portraitObject.GetComponent<UnityEngine.UI.Image>();
            cutscenePortraitImage.preserveAspect = true;
            cutscenePortraitImage.raycastTarget = false;
            portraitObject.SetActive(false);
            return cutscenePortraitImage;
        }

        private static void ConfigureCutscenePortraitRect(RectTransform portraitRect)
        {
            if (portraitRect == null)
            {
                return;
            }

            // Large portrait block intended to cover a significant portion of cutscene background.
            portraitRect.anchorMin = new Vector2(0.46f, 0.04f);
            portraitRect.anchorMax = new Vector2(0.99f, 0.96f);
            portraitRect.pivot = new Vector2(1f, 0.5f);
            portraitRect.anchoredPosition = Vector2.zero;
            portraitRect.sizeDelta = Vector2.zero;
        }

        private static void ApplyCutsceneButtonLayout(Button button, bool isFallbackButton)
        {
            if (button == null)
            {
                return;
            }

            var buttonRect = button.GetComponent<RectTransform>();
            if (buttonRect != null)
            {
                buttonRect.anchorMin = new Vector2(0.5f, 0.06f);
                buttonRect.anchorMax = new Vector2(0.5f, 0.06f);
                buttonRect.pivot = new Vector2(0.5f, 0.5f);
                buttonRect.anchoredPosition = Vector2.zero;
                buttonRect.sizeDelta = isFallbackButton
                    ? new Vector2(220f, 52f)
                    : new Vector2(240f, 56f);
            }

            var layoutElement = button.GetComponent<LayoutElement>();
            if (layoutElement != null)
            {
                layoutElement.minWidth = 0f;
                layoutElement.minHeight = 0f;
                layoutElement.preferredWidth = isFallbackButton ? 220f : 240f;
                layoutElement.preferredHeight = isFallbackButton ? 52f : 56f;
                layoutElement.flexibleWidth = 0f;
                layoutElement.flexibleHeight = 0f;
            }

            button.transform.SetAsLastSibling();
        }

        private static string ResolveDialoguePortraitKey(DialogueLine line)
        {
            if (line == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(line.portraitKey))
            {
                return line.portraitKey;
            }

            if (string.Equals(line.speaker, "Brownell", StringComparison.OrdinalIgnoreCase))
            {
                return "S01_N03B_P_BROWNELL";
            }

            if (string.Equals(line.speaker, "Parker", StringComparison.OrdinalIgnoreCase))
            {
                return "S01_N03B_P_PARKER";
            }

            if (string.Equals(line.speaker, "Dunbar", StringComparison.OrdinalIgnoreCase))
            {
                return "S01_N03B_P_DUNBAR";
            }

            return null;
        }

        private Sprite ResolveCutscenePortraitSprite(string portraitKey)
        {
            var portraitSprite = ResolveBackgroundSprite(portraitKey);
            if (portraitSprite != null)
            {
                return portraitSprite;
            }

#if UNITY_EDITOR
            switch (portraitKey)
            {
                case "S01_N03B_P_BROWNELL":
                    return UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(
                        "Assets/Game/Art/Backgrounds/Scene01_Node03B_ParlourEavesdrop/Scene01_Node03B_Officer_Senior.png");
                case "S01_N03B_P_PARKER":
                    return UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(
                        "Assets/Game/Art/Backgrounds/Scene01_Node03B_ParlourEavesdrop/Scene01_Node03B_Officer_Standard.png");
                case "S01_N03B_P_DUNBAR":
                    return UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(
                        "Assets/Game/Art/Backgrounds/Scene01_Node03B_ParlourEavesdrop/Scene01_Node03B_Officer_Young.png");
            }
#endif

            return null;
        }

        private Transform ResolveCutscenePortraitParent()
        {
            if (cutscenePanelRoot != null && cutscenePanelRoot.activeInHierarchy)
            {
                return cutscenePanelRoot.transform;
            }

            if (backgroundPanel != null && backgroundPanel.transform.parent != null)
            {
                return backgroundPanel.transform.parent;
            }

            if (backgroundPanel != null)
            {
                return backgroundPanel.transform;
            }

            return transform;
        }

        private void LogMissingCutsceneWiring()
        {
            if (hasLoggedCutsceneWiringWarning)
            {
                return;
            }

            var missing = new List<string>();

            if (cutscenePanelRoot == null)
            {
                missing.Add("Cutscene Panel Root");
            }

            if (cutsceneSpeakerText == null)
            {
                missing.Add("Cutscene Speaker Text");
            }

            if (cutsceneDialogueText == null)
            {
                missing.Add("Cutscene Dialogue Text");
            }

            if (cutsceneAdvanceButton == null)
            {
                missing.Add("Cutscene Advance Button");
            }

            if (missing.Count == 0)
            {
                return;
            }

            hasLoggedCutsceneWiringWarning = true;

            if (cutsceneAdvanceButton == null && hotspotContainer != null && hotspotButtonPrefab != null)
            {
                Debug.Log("UIManager cutscene references missing: " + string.Join(", ", missing.ToArray()) + ". Using hotspot fallback for cutscene controls.");
                return;
            }

            Debug.LogWarning("UIManager cutscene references missing: " + string.Join(", ", missing.ToArray()));
        }

        private Button EnsureFallbackCutsceneButton()
        {
            if (fallbackCutsceneButton != null)
            {
                var desiredParent = ResolveCutsceneButtonParent();
                if (desiredParent != null && fallbackCutsceneButton.transform.parent != desiredParent)
                {
                    fallbackCutsceneButton.transform.SetParent(desiredParent, false);
                }

                return fallbackCutsceneButton;
            }

            if (hotspotButtonPrefab == null)
            {
                return null;
            }

            var buttonParent = ResolveCutsceneButtonParent();
            if (buttonParent == null)
            {
                return null;
            }

            fallbackCutsceneButton = Instantiate(hotspotButtonPrefab, buttonParent);
            fallbackCutsceneButton.gameObject.name = "CutsceneAdvanceButton_Fallback";
            fallbackCutsceneButton.gameObject.SetActive(true);
            fallbackCutsceneButton.transform.SetAsLastSibling();
            spawnedHotspotButtons.Add(fallbackCutsceneButton);
            return fallbackCutsceneButton;
        }

        private Transform ResolveCutsceneButtonParent()
        {
            if (cutscenePanelRoot != null && cutscenePanelRoot.activeInHierarchy)
            {
                return cutscenePanelRoot.transform;
            }

            if (backgroundPanel != null && backgroundPanel.transform.parent != null)
            {
                return backgroundPanel.transform.parent;
            }

            if (backgroundPanel != null)
            {
                return backgroundPanel.transform;
            }

            if (hotspotContainer != null)
            {
                return hotspotContainer;
            }

            return transform;
        }

        private GameObject GetNavigationPanelFallback()
        {
            if (leftButton != null && leftButton.transform.parent != null)
            {
                return leftButton.transform.parent.gameObject;
            }

            if (rightButton != null && rightButton.transform.parent != null)
            {
                return rightButton.transform.parent.gameObject;
            }

            if (backButton != null && backButton.transform.parent != null)
            {
                return backButton.transform.parent.gameObject;
            }

            if (forwardButton != null && forwardButton.transform.parent != null)
            {
                return forwardButton.transform.parent.gameObject;
            }

            return null;
        }

        private static void SetPanelActive(GameObject panel, bool isActive)
        {
            if (panel != null)
            {
                panel.SetActive(isActive);
            }
        }

        private static void SetComponentActive(Component component, bool isActive)
        {
            if (component != null)
            {
                component.gameObject.SetActive(isActive);
            }
        }

        private static bool HasWritableTextProperty(Component component)
        {
            var type = component.GetType();
            var textProperty = type.GetProperty("text");
            return textProperty != null && textProperty.CanWrite && textProperty.PropertyType == typeof(string);
        }

        private static void SetText(Component textComponent, string value)
        {
            if (textComponent == null)
            {
                return;
            }

            var legacyText = textComponent as Text;
            if (legacyText != null)
            {
                legacyText.text = value ?? string.Empty;
                return;
            }

            var type = textComponent.GetType();
            var textProperty = type.GetProperty("text");
            if (textProperty != null && textProperty.CanWrite && textProperty.PropertyType == typeof(string))
            {
                textProperty.SetValue(textComponent, value ?? string.Empty, null);
            }
        }

        private void ConfigureNavigation(NavigationTargets navigation, Action<NavigationDirection> onNavigate)
        {
            ConfigureNavigationButton(leftButton, navigation?.left, NavigationDirection.Left, onNavigate);
            ConfigureNavigationButton(rightButton, navigation?.right, NavigationDirection.Right, onNavigate);
            ConfigureNavigationButton(backButton, navigation?.back, NavigationDirection.Back, onNavigate);
            ConfigureNavigationButton(forwardButton, navigation?.forward, NavigationDirection.Forward, onNavigate);
        }

        private static void ConfigureNavigationButton(
            Button button,
            string target,
            NavigationDirection direction,
            Action<NavigationDirection> onNavigate)
        {
            if (button == null)
            {
                return;
            }

            button.onClick.RemoveAllListeners();

            var hasTarget = !string.IsNullOrWhiteSpace(target);
            button.interactable = hasTarget;

            if (hasTarget)
            {
                button.onClick.AddListener(() => onNavigate?.Invoke(direction));
            }
        }

        private void ClearHotspotButtons()
        {
            foreach (var hotspotButton in spawnedHotspotButtons)
            {
                if (hotspotButton != null)
                {
                    Destroy(hotspotButton.gameObject);
                }
            }

            spawnedHotspotButtons.Clear();
            fallbackCutsceneButton = null;
        }

        private void OnDisable()
        {
            ClearHotspotButtons();
            DeactivateMappedHotspots();
            HideScene1Node1CompositionOverlay();
            SetLightingMoodOverlayActive(false);

            if (cutsceneAdvanceButton != null)
            {
                cutsceneAdvanceButton.onClick.RemoveAllListeners();
            }
        }
    }
}
