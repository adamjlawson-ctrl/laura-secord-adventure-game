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
        [SerializeField] private Image backgroundPanel;
        [SerializeField] private Component backgroundLabelText;

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

        private readonly List<Button> spawnedHotspotButtons = new List<Button>();
        private Button fallbackCutsceneButton;
        private bool hasLoggedCutsceneWiringWarning;

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
            if (backgroundLabelText != null)
            {
                SetText(backgroundLabelText, viewData.backgroundKey);
            }

            if (backgroundPanel == null)
            {
                return;
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

            if (callback != null)
            {
                button.onClick.AddListener(() => callback());
            }

            SetButtonLabel(button, label);
        }

        private void ShowCutsceneMode()
        {
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

            if (cutsceneAdvanceButton != null)
            {
                cutsceneAdvanceButton.onClick.RemoveAllListeners();
            }

            if (fallbackCutsceneButton != null)
            {
                fallbackCutsceneButton.onClick.RemoveAllListeners();
            }
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
                return fallbackCutsceneButton;
            }

            if (hotspotContainer == null || hotspotButtonPrefab == null)
            {
                return null;
            }

            fallbackCutsceneButton = Instantiate(hotspotButtonPrefab, hotspotContainer);
            fallbackCutsceneButton.gameObject.name = "CutsceneAdvanceButton_Fallback";
            fallbackCutsceneButton.gameObject.SetActive(true);
            spawnedHotspotButtons.Add(fallbackCutsceneButton);
            return fallbackCutsceneButton;
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

            if (cutsceneAdvanceButton != null)
            {
                cutsceneAdvanceButton.onClick.RemoveAllListeners();
            }
        }
    }
}
