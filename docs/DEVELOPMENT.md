# Development and release notes

## Current application boundaries

CodeBank is currently a single-user Windows desktop application. The UI calls the service layer, which validates input and delegates persistence to the SQLite repository.

The SQLite database is stored per Windows user at `%LOCALAPPDATA%\\Matin-dev-2010\\CodeBank\\database.db`. On first launch, the application migrates the legacy executable-folder database only when the new destination does not exist. The original database is retained. If both files already exist, the application deliberately does not merge or overwrite either file; compare and back up them manually before deciding which data set to keep.\n\nThe current data flow is:

`Windows Forms UI -> Services -> Data repository -> SQLite`

## Database compatibility

The database initializer uses `CREATE TABLE IF NOT EXISTS` and creates indexes. This protects an existing table from being dropped during startup, but it is not a migration framework.

Before changing the schema:

1. Back up a representative existing `database.db`.
2. Define the old and new schema.
3. Add a versioned, transactional migration.
4. Verify that existing records survive the migration.
5. Test both a fresh database and an upgrade from the previous schema.

The current location migration preserves the original file and copies SQLite WAL / rollback-journal sidecars when present. If both the old and new locations contain databases, no automatic merge is attempted. Back up both files and compare them manually.

Do not change the database location again without a migration strategy that preserves existing user data.

## Verification checklist

For changes affecting the editor or persistence, manually verify:

- Create a record and confirm it appears after restart.
- Read and filter records by category.
- Update an existing record.
- Delete a record after confirmation.
- Try clearing, navigating, and closing with unsaved changes; verify Yes, No, and Cancel behavior.
- Verify empty required fields are rejected.
- Verify special characters are stored and retrieved correctly.
- Verify an existing database is not overwritten.

## CI and artifacts

The GitHub Actions workflow restores NuGet packages, builds the solution in Release mode on Windows, runs the NUnit unit tests, and uploads the application output and test results as short-lived artifacts. The tag-triggered release workflow builds a per-user installer using Inno Setup.

A successful build proves compilation only. It does not replace automated tests or manual UI/database verification.

## Before publishing a release

1. Confirm the intended version and update the changelog.
2. Run the CI workflow and inspect its result.
3. Test the built application on a clean Windows environment.
4. Confirm the SQLite native provider files are included and the app starts.
5. Test database creation and upgrade behavior.
6. Package only verified binaries; do not publish a release based solely on a successful compile.
7. Attach checksums and installation / upgrade instructions when distributing binaries.
