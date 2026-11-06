# Release process

CodeBank releases are created from version tags. The release workflow builds the application, runs the automated unit tests, creates a Windows installer with Inno Setup, and attaches the installer to a GitHub Release.

## Before creating a tag

1. Confirm the default branch has a successful build and test run.
2. Run the application on a clean Windows machine or VM.
3. Verify SQLite native dependencies load and the application starts.
4. Test create, read, update, and delete operations.
5. Test migration from an existing executable-folder `database.db`.
6. Verify that an existing per-user database is never overwritten.
7. Back up any real user data before upgrade testing.
8. Update `CHANGELOG.md` and assembly version metadata.

## Create a release

Create and push a semantic version tag, for example:

```bash
git tag v1.0.0
git push origin v1.0.0
```

The `Release CodeBank` workflow will build, test, package, and publish the installer.

## Important

- The installer is per-user and does not require administrator privileges.
- The SQLite database is stored outside the installation folder, so uninstalling the application does not remove user data.
- The installer is not code-signed. Windows may show an unknown-publisher or SmartScreen warning.
- Do not publish a release if CI is failing or manual Windows verification has not been completed.
- A successful build and unit-test run does not replace manual UI and end-to-end verification.
