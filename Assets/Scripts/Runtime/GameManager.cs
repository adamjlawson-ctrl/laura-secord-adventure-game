using QueenstonWarning.NodeSystem.Runtime;
using QueenstonWarning.NodeSystem.UI;
using UnityEngine;

namespace QueenstonWarning.NodeSystem.Runtime
{
    [RequireComponent(typeof(CsvNodeLoader))]
    [RequireComponent(typeof(NodeNavigator))]
    [RequireComponent(typeof(NodePrototypeUI))]
    public sealed class GameManager : MonoBehaviour
    {
        private CsvNodeLoader _loader;
        private NodeNavigator _navigator;
        private NodePrototypeUI _ui;

        private void Awake()
        {
            _loader = GetComponent<CsvNodeLoader>();
            _navigator = GetComponent<NodeNavigator>();
            _ui = GetComponent<NodePrototypeUI>();

            var route = _loader.LoadFromResources();
            _navigator.Initialize(route);
            _ui.Initialize(_navigator, route);

            Debug.Log($"[GameManager] { _navigator.BuildTraversalStatus() }");
        }
    }
}
