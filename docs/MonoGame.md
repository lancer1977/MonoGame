# MonoGame

**Location:** `~/code/MonoGame`

**Purpose:** Helper library for MonoGame/XNA 2D game development. Provides utilities for animations, resolution handling, collision detection, and game state management. Inspired by Shiny.net patterns.

## Tech Stack

- **Framework:** MonoGame (.NET 6.0, .NET 8.0)
- **Type:** Class Library
- **Dependencies:** MonoGame.Framework.DesktopGL v3.8.1.303

## Project Structure

```
MonoGame/
├── src/
│   ├── GameBase.cs              # Base class for MonoGame apps
│   ├── GameData.cs              # Game state management
│   ├── Resolution.cs            # Resolution handling/scaling
│   ├── Animation.cs             # Animation system
│   ├── DrawHelper.cs            # Drawing utilities
│   ├── RectangleExtensions.cs  # Collision detection
│   ├── Drawables/               # Drawable game objects
│   ├── Enums/                   # Game enumerations
│   ├── Interactions/             # User interaction handlers
│   ├── Interfaces/              # Abstractions (IDrawHelper)
│   └── Services/                # Game services
├── tests/                       # Unit tests
├── Project1/                    # Sample game demo
└── PolyhydraGames.MonoGame.sln  # Solution file
```

## Entry Points

| File | Purpose |
|------|---------|
| `src/PolyhydraGames.MonoGame.csproj` | Main library |
| `tests/PolyhydraGames.MonoGame.Tests/` | Unit tests |
| `Project1/` | Basic game implementation demo |

## Key Components

| Component | Purpose |
|-----------|---------|
| `GameBase.cs` | Base class for MonoGame applications |
| `Resolution.cs` | Resolution handling and scaling |
| `Animation.cs` | Animation system implementation |
| `DrawHelper.cs` | Drawing utilities |
| `RectangleExtensions.cs` | Collision detection helpers |

## Build & Test

```bash
dotnet build PolyhydraGames.MonoGame.sln
dotnet test PolyhydraGames.MonoGame.sln
```

## Notes

- Utility library used by other game projects
- Legacy XNA-style patterns with modern .NET
- Sample project in `Project1/` demonstrates usage