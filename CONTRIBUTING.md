# Contributing

## Prototype Scope

This repository is currently for the first Unity milestone only:

- static node navigation
- CSV-driven route spine
- placeholder visuals and data placeholders for later systems

Do not add combat, inventory, save/load, or final art pipeline features in this phase.

## Content Pipeline Conventions

- Route spine source is Assets/Resources/Data/nodes.csv.
- Keep Node values stable once referenced in scripts or scene logic.
- Keep CSV columns compatible with CsvNodeLoader required headers.
- Story text additions should remain external to runtime code until the content-layer pass.
- Do not overwrite established historical writing when adding future content files.

## Unity Repository Conventions

- Commit all Unity .meta files with their corresponding assets.
- Keep runtime architecture under Assets/Scripts with Data, Runtime, and UI separation.
- Keep placeholder-only features clearly labeled as placeholders.

## Git LFS Conventions

- Install Git LFS once per machine before first push:
  - git lfs install
- This repository tracks common large art/audio/video formats via .gitattributes.
- Verify tracked files with:
  - git lfs ls-files

## Validation Before PR

- Open Assets/Scenes/Prototype.unity.
- Press Play and verify route starts at Node 1.
- Verify N/E/S/W turns work at any node.
- Verify Forward only appears on the default forward direction.
- Verify full forward traversal reaches the final node from the CSV route.

## Commit Guidance

- Keep commits small and descriptive.
- Mention impacted systems in commit messages, for example:
  - csv-loader
  - node-navigation
  - prototype-ui
