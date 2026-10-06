# Assignment 14 - Solution, Build and Project

This document outlines the structural layout, dependencies, and build configurations for the multi-project console solution within Visual Studio.

## Solution Explorer Structure

### Initial Solution Layout
* Solution CSharpSolution (4 of 4 projects)
  * DisplayApp
    * Dependencies
    * .editorconfig
    * Program.cs
  * GreetingApp
    * Dependencies
    * .editorconfig
    * Program.cs
  * MathApp
    * Dependencies
    * .editorconfig
    * Calculator.cs
    * Program.cs
  * UtilityApp
    * Dependencies
    * .editorconfig
    * Program.cs

### Modified Solution Layout
* Solution CSharpSolution (5 of 5 projects)
  * DisplayApp
  * GreetingApp
  * MathApp
  * UtilityApp
  * ValidatorApp (Project E)
    * Dependencies
    * .editorconfig
    * Program.cs

---

## Project Dependencies and Build Order

Visual Studio calculates the compilation sequence based on designated project-to-project references to ensure prerequisites are compiled before dependent layers.

### Pre-Modification Build Sequence
1. UtilityApp (Base framework helper)
2. DisplayApp (Console menu and UI interface)
3. MathApp (Arithmetic calculation layer)
4. GreetingApp (Application entry onboarding screen)

![Pre-Modification Build Dependencies](ScreenShots/Snapshot2.png)

### Post-Modification Build Sequence
1. UtilityApp
2. DisplayApp
3. ValidatorApp (New custom validation tier inserted here)
4. MathApp
5. GreetingApp

![Post-Modification Build Dependencies with Project E](ScreenShots/Snapshot1.png)


---

## Technical Analysis and System Management

### Importance of Solution Organization
Breaking a software ecosystem into independent, specialized projects enforces Separation of Concerns. By separating infrastructure tasks like utility logging (UtilityApp) from validation logic (ValidatorApp) and core calculation components (MathApp), development teams can restrict technical changes to isolated modules. 
This structure prevents code degradation, resolves team workflow overlaps, and simplifies code reusability.
