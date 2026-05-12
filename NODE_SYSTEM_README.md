# NODE_SYSTEM_README

## Purpose

This project now includes a first-pass Unity C# node-navigation prototype for:

- 1813: The Queenston Warning
- The Secret in the House

The milestone is a data-driven static-node route prototype only.

## Unity Structure

- Assets/Scripts/Data/
  - SceneData.cs
  - NodeData.cs
  - NodeViewData.cs
  - ExitData.cs
  - HotspotData.cs
- Assets/Scripts/Runtime/
  - CsvNodeLoader.cs
  - NodeNavigator.cs
  - GameManager.cs
- Assets/Scripts/UI/
  - NodePrototypeUI.cs
- Assets/Resources/Data/
  - nodes.csv
- Assets/Scenes/
  - Prototype.unity

## Data Flow: CSV -> Runtime Node Data

1. CsvNodeLoader loads Resources/Data/nodes.csv at runtime.
2. The CSV parser reads required tracker columns:
   - Node
   - Scene
   - Scene Name
   - Approx Distance to DeCew
   - Time Window
   - Modern Approx Location
   - Default/Forward View
   - Leads To (Forward)
   - Forward Node Direction
   - Notes
3. Each row becomes NodeData with:
   - metadata fields from CSV
   - four directional NodeViewData entries (N/E/S/W)
   - placeholder AlternateContentData entries for danger/cutscene expansion
   - forward ExitData
4. Scene buckets are created as SceneData collections.

## CSV Safety and Malformed Data Handling

CsvNodeLoader is defensive:

- Blank/missing fields do not crash loading.
- Malformed rows are skipped with warnings.
- Missing direction values fallback safely to N with warning.
- Ambiguous or missing forward node strings fallback to sequential node order.
- Terminal nodes remain valid with no forward target.

## Directional Navigation Rules

NodeNavigator controls player movement state:

- Starts at Node 1 if present; otherwise starts at the first sorted node.
- Tracks current node ID and current direction.
- Turn Left: N->W->S->E->N
- Turn Right: N->E->S->W->N
- Turn Back: 180 degree turn
- Forward is only available when:
  - current direction equals node default/forward direction
  - the node has a valid forward target

When moving forward, the next node loads and direction resets to that node's default forward direction.

## Prototype UI

NodePrototypeUI builds a Canvas UI at runtime using placeholder visuals:

- Large colored view panel (color varies by N/E/S/W)
- Text display for:
  - current node
  - scene
  - time window
  - approx distance to DeCew
  - modern approx location
  - current direction
  - notes
- Buttons:
  - Turn Left
  - Turn Right
  - Turn Back
  - Forward (only visible when allowed)
- Debug panel:
  - current node ID
  - current direction
  - forward target
  - scene number/name
  - CSV row status
  - route traversal summary

## Scene Wiring

Prototype scene:

- Assets/Scenes/Prototype.unity
- Contains GameObject named GameManager
- GameManager, CsvNodeLoader, NodeNavigator, and NodePrototypeUI components are attached

Press Play in Unity with this scene open to run the prototype.

## Placeholder Scope

Still placeholder in this milestone:

- visuals
- hotspots (data placeholder only)
- danger alternates (data placeholder only)
- cutscenes (data placeholder only)
- environmental cards
- SFX layers
- auto lines
- portrait dialogue
- transition sequencing

## Future Content Integration

Markdown scene files can be added later through a content-layer pass:

- keep CSV as route spine
- attach richer scene content by node ID / scene ID
- add hotspot and alternate assets per direction
- evolve loader to ScriptableObjects or a dedicated content database without replacing navigation core
