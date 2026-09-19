# CodeBank

CodeBank is a C# Windows Forms desktop application for storing, organizing, editing, and deleting reusable code snippets in a local SQLite database.

## Tech Stack

- C#
- Windows Forms
- .NET Framework 4.6.1
- SQLite
- System.Data.SQLite 1.0.119

Entity Framework is not used by the application and has been removed from the project dependencies.

## Architecture

```text
CodeBank/
├── CodeBank.sln
└── CodeBank/
    ├── Data/
    │   ├── Database.cs
    │   ├── DatabaseInitializer.cs
    │   └── CodeRepository.cs
    ├── Models/
    │   └── CodeItem.cs
    ├── Services/
    │   ├── CodeItemService.cs
    │   └── FormStateService.cs
    ├── Form1.cs
    ├── Form1.Designer.cs
    ├── Form1.resx
    ├── Program.cs
    ├── App.config
    └── packages.config
```

### Responsibilities

- **Models** — application data models.
- **Data** — SQLite connection, database initialization, and CRUD persistence.
- **Services** — validation and form-state behavior.
- **Form1.cs** — UI orchestration only; it does not contain SQL.
- **Form1.Designer.cs** — complete Windows Forms UI definition.

## Features

- Create code records.
- Read and browse all records.
- Update existing records.
- Delete records with confirmation.
- Browse records by category.
- Use database IDs for record selection instead of titles.
- Parameterized SQLite queries.
- Shared category-list behavior.
- Unsaved-change protection before clearing, navigating, replacing, or closing.
- Automatically generated Save, Update, Delete, and Clear controls in the WinForms designer code.
- Existing SQLite databases are reused without deleting user data.

## CRUD Flow

1. **New record:** fill the editor and select Save New Record.
2. **Edit:** select a row in the main grid or select a category item and press Edit.
3. **Update:** change the fields and press Update.
4. **Delete:** select a record and press Delete, then confirm.
5. **Clear:** press Clear. If there are unsaved changes, the application asks whether they should be saved first.

## Database

The database file is created as `database.db` beside the application executable. The application creates the required table and indexes automatically on startup.

The current database schema is compatible with the existing CodeFormFile table, so the application does not drop or recreate an existing database.

## Requirements

- Visual Studio with .NET Framework 4.6.1 development support.
- NuGet package restore.

## Getting Started

```bash
git clone https://github.com/Matin-dev-2010/CodeBank.git
```

Open CodeBank.sln, restore NuGet packages, build, and run.

## Notes

The project intentionally uses a small number of layers rather than introducing unnecessary frameworks. The goal is clear separation of UI, business validation, and persistence while keeping the application easy to understand and maintain.
