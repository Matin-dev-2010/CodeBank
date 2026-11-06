# CodeBank UI design

## Design direction

CodeBank uses a restrained modern desktop visual system designed for long coding sessions and dense data entry.

- **Application shell:** dark navy brand header, light workspace, and a quiet status bar.
- **Primary color:** blue for save/update and selected navigation states.
- **Danger color:** red for destructive actions.
- **Secondary actions:** neutral slate surfaces; copy actions use a light cyan treatment.
- **Typography:** Tahoma for Persian interface text and Consolas for source code.
- **Code editing:** dark, high-contrast editor surfaces with wrapping disabled to preserve indentation and long lines.
- **Data grid:** high-contrast headers, alternating rows, clear selection state, and consistent row height.
- **Navigation:** owner-drawn tabs with a clear selected indicator and custom list selection states.

## Interaction principles

1. Keep destructive actions visually distinct from save/update actions.
2. Preserve the existing unsaved-change confirmation flow during navigation.
3. Keep search and its results grouped in one panel.
4. Use consistent hover and pressed states so buttons communicate interactivity.
5. Keep code text left-to-right while the Persian application UI remains right-aligned.

## Implementation constraints

The visual system is implemented with native Windows Forms controls and GDI+ drawing. It does not add a third-party UI dependency and remains compatible with the existing .NET Framework 4.6.1 target.

The theme is centralized in `CodeBank/UI/CodeBankTheme.cs`; form-specific shell composition remains in `frmCodeBank`.
