# Contributing to CodeBank

Thank you for considering a contribution.

## Before you start

1. Check existing issues and pull requests to avoid duplicate work.
2. For a significant change, open an issue first to discuss the approach.
3. Keep changes focused. Avoid unrelated formatting or generated Designer-file changes.

## Development setup

- Windows with Visual Studio and .NET Framework 4.6.1 targeting support.
- Restore NuGet packages from `CodeBank.sln`.
- Build the solution in both Debug and Release configurations when possible.
- Back up any local `database.db` before testing database changes.

## Code guidelines

- Keep SQL and persistence code in `Data`, validation in `Services`, models in `Models`, and UI orchestration in the form.
- Use parameterized SQL commands. Never concatenate user input into SQL.
- Dispose database connections, commands, and readers with `using`.
- Preserve existing user data. Do not drop or recreate the production table as a shortcut.
- Validate inputs at the service boundary.
- Keep user-facing messages clear and consistent with the existing Persian UI.
- Do not commit credentials, personal data, database files, build output, or local IDE state.

## Pull request checklist

- [ ] The change has a clear, focused purpose.
- [ ] The solution builds successfully.
- [ ] Existing CRUD and unsaved-change behavior has been checked when relevant.
- [ ] Database changes are backward-compatible or include a documented migration plan.
- [ ] README or other documentation is updated when behavior changes.
- [ ] No secrets, local databases, or generated build files are included.
- [ ] Limitations and manual test steps are described in the pull request.

## Commit messages

Use short, descriptive messages. Examples:

- `fix: prevent losing edits during navigation`
- `docs: clarify database storage behavior`
- `ci: publish build artifacts`

## Reporting issues

Use the Bug report or Feature request template. Include reproduction steps, expected behavior, actual behavior, and relevant environment details. Remove private data before sharing logs or screenshots.
