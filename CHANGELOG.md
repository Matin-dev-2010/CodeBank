# Changelog

All notable project changes should be documented here.

This project follows a lightweight Keep a Changelog-style format. Version numbers follow Semantic Versioning where practical.

## [Unreleased]

### Repository and maintenance
- Improve project documentation and contribution guidance.
- Improve the Windows CI workflow and retain build artifacts for a limited period.
- Add repository issue templates and dependency update automation.

### Application
- Store the SQLite database in the current user's LocalAppData directory.
- Migrate a legacy executable-folder database without deleting the original or overwriting an existing destination.
- Preserve SQLite WAL and rollback-journal sidecar files during first-run migration.
- Restore the previously selected grid record when unsaved navigation is cancelled.
- Reload the persisted record after a save-and-navigate operation to avoid displaying stale values.

### Tests
- Add NUnit unit tests for service validation and legacy database migration.
