using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CodeBank
{
    internal static class CodeBankTheme
    {
        private static readonly Color Canvas = Color.FromArgb(244, 247, 251);
        private static readonly Color Surface = Color.White;
        private static readonly Color Primary = Color.FromArgb(37, 99, 235);
        private static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
        private static readonly Color Text = Color.FromArgb(30, 41, 59);
        private static readonly Color Muted = Color.FromArgb(100, 116, 139);
        private static readonly Color Border = Color.FromArgb(226, 232, 240);
        private static readonly Color Danger = Color.FromArgb(220, 38, 38);
        private static readonly Color DangerHover = Color.FromArgb(185, 28, 28);

        public static void Apply(Form form)
        {
            if (form == null) return;

            form.SuspendLayout();
            try
            {
                form.BackColor = Canvas;
                form.ForeColor = Text;
                form.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimumSize = new Size(900, 650);
                form.Size = new Size(1180, 820);
                form.AutoScaleMode = AutoScaleMode.Font;

                ApplyToControls(form);

                var tabs = FindTabControl(form);
                if (tabs != null)
                {
                    tabs.DrawMode = TabDrawMode.OwnerDrawFixed;
                    tabs.ItemSize = new Size(125, 38);
                    tabs.SizeMode = TabSizeMode.Fixed;
                    tabs.Padding = new Point(18, 5);
                    tabs.DrawItem -= DrawTab;
                    tabs.DrawItem += DrawTab;
                    tabs.BackColor = Canvas;
                }
            }
            finally
            {
                form.ResumeLayout(true);
            }
        }

        private static void ApplyToControls(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                ApplyControl(child);
                ApplyToControls(child);
            }
        }

        private static void ApplyControl(Control control)
        {
            control.ForeColor = Text;

            if (control is TabPage)
            {
                control.BackColor = Canvas;
                control.Padding = new Padding(14);
            }
            else if (control is Panel || control is GroupBox)
            {
                control.BackColor = Canvas;
            }
            else if (control is DataGridView)
            {
                StyleGrid((DataGridView)control);
            }
            else if (control is Button)
            {
                StyleButton((Button)control);
            }
            else if (control is TextBoxBase)
            {
                var textControl = (TextBoxBase)control;
                textControl.BackColor = Surface;
                textControl.ForeColor = Text;
                textControl.BorderStyle = BorderStyle.FixedSingle;
                textControl.Font = IsCodeControl(control) ? new Font("Consolas", 10F) : new Font("Tahoma", 9F);
                if (control is RichTextBox)
                    ((RichTextBox)control).DetectUrls = false;
            }
            else if (control is ComboBox)
            {
                var combo = (ComboBox)control;
                combo.FlatStyle = FlatStyle.Flat;
                combo.BackColor = Surface;
                combo.ForeColor = Text;
                combo.Font = new Font("Tahoma", 9F);
            }
            else if (control is ListBox)
            {
                var list = (ListBox)control;
                list.BackColor = Surface;
                list.ForeColor = Text;
                list.BorderStyle = BorderStyle.FixedSingle;
                list.Font = new Font("Tahoma", 9F);
                list.IntegralHeight = false;
            }
            else if (control is CheckBox)
            {
                control.Font = new Font("Tahoma", 9F);
                control.ForeColor = Muted;
            }
            else if (control is Label)
            {
                control.Font = new Font("Tahoma", 9F, FontStyle.Regular);
                control.ForeColor = Muted;
            }

            if (control is TabControl)
                control.BackColor = Canvas;
        }

        private static bool IsCodeControl(Control control)
        {
            return control.Name.IndexOf("code", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static void StyleButton(Button button)
        {
            string caption = (button.Text ?? string.Empty).Trim();
            bool isDanger = caption.Contains("حذف") || caption.Contains("پاک");
            bool isPrimary = caption.Contains("ذخیره") || caption.Contains("ثبت") ||
                             caption.Contains("بروزرسانی") || caption.Contains("ویرایش");
            Color normal = isDanger ? Danger : (isPrimary ? Primary : Color.FromArgb(226, 232, 240));
            Color hover = isDanger ? DangerHover : (isPrimary ? PrimaryHover : Color.FromArgb(203, 213, 225));
            Color foreground = (isDanger || isPrimary) ? Color.White : Text;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = hover;
            button.FlatAppearance.MouseDownBackColor = hover;
            button.BackColor = normal;
            button.ForeColor = foreground;
            button.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Height = Math.Max(button.Height, 32);
            button.Padding = new Padding(10, 3, 10, 3);
            button.UseVisualStyleBackColor = false;
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Border;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(239, 244, 250);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Text;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersHeight = 42;
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = Text;
            grid.DefaultCellStyle.Font = new Font("Tahoma", 9F);
            grid.DefaultCellStyle.Padding = new Padding(7, 4, 7, 4);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 36;
            grid.RowHeadersVisible = false;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private static TabControl FindTabControl(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child is TabControl) return (TabControl)child;
                var nested = FindTabControl(child);
                if (nested != null) return nested;
            }
            return null;
        }

        private static void DrawTab(object sender, DrawItemEventArgs e)
        {
            var tabs = sender as TabControl;
            if (tabs == null || e.Index < 0 || e.Index >= tabs.TabPages.Count) return;

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Rectangle bounds = e.Bounds;
            bounds.Inflate(-2, -2);

            using (var brush = new SolidBrush(selected ? Surface : Canvas))
                e.Graphics.FillRectangle(brush, e.Bounds);

            if (selected)
            {
                using (var brush = new SolidBrush(Primary))
                    e.Graphics.FillRectangle(brush, new Rectangle(bounds.X + 8, bounds.Bottom - 3, bounds.Width - 16, 3));
            }

            using (var tabFont = new Font("Tahoma", 9F, selected ? FontStyle.Bold : FontStyle.Regular))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    tabs.TabPages[e.Index].Text,
                    tabFont,
                    bounds,
                    selected ? Primary : Muted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
        }
    }
}