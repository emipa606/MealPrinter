# GitHub Copilot Instructions for Meal Printer (Continued)

## Mod Overview and Purpose

Meal Printer (Continued) is an update to the SomewhereOutInSpaces mod, introducing the Meal Printer building and NutriBars into the RimWorld game. The mod focuses on adding advanced meal production for the mid-to-late game, enhancing the automation and efficiency of food production.

## Key Features and Systems

### Meal Printer Building
- Acts as an advanced drop-in upgrade to the nutrient paste dispenser.
- Converts raw foodstuffs into filling, wholesome meals.
- Researchable upgrades unlock fine meals, high-efficiency nutrient paste, and NutriBars.

### NutriBars
- A spacer-tech compromise between neolithic pemmican and industrial packaged survival meals.
- Lightweight, energy dense, and inoffensively flavored.
- One NutriBar is just as filling as a traditional meal and lasts several seasons without refrigeration.

## Coding Patterns and Conventions

### C# Code Structure
- **Dialog_PrintBars.cs**: Handles the dialog for printing NutriBars.
- **HarmonyPatches**:
  - **JobGiver_Autofeed_TryGiveJob.cs**: Prefixes the `findAlternativeBabyFood` method to modify job-giving behavior.
  - **ThingDef_IsFoodDispenser.cs**: Prefixes the `IsFoodDispenser` method to integrate meal printers into the food dispenser system.
  - **ThingListGroupHelper_Includes.cs**: Prefixes the `Includes` method to include meal printers in relevant lists.
  - **JobDriver_FoodFeedPatient_GetReport.cs**: Postfixes the `GetReport` method to modify job reports for food feeding.

### XML Integration
- **BuildingDefs/Building_MealPrinter.xml**: Defines the Meal Printer building.
- **ItemDefs/Items_Food.xml**: Defines NutriBars and other food items.
- **ResearchDefs/MealPrinter_ResearchProjects.xml**: Defines research projects required to unlock meal printer features.
- **ResearchDefs/MealPrinter_ResearchTab.xml**: Defines the research tab for meal printer upgrades.
- **SoundDefs/PrinterSounds.xml**: Defines sound effects for meal printer operations.

## Harmony Patching

Harmony is used to patch existing RimWorld code to integrate the new meal printer and NutriBar features. The patches are located in the `HarmonyPatches` folder and modify methods such as `findAlternativeBabyFood`, `IsFoodDispenser`, `Includes`, and `GetReport`.

## Suggestions for Copilot

1. **C# Code Generation**:
   - Use Copilot to generate new dialog classes or harmony patches.
   - Suggest code improvements or fixes for existing C# files.

2. **XML Defs**:
   - Assist in creating new XML def files or modifying existing ones.
   - Suggest improvements to existing XML definitions.

3. **Integration with Vending Machine Mechanic**:
   - If the Hospitality mod is loaded, use Copilot to integrate the meal printer with the vending machine mechanic.
   - Suggest code changes to support additional mod compatibility.

4. **Documentation and Comments**:
   - Use Copilot to generate documentation and comments for C# files and XML defs.
   - Suggest improvements to existing documentation and comments.

5. **Debugging and Support**:
   - Use Copilot to assist in debugging code and resolving issues.
   - Suggest solutions for known issues or errors reported by users.

By following these guidelines, Copilot can be effectively utilized to enhance the Meal Printer (Continued) mod, ensuring a smooth integration with RimWorld and providing additional features and improvements.

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

