using QueenstonWarning.NodeSystem.Data;
using QueenstonWarning.NodeSystem.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QueenstonWarning.NodeSystem.UI
{
    public sealed class NodePrototypeUI : MonoBehaviour
    {
        private NodeNavigator _navigator;
        private CsvLoadResult _route;

        private Image _placeholderVisual;
        private Text _placeholderTitle;
        private Text _placeholderSubtitle;
        private Text _infoText;
        private Text _debugText;

        private Button _turnLeftButton;
        private Button _turnRightButton;
        private Button _turnBackButton;
        private Button _forwardButton;
        private Text _forwardButtonText;

        private bool _uiBuilt;

        public void Initialize(NodeNavigator navigator, CsvLoadResult route)
        {
            if (!_uiBuilt)
            {
                BuildUi();
            }

            if (_navigator != null)
            {
                _navigator.StateChanged -= Render;
            }

            _navigator = navigator;
            _route = route;

            if (_navigator != null)
            {
                _navigator.StateChanged += Render;
            }

            Render();
        }

        private void OnDestroy()
        {
            if (_navigator != null)
            {
                _navigator.StateChanged -= Render;
            }
        }

        private void BuildUi()
        {
            EnsureEventSystem();

            var canvasObject = new GameObject("PrototypeCanvas", typeof(RectTransform));
            canvasObject.transform.SetParent(transform, false);

            var canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<GraphicRaycaster>();

            var scaler = canvasObject.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            scaler.matchWidthOrHeight = 0.5f;

            var root = CreateUiObject("Root", canvasObject.transform);
            Stretch(root.GetComponent<RectTransform>(), 10f);

            var rootImage = root.AddComponent<Image>();
            rootImage.color = new Color(0.95f, 0.93f, 0.89f, 0.98f);

            var rootLayout = root.AddComponent<HorizontalLayoutGroup>();
            rootLayout.padding = new RectOffset(16, 16, 16, 16);
            rootLayout.spacing = 12f;
            rootLayout.childControlWidth = true;
            rootLayout.childControlHeight = true;
            rootLayout.childForceExpandWidth = true;
            rootLayout.childForceExpandHeight = true;

            var viewportPanel = CreateUiObject("ViewportPanel", root.transform);
            viewportPanel.AddComponent<Image>().color = new Color(0.16f, 0.2f, 0.23f, 0.95f);
            var viewportLayoutElement = viewportPanel.AddComponent<LayoutElement>();
            viewportLayoutElement.flexibleWidth = 3f;
            viewportLayoutElement.preferredWidth = 1180f;

            var viewportLayout = viewportPanel.AddComponent<VerticalLayoutGroup>();
            viewportLayout.padding = new RectOffset(12, 12, 12, 12);
            viewportLayout.spacing = 8f;
            viewportLayout.childControlWidth = true;
            viewportLayout.childControlHeight = true;
            viewportLayout.childForceExpandWidth = true;
            viewportLayout.childForceExpandHeight = false;

            var visualPanel = CreateUiObject("VisualPanel", viewportPanel.transform);
            _placeholderVisual = visualPanel.AddComponent<Image>();
            _placeholderVisual.color = DirectionColor(CardinalDirection.N);

            var visualLayoutElement = visualPanel.AddComponent<LayoutElement>();
            visualLayoutElement.minHeight = 560f;
            visualLayoutElement.flexibleHeight = 1f;

            var visualLayout = visualPanel.AddComponent<VerticalLayoutGroup>();
            visualLayout.childAlignment = TextAnchor.MiddleCenter;
            visualLayout.spacing = 6f;
            visualLayout.padding = new RectOffset(20, 20, 20, 20);
            visualLayout.childControlWidth = true;
            visualLayout.childControlHeight = false;
            visualLayout.childForceExpandWidth = true;
            visualLayout.childForceExpandHeight = false;

            _placeholderTitle = CreateText(visualPanel.transform, "Placeholder View", 42, FontStyle.Bold, TextAnchor.MiddleCenter, Color.white);
            _placeholderSubtitle = CreateText(visualPanel.transform, "Node 1", 24, FontStyle.Normal, TextAnchor.MiddleCenter, Color.white);

            var hint = CreateText(
                visualPanel.transform,
                "Placeholder visual only. Final art, SFX layers, and scene detail systems are pending.",
                18,
                FontStyle.Italic,
                TextAnchor.MiddleCenter,
                new Color(0.96f, 0.97f, 0.98f, 0.95f));
            hint.horizontalOverflow = HorizontalWrapMode.Wrap;

            var controlsRow = CreateUiObject("ControlsRow", viewportPanel.transform);
            var controlsLayoutElement = controlsRow.AddComponent<LayoutElement>();
            controlsLayoutElement.preferredHeight = 66f;

            var controlsLayout = controlsRow.AddComponent<HorizontalLayoutGroup>();
            controlsLayout.spacing = 8f;
            controlsLayout.childControlWidth = true;
            controlsLayout.childControlHeight = true;
            controlsLayout.childForceExpandWidth = true;
            controlsLayout.childForceExpandHeight = true;

            _turnLeftButton = CreateButton(controlsRow.transform, "Turn Left", () => _navigator?.TurnLeft());
            _turnRightButton = CreateButton(controlsRow.transform, "Turn Right", () => _navigator?.TurnRight());
            _turnBackButton = CreateButton(controlsRow.transform, "Turn Back", () => _navigator?.TurnBack());
            _forwardButton = CreateButton(controlsRow.transform, "Forward", OnForwardPressed);
            _forwardButtonText = _forwardButton.GetComponentInChildren<Text>();

            var infoPanel = CreateUiObject("InfoPanel", root.transform);
            infoPanel.AddComponent<Image>().color = new Color(0.99f, 0.99f, 0.98f, 0.98f);
            var infoLayoutElement = infoPanel.AddComponent<LayoutElement>();
            infoLayoutElement.flexibleWidth = 2f;
            infoLayoutElement.preferredWidth = 740f;

            var infoLayout = infoPanel.AddComponent<VerticalLayoutGroup>();
            infoLayout.padding = new RectOffset(12, 12, 12, 12);
            infoLayout.spacing = 8f;
            infoLayout.childControlWidth = true;
            infoLayout.childControlHeight = true;
            infoLayout.childForceExpandWidth = true;
            infoLayout.childForceExpandHeight = false;

            var title = CreateText(infoPanel.transform, "Node Navigation Prototype", 30, FontStyle.Bold, TextAnchor.UpperLeft, new Color(0.09f, 0.12f, 0.13f, 1f));
            title.horizontalOverflow = HorizontalWrapMode.Wrap;

            _infoText = CreateText(infoPanel.transform, string.Empty, 19, FontStyle.Normal, TextAnchor.UpperLeft, new Color(0.08f, 0.1f, 0.1f, 1f));
            _infoText.horizontalOverflow = HorizontalWrapMode.Wrap;
            _infoText.verticalOverflow = VerticalWrapMode.Overflow;
            var infoTextLayout = _infoText.gameObject.AddComponent<LayoutElement>();
            infoTextLayout.flexibleHeight = 1f;

            var debugTitle = CreateText(infoPanel.transform, "Debug Panel", 24, FontStyle.Bold, TextAnchor.UpperLeft, new Color(0.2f, 0.16f, 0.07f, 1f));
            debugTitle.horizontalOverflow = HorizontalWrapMode.Wrap;

            _debugText = CreateText(infoPanel.transform, string.Empty, 17, FontStyle.Normal, TextAnchor.UpperLeft, new Color(0.2f, 0.16f, 0.07f, 1f));
            _debugText.horizontalOverflow = HorizontalWrapMode.Wrap;
            _debugText.verticalOverflow = VerticalWrapMode.Overflow;

            _uiBuilt = true;
        }

        private void Render()
        {
            if (!_uiBuilt)
            {
                return;
            }

            if (_navigator == null || _navigator.CurrentNode == null)
            {
                _placeholderTitle.text = "No Node Loaded";
                _placeholderSubtitle.text = "Check CSV file at Resources/Data/nodes.csv";
                _infoText.text = "No route data is currently loaded.";
                _debugText.text = "CSV row status: unavailable";
                SetControlsInteractable(false);
                _forwardButton.gameObject.SetActive(false);
                return;
            }

            var node = _navigator.CurrentNode;
            var direction = _navigator.CurrentDirection;
            var forwardTarget = _navigator.GetForwardTarget();

            _placeholderVisual.color = DirectionColor(direction);
            _placeholderTitle.text = $"{direction} View";
            _placeholderSubtitle.text = $"Node {node.NodeId} - {Safe(node.SceneName, "Untitled Scene")}";

            _infoText.text =
                $"Current Node: {node.NodeId}\n" +
                $"Scene: {Safe(node.SceneId, "Unknown Scene")} - {Safe(node.SceneName, "Untitled")}\n" +
                $"Time Window: {Safe(node.TimeWindow)}\n" +
                $"Approx Distance to DeCew: {Safe(node.ApproxDistanceToDecew)}\n" +
                $"Modern Approx Location: {Safe(node.ModernApproxLocation)}\n" +
                $"Current Direction/View: {direction}\n" +
                $"Notes: {Safe(node.Notes, "No notes listed in CSV")}";

            _debugText.text =
                $"Current node ID: {node.NodeId}\n" +
                $"Current direction: {direction}\n" +
                $"Forward target: {(forwardTarget.HasValue ? $"Node {forwardTarget.Value}" : "None (terminal)")}\n" +
                $"Scene number/name: {Safe(node.SceneId, "Unknown")} / {Safe(node.SceneName, "Untitled")}\n" +
                $"CSV row status: {Safe(node.CsvRowStatus)}\n" +
                $"Future richer content pending: {(node.HasFutureRichContentPending ? "Yes" : "No")}\n" +
                $"Traversal check: {(_navigator != null ? _navigator.BuildTraversalStatus() : "Unavailable")}\n" +
                $"Total loaded nodes: {(_route != null ? _route.SortedNodeIds.Count : 0)}";

            SetControlsInteractable(true);

            var canForward = _navigator.CanMoveForward();
            _forwardButton.gameObject.SetActive(canForward);
            if (canForward && forwardTarget.HasValue)
            {
                _forwardButtonText.text = $"Forward -> Node {forwardTarget.Value}";
            }
        }

        private void OnForwardPressed()
        {
            if (_navigator == null)
            {
                return;
            }

            var moved = _navigator.MoveForward();
            if (!moved)
            {
                Debug.Log("[NodePrototypeUI] Forward blocked. Face the default forward direction first.");
            }
        }

        private void SetControlsInteractable(bool interactable)
        {
            _turnLeftButton.interactable = interactable;
            _turnRightButton.interactable = interactable;
            _turnBackButton.interactable = interactable;
            _forwardButton.interactable = interactable;
        }

        private static GameObject CreateUiObject(string name, Transform parent)
        {
            var go = new GameObject(name, typeof(RectTransform));
            go.transform.SetParent(parent, false);
            return go;
        }

        private static Text CreateText(
            Transform parent,
            string content,
            int fontSize,
            FontStyle style,
            TextAnchor alignment,
            Color color)
        {
            var textObject = CreateUiObject("Text", parent);
            var text = textObject.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.text = content;
            text.fontSize = fontSize;
            text.fontStyle = style;
            text.alignment = alignment;
            text.color = color;
            text.supportRichText = false;
            text.resizeTextForBestFit = false;
            return text;
        }

        private static Button CreateButton(Transform parent, string label, UnityEngine.Events.UnityAction onClick)
        {
            var buttonObject = CreateUiObject($"{label}Button", parent);
            var image = buttonObject.AddComponent<Image>();
            image.color = new Color(0.9f, 0.92f, 0.93f, 1f);

            var button = buttonObject.AddComponent<Button>();
            button.targetGraphic = image;
            button.onClick.AddListener(onClick);

            var layout = buttonObject.AddComponent<LayoutElement>();
            layout.preferredHeight = 52f;
            layout.flexibleWidth = 1f;

            var labelText = CreateText(buttonObject.transform, label, 20, FontStyle.Bold, TextAnchor.MiddleCenter, new Color(0.1f, 0.13f, 0.14f, 1f));
            Stretch(labelText.rectTransform, 0f);
            return button;
        }

        private static void EnsureEventSystem()
        {
            if (EventSystem.current != null)
            {
                return;
            }

            var eventSystemObject = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            eventSystemObject.transform.SetParent(null, false);
        }

        private static void Stretch(RectTransform rectTransform, float margin)
        {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = new Vector2(margin, margin);
            rectTransform.offsetMax = new Vector2(-margin, -margin);
        }

        private static Color DirectionColor(CardinalDirection direction)
        {
            switch (direction)
            {
                case CardinalDirection.N:
                    return new Color(0.29f, 0.47f, 0.39f, 1f);
                case CardinalDirection.E:
                    return new Color(0.29f, 0.41f, 0.53f, 1f);
                case CardinalDirection.S:
                    return new Color(0.54f, 0.37f, 0.25f, 1f);
                case CardinalDirection.W:
                    return new Color(0.45f, 0.3f, 0.42f, 1f);
                default:
                    return new Color(0.35f, 0.35f, 0.35f, 1f);
            }
        }

        private static string Safe(string value, string fallback = "-")
        {
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }
    }
}
