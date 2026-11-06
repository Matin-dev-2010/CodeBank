using System;
using System.Drawing;
using System.Windows.Forms;
using CodeBank.Models;

namespace CodeBank.UI
{
    internal static class CodeBankTheme
    {
        internal static readonly Color Background = Color.FromArgb(241, 245, 249);
        internal static readonly Color Surface = Color.White;
        internal static readonly Color Ink = Color.FromArgb(30, 41, 59);
        internal static readonly Color Muted = Color.FromArgb(100, 116, 139);
        internal static readonly Color Primary = Color.FromArgb(37, 99, 235);
        private static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
        private static readonly Color Danger = Color.FromArgb(220, 38, 38);
        private static readonly Color DangerHover = Color.FromArgb(185, 28, 28);
        private static readonly Color CodeBackground = Color.FromArgb(15, 23, 42);
        private static readonly Color CodeForeground = Color.FromArgb(226, 232, 240);

        internal static void Apply(Control root, TabControl tabs)
        {
            tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabs.SizeMode = TabSizeMode.Fixed;
            tabs.ItemSize = new Size(126, 38);
            tabs.Padding = new Point(14, 5);
            tabs.DrawItem += (sender, e) => TabControl1_DrawItem(tabs, e);
            ApplyVisualTheme(root);
            tabs.Invalidate();
        }

        private static bool IsInsideHeader(Control control)
        {
            Control current = control;
            while (current != null)
            {
                if (current.Name == "pnlAppHeader")
                    return true;
                current = current.Parent;
            }
            return false;
        }

        private static void ApplyVisualTheme(Control root)
        {
            foreach (Control control in root.Controls)
            {
                bool insideHeader = IsInsideHeader(control);

                if (control is TabPage)
                {
                    control.BackColor = Background;
                    control.ForeColor = Ink;
                    control.Padding = new Padding(12);
                }
                else if (control is Label && !insideHeader)
                {
                    control.ForeColor = Muted;
                    control.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
                }
                else if (control is TextBox)
                {
                    var textBox = (TextBox)control;
                    textBox.BackColor = Surface;
                    textBox.ForeColor = Ink;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.Font = new System.Drawing.Font("Tahoma", 9.5F);
                    textBox.TextAlign = HorizontalAlignment.Right;
                }
                else if (control is RichTextBox)
                {
                    var editor = (RichTextBox)control;
                    editor.BackColor = CodeBackground;
                    editor.ForeColor = CodeForeground;
                    editor.BorderStyle = BorderStyle.None;
                    editor.Font = new System.Drawing.Font("Consolas", 10F);
                    editor.RightToLeft = RightToLeft.No;
                    editor.DetectUrls = false;
                    editor.WordWrap = false;
                }
                else if (control is ComboBox)
                {
                    var combo = (ComboBox)control;
                    combo.BackColor = Surface;
                    combo.ForeColor = Ink;
                    combo.FlatStyle = FlatStyle.Flat;
                    combo.Font = new System.Drawing.Font("Tahoma", 9F);
                }
                else if (control is ListBox)
                {
                    var list = (ListBox)control;
                    list.BackColor = Surface;
                    list.ForeColor = Ink;
                    list.BorderStyle = BorderStyle.None;
                    list.Font = new System.Drawing.Font("Tahoma", 9F);
                    list.DrawMode = DrawMode.OwnerDrawFixed;
                    list.ItemHeight = 32;
                    list.DrawItem -= ModernListBox_DrawItem;
                    list.DrawItem += ModernListBox_DrawItem;
                }
                else if (control is DataGridView)
                {
                    StyleDataGridView((DataGridView)control);
                }
                else if (control is Button)
                {
                    StyleButton((Button)control);
                }
                else if (control is CheckBox)
                {
                    var check = (CheckBox)control;
                    check.ForeColor = Ink;
                    check.Font = new System.Drawing.Font("Tahoma", 9F);
                    check.Cursor = Cursors.Hand;
                }
                else if (control is Panel && control.Name == "pnlSearch")
                {
                    control.BackColor = Surface;
                }

                if (control.HasChildren)
                    ApplyVisualTheme(control);
            }
        }

        private static void StyleButton(Button button)
        {
            bool isDanger = button.Name.IndexOf("delete", StringComparison.OrdinalIgnoreCase) >= 0 ||
                button.Text.IndexOf("حذف", StringComparison.OrdinalIgnoreCase) >= 0;
            bool isCopy = button.Text.IndexOf("کپی", StringComparison.OrdinalIgnoreCase) >= 0;
            bool isPrimary = button.Name.IndexOf("save", StringComparison.OrdinalIgnoreCase) >= 0 ||
                button.Name.IndexOf("update", StringComparison.OrdinalIgnoreCase) >= 0 ||
                button.Text.IndexOf("ذخیره", StringComparison.OrdinalIgnoreCase) >= 0 ||
                button.Text.IndexOf("بروزرسانی", StringComparison.OrdinalIgnoreCase) >= 0;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.UseVisualStyleBackColor = false;
            button.Cursor = Cursors.Hand;
            button.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            button.Height = Math.Max(button.Height, 34);
            button.Resize -= ModernButton_Resize;
            button.Resize += ModernButton_Resize;
            ApplyRoundedButtonRegion(button);

            if (isDanger)
            {
                button.BackColor = Danger;
                button.ForeColor = System.Drawing.Color.White;
                button.FlatAppearance.MouseOverBackColor = DangerHover;
                button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            }
            else if (isCopy)
            {
                button.BackColor = System.Drawing.Color.FromArgb(224, 242, 254);
                button.ForeColor = System.Drawing.Color.FromArgb(3, 105, 161);
                button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(186, 230, 253);
                button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(125, 211, 252);
            }
            else if (isPrimary)
            {
                button.BackColor = Primary;
                button.ForeColor = System.Drawing.Color.White;
                button.FlatAppearance.MouseOverBackColor = PrimaryHover;
                button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            }
            else
            {
                button.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
                button.ForeColor = Ink;
                button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 213, 225);
                button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(148, 163, 184);
            }
        }

        private static void ModernButton_Resize(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
                ApplyRoundedButtonRegion(button);
        }

        private static void ApplyRoundedButtonRegion(Button button)
        {
            int radius = Math.Min(9, Math.Max(4, button.Height / 4));
            int diameter = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, diameter, diameter, 180, 90);
            path.AddArc(button.Width - diameter - 1, 0, diameter, diameter, 270, 90);
            path.AddArc(button.Width - diameter - 1, button.Height - diameter - 1, diameter, diameter, 0, 90);
            path.AddArc(0, button.Height - diameter - 1, diameter, diameter, 90, 90);
            path.CloseFigure();

            var oldRegion = button.Region;
            button.Region = new System.Drawing.Region(path);
            path.Dispose();
            if (oldRegion != null)
                oldRegion.Dispose();
        }

        private static void StyleDataGridView(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Ink;
            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            grid.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 34;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
        }

        private static void TabControl1_DrawItem(TabControl tabs, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tabs.TabPages.Count)
                return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bounds = e.Bounds;
            var backColor = selected ? Surface : System.Drawing.Color.FromArgb(226, 232, 240);
            var foreColor = selected ? Primary : Muted;

            using (var brush = new System.Drawing.SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, bounds);

            if (selected)
            {
                using (var brush = new System.Drawing.SolidBrush(Primary))
                    e.Graphics.FillRectangle(brush, bounds.Left + 18, bounds.Bottom - 3, bounds.Width - 36, 3);
            }

            var textBounds = new System.Drawing.Rectangle(bounds.X + 4, bounds.Y + 2, bounds.Width - 8, bounds.Height - 4);
            using (var tabFont = new System.Drawing.Font("Tahoma", 9F,
                selected ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular))
            {
                TextRenderer.DrawText(e.Graphics, tabs.TabPages[e.Index].Text,
                    tabFont, textBounds, foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
        }

        private static void ModernListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            var list = sender as ListBox;
            if (list == null)
                return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var backColor = selected ? System.Drawing.Color.FromArgb(219, 234, 254) : list.BackColor;
            var foreColor = selected ? System.Drawing.Color.FromArgb(30, 64, 175) : list.ForeColor;

            using (var brush = new System.Drawing.SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.Bounds);

            var item = list.Items[e.Index] as CodeItem;
            var text = item == null ? Convert.ToString(list.Items[e.Index]) : item.Title;
            if (item != null && list.Name == "lstSearchResults")
                text = item.Title + "  ·  " + item.Language + "  ·  " + item.Tag;

            var textBounds = new System.Drawing.Rectangle(e.Bounds.X + 8, e.Bounds.Y + 2, e.Bounds.Width - 16, e.Bounds.Height - 4);
            TextRenderer.DrawText(e.Graphics, text, list.Font, textBounds, foreColor,
                TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
        }


    }
}
