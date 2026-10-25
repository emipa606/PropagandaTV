# GitHub Copilot Instructions for Propaganda TV (Continued) Mod

## Mod Overview and Purpose
The Propaganda TV (Continued) mod is an update to the original Propaganda TV mod. It passively reduces the certainty of newly recruited pawns in their current ideology if it is not the primary ideology of the colony. The mod reinforces the belief in the primary colony's ideology if the pawn already believes in it. It also provides a short-term mood buff to pawns who have their certainty reduced and automatically converts pawns to the colony's primary ideology if their certainty reaches a low enough point. The mod works by adding a comp to a powered Radio or TV and is highly compatible with other mods.

## Key Features and Systems
- **Certainty Reduction**: Reduces the certainty of pawns in their current ideology if it is not the primary ideology of the colony.
- **Belief Reinforcement**: Reinforces the belief in the primary colony's ideology if the pawn already believes in it.
- **Mood Buff**: Provides a short-term mood buff (+5 for 5 hours) to pawns who have their certainty reduced.
- **Automatic Conversion**: Automatically converts pawns to the colony's primary ideology if their certainty reaches a low enough point.
- **XML Integration**: Utilizes XML files to define thoughts and patches.
- **Harmony Patching**: Uses Harmony patching to modify vanilla game behavior.

## Coding Patterns and Conventions
- **C# Files**: The mod primarily uses C# for its logic and components.
  - `CompTVPropaganda.cs`: Contains the main logic for the comp added to TVs and radios.
  - `CompProperties_TVPropaganda.cs`: Contains the properties for the comp.
- **XML Files**: The mod uses XML files to define thoughts and patches.
  - `Defs_RadioThought.xml` and `Defs_TVThought.xml`: Define thoughts related to radios and TVs.
  - `Buildings_Furniture.xml`, `Buildings_Joy.xml`, and `Patch_TV_Vanilla.xml`: Define patches for buildings and joy.

## XML Integration
The mod integrates with the RimWorld XML system to define thoughts and patches. The XML files are located in the `Defs` and `Patches` folders. Key XML files include:

- `Defs_RadioThought.xml`: Defines thoughts related to radios.
- `Defs_TVThought.xml`: Defines thoughts related to TVs.
- `Buildings_Furniture.xml`: Patches for furniture buildings.
- `Buildings_Joy.xml`: Patches for joy buildings.
- `Patch_TV_Vanilla.xml`: Patches for vanilla TVs.

## Harmony Patching
The mod uses Harmony patching to modify vanilla game behavior. Key patches include:

- **Buildings_Furniture.xml**: Patches for furniture buildings.
- **Buildings_Joy.xml**: Patches for joy buildings.
- **Patch_TV_Vanilla.xml**: Patches for vanilla TVs.

## Suggestions for Copilot
When using GitHub Copilot for this mod, consider the following suggestions:

1. **C# Logic**: Focus on writing C# code for the logic of the comp and its properties.
2. **XML Definitions**: Use Copilot to generate XML definitions for thoughts and patches.
3. **Harmony Patches**: Utilize Copilot to create and modify Harmony patches for vanilla game behavior.
4. **Code Formatting**: Ensure that the generated code follows the coding patterns and conventions of the mod.
5. **Testing**: After generating code, thoroughly test the mod to ensure that it functions as intended.

By following these instructions, developers can effectively use GitHub Copilot to enhance the Propaganda TV (Continued) mod.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

