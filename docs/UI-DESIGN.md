# CodeBank UI design

## Visual direction

CodeBank uses a restrained modern desktop visual system designed for focused coding sessions and dense data entry.

- **Application shell:** dark navy brand header, light workspace, and a quiet status bar.
- **Primary actions:** blue save/update buttons with hover and pressed feedback.
- **Destructive actions:** red delete buttons, visually separated from normal actions.
- **Secondary actions:** neutral slate surfaces; copy actions use a light cyan treatment.
- **Typography:** Tahoma for Persian interface text and Consolas for source code.
- **Code editing:** dark, high-contrast editor surfaces with horizontal and vertical scrollbars and wrapping disabled.
- **Data grid:** dark headers, alternating rows, clear selection state, and consistent row height.
- **Navigation:** owner-drawn tabs with a selected indicator and custom list selection states.

## Interaction principles

1. Keep destructive actions visually distinct from save/update actions.
2. Preserve the existing unsaved-change confirmation flow during navigation.
3. Keep search and results grouped in one panel.
4. Use consistent hover and pressed states so buttons communicate interactivity.
5. Keep code text left-to-right while the Persian application UI remains right-aligned.

## Implementation constraints

The visual system is implemented with native Windows Forms controls and GDI+ drawing. It adds no third-party UI dependency and remains compatible with the existing .NET Framework 4.6.1 target.

The theme is centralized in `CodeBank/Ui/CodeBankTheme.cs`; form-specific shell composition remains in `frmCodeBank`.
