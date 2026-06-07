# Contributing to eyebreak

Thanks for your interest in improving eyebreak! Here's how to get set up.

## Prerequisites

- Windows 10 or later
- [.NET 9 SDK](https://dotnet.microsoft.com/download)

## Getting started

1. Fork the repository and clone your fork.
2. Build the solution:
   ```
   dotnet build eyebreak.sln
   ```
3. Run the app:
   ```
   dotnet run --project eyebreak.csproj
   ```
4. Run the test suite:
   ```
   dotnet test eyebreak.sln
   ```

## Project layout

- `MainForm.cs` / `MainForm.Designer.cs` — the settings window and tray icon behavior.
- `AppSettings.cs` — persisted user preferences (saved as JSON under `%AppData%\eyebreak`).
- `StartupManager.cs` — registers/unregisters the app to run at Windows startup.
- `CountdownFormatter.cs`, `BreakDefaults.cs` — small, pure helpers that are unit tested.
- `tests/eyebreak.Tests` — xUnit test project covering the testable, non-UI logic.

## Making changes

1. Create a branch (`git checkout -b feature/your-feature`).
2. Make your changes, keeping pure logic (formatting, settings, defaults) in small testable classes where practical — UI code in `MainForm` is harder to cover with automated tests.
3. Add or update tests in `tests/eyebreak.Tests` for any non-UI logic you change.
4. Run `dotnet build eyebreak.sln` and `dotnet test eyebreak.sln` and make sure both succeed.
5. Commit your changes and push to your fork.
6. Open a Pull Request describing what changed and why.

For larger changes, please open an issue first to discuss the approach before investing significant time.

## Releasing a build

A self-contained, single-file Windows executable can be produced with:

```
dotnet publish -c Release -p:PublishProfile=win-x64
```

The output is written to `bin\publish\win-x64\eyebreak.exe`.
