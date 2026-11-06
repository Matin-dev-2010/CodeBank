using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CodeBank.Data;
using CodeBank.Models;
using CodeBank.Services;
using CodeBank.UI;

namespace CodeBank
{
    public partial class frmCodeBank : Form
    {
        private readonly CodeItemService _service;
        private long? _editingId;
        private bool _isDirty;
        private bool _isLoading;
        private long? _selectedGridItemId;
        private long? _selectedSearchItemId;
        private TextBox _searchTextBox;
        private ListBox _searchResultsList;
        private System.Windows.Forms.Panel _searchPanel;

        private const string ErrorsCategory = "خطاها";
        private const string TutorialsCategory = "اموزشی";
        private const string TemplatesCategory = "کد اماده";

        public frmCodeBank()
        {
            InitializeComponent();

            _service = new CodeItemService(new CodeRepository());

            ConfigureUi();
            InitializeSearchUi();
            ConfigureCopyButtons();
            InitializeModernShell();
            WireEditorDirtyTracking();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseInitializer.Initialize();

                LoadLanguages();
                LoadCategories();
                RefreshAllData();
                ClearEditor(false);
            }
            catch (Exception ex)
            {
                ShowError("راه‌اندازی برنامه", ex);
            }
        }

        private System.Windows.Forms.Label CreateLabel(string text, int x, int y)
        {
            return new System.Windows.Forms.Label
            {
                AutoSize = true,
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Margin = new System.Windows.Forms.Padding(2)
            };
        }

        private void SetupCategoryTab(
            System.Windows.Forms.TabPage tab,
            System.Windows.Forms.ListBox list,
            System.Windows.Forms.TextBox title,
            System.Windows.Forms.TextBox description,
            System.Windows.Forms.RichTextBox code,
            System.Windows.Forms.TextBox language,
            System.Windows.Forms.TextBox tag,
            System.Windows.Forms.CheckBox isPublic,
            System.Windows.Forms.Button edit,
            System.Windows.Forms.Button delete)
        {
            tab.Padding = new System.Windows.Forms.Padding(8);
            list.Location = new System.Drawing.Point(8, 8);
            list.Size = new System.Drawing.Size(250, 600);
            list.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            list.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);

            var titleLabel = CreateLabel("عنوان", 275, 15);
            title.Location = new System.Drawing.Point(275, 35);
            title.Size = new System.Drawing.Size(300, 25);

            var languageLabel = CreateLabel("زبان", 590, 15);
            language.Location = new System.Drawing.Point(590, 35);
            language.Size = new System.Drawing.Size(180, 25);

            var descriptionLabel = CreateLabel("توضیحات", 275, 75);
            description.Location = new System.Drawing.Point(275, 95);
            description.Size = new System.Drawing.Size(495, 70);
            description.Multiline = true;

            var codeLabel = CreateLabel("کد", 275, 180);
            code.Location = new System.Drawing.Point(275, 200);
            code.Size = new System.Drawing.Size(495, 240);
            code.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            var tagLabel = CreateLabel("تگ", 275, 455);
            tag.Location = new System.Drawing.Point(275, 475);
            tag.Size = new System.Drawing.Size(200, 25);
            tag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            isPublic.Text = "عمومی";
            isPublic.Location = new System.Drawing.Point(500, 478);
            isPublic.AutoSize = true;
            isPublic.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            edit.Text = "ویرایش";
            edit.Location = new System.Drawing.Point(590, 470);
            edit.Size = new System.Drawing.Size(85, 35);
            edit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            delete.Text = "حذف";
            delete.Location = new System.Drawing.Point(685, 470);
            delete.Size = new System.Drawing.Size(85, 35);
            delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            tab.Controls.Add(list);
            tab.Controls.Add(titleLabel);
            tab.Controls.Add(title);
            tab.Controls.Add(languageLabel);
            tab.Controls.Add(language);
            tab.Controls.Add(descriptionLabel);
            tab.Controls.Add(description);
            tab.Controls.Add(codeLabel);
            tab.Controls.Add(code);
            tab.Controls.Add(tagLabel);
            tab.Controls.Add(tag);
            tab.Controls.Add(isPublic);
            tab.Controls.Add(edit);
            tab.Controls.Add(delete);
        }

        private void ConfigureUi()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtErrorCode.ReadOnly = true;
            txtErrorDesc.ReadOnly = true;
            txtErrorTitle.ReadOnly = true;
            txtErrorLang.ReadOnly = true;
            txtErrorTag.ReadOnly = true;
            chkErrorPublic.Enabled = false;

            txtTutorialCode.ReadOnly = true;
            txtTutorialDesc.ReadOnly = true;
            txtTutorialTitle.ReadOnly = true;
            txtTutorialLang.ReadOnly = true;
            txtTutorialTag.ReadOnly = true;
            chkTutorialPublic.Enabled = false;

            txtTemplateCodeCode.ReadOnly = true;
            txtTemplateCodeDesc.ReadOnly = true;
            txtTemplateCodeTitle.ReadOnly = true;
            txtTemplateCodeLang.ReadOnly = true;
            txtTemplateCodeTag.ReadOnly = true;
            chkTemplateCodePublic.Enabled = false;
        }


        private void InitializeSearchUi()
        {
            _searchPanel = new System.Windows.Forms.Panel
            {
                Name = "pnlSearch",
                Location = new System.Drawing.Point(710, 12),
                Size = new System.Drawing.Size(190, 420),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            var searchLabel = CreateLabel("جستجوی کدها", 10, 12);
            searchLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            searchLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);

            _searchTextBox = new TextBox
            {
                Name = "txtSearchSnippets",
                Location = new System.Drawing.Point(10, 38),
                Size = new System.Drawing.Size(166, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            _searchResultsList = new ListBox
            {
                Name = "lstSearchResults",
                Location = new System.Drawing.Point(10, 76),
                Size = new System.Drawing.Size(166, 330),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                FormattingEnabled = true,
                IntegralHeight = false
            };
            _searchResultsList.Format += SearchResults_Format;
            _searchTextBox.TextChanged += SearchTextBox_TextChanged;
            _searchResultsList.SelectedIndexChanged += SearchResults_SelectedIndexChanged;

            _searchPanel.Controls.Add(searchLabel);
            _searchPanel.Controls.Add(_searchTextBox);
            _searchPanel.Controls.Add(_searchResultsList);
            tabpageInsert.Controls.Add(_searchPanel);

            txtdesc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            txtcode.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            tabpageInsert.Resize += MainTab_Resize;
            UpdateMainEditorLayout();
            _searchPanel.BringToFront();
        }

        private void MainTab_Resize(object sender, EventArgs e)
        {
            UpdateMainEditorLayout();
        }

        private void UpdateMainEditorLayout()
        {
            if (_searchPanel == null)
                return;

            _searchPanel.Left = tabpageInsert.ClientSize.Width - _searchPanel.Width - 12;
            var editorWidth = Math.Max(260, _searchPanel.Left - txtdesc.Left - 24);
            txtdesc.Width = editorWidth;
            txtcode.Width = editorWidth;
        }

        private void SearchResults_Format(object sender, ListControlConvertEventArgs e)
        {
            var item = e.ListItem as CodeItem;
            if (item != null)
                e.Value = string.Format("{0}  |  {1}  |  {2}",
                    item.Title, item.Language, item.Tag);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshSearchResults();
        }

        private void RefreshSearchResults()
        {
            if (_searchResultsList == null)
                return;

            var previousLoadingState = _isLoading;
            _isLoading = true;
            try
            {
                _searchResultsList.DataSource = null;
                var query = _searchTextBox.Text.Trim();
                if (query.Length == 0)
                    return;

                _searchResultsList.DataSource = _service.Search(query);
            }
            catch (Exception ex)
            {
                ShowError("جستجوی کدها", ex);
            }
            finally
            {
                _isLoading = previousLoadingState;
            }
        }

        private void SearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
                return;

            var selected = _searchResultsList.SelectedItem as CodeItem;
            if (selected == null)
                return;

            var previousId = _selectedSearchItemId;
            if (!PrepareForNavigation())
            {
                RestoreSearchSelection(previousId);
                return;
            }

            try
            {
                var item = _service.GetById(selected.Id);
                if (item == null)
                {
                    RefreshSearchResults();
                    return;
                }

                _selectedSearchItemId = item.Id;

                if (item.Category == ErrorsCategory)
                    OpenSearchResultInCategory(item, txttabpageErrors, listErrors);
                else if (item.Category == TutorialsCategory)
                    OpenSearchResultInCategory(item, tabpageTutorials, listTutorials);
                else if (item.Category == TemplatesCategory)
                    OpenSearchResultInCategory(item, tabpageTemplateCode, listBoxTemplateCode);
                else
                {
                    LoadItemIntoEditor(item);
                    _selectedGridItemId = item.Id;
                    RestoreGridSelection(item.Id);
                    tabControl1.SelectedTab = tabpageInsert;
                }
            }
            catch (Exception ex)
            {
                ShowError("باز کردن نتیجه جستجو", ex);
                RestoreSearchSelection(previousId);
            }
        }

        private void OpenSearchResultInCategory(CodeItem item, TabPage tab, ListBox list)
        {
            tabControl1.SelectedTab = tab;
            var wasLoading = _isLoading;
            _isLoading = true;
            try
            {
                list.SelectedIndex = -1;
                for (var i = 0; i < list.Items.Count; i++)
                {
                    var listItem = list.Items[i] as CodeItem;
                    if (listItem != null && listItem.Id == item.Id)
                    {
                        list.SelectedIndex = i;
                        break;
                    }
                }
            }
            finally
            {
                _isLoading = wasLoading;
            }

            ShowCategoryItem(item,
                tab == txttabpageErrors ? txtErrorTitle : tab == tabpageTutorials ? txtTutorialTitle : txtTemplateCodeTitle,
                tab == txttabpageErrors ? txtErrorDesc : tab == tabpageTutorials ? txtTutorialDesc : txtTemplateCodeDesc,
                tab == txttabpageErrors ? txtErrorCode : tab == tabpageTutorials ? txtTutorialCode : txtTemplateCodeCode,
                tab == txttabpageErrors ? txtErrorLang : tab == tabpageTutorials ? txtTutorialLang : txtTemplateCodeLang,
                tab == txttabpageErrors ? txtErrorTag : tab == tabpageTutorials ? txtTutorialTag : txtTemplateCodeTag,
                tab == txttabpageErrors ? chkErrorPublic : tab == tabpageTutorials ? chkTutorialPublic : chkTemplateCodePublic);
        }

        private void RestoreSearchSelection(long? itemId)
        {
            var wasLoading = _isLoading;
            _isLoading = true;
            try
            {
                _searchResultsList.ClearSelected();
                if (!itemId.HasValue)
                    return;

                for (var i = 0; i < _searchResultsList.Items.Count; i++)
                {
                    var item = _searchResultsList.Items[i] as CodeItem;
                    if (item != null && item.Id == itemId.Value)
                    {
                        _searchResultsList.SelectedIndex = i;
                        return;
                    }
                }
            }
            finally
            {
                _isLoading = wasLoading;
            }
        }

        private void ConfigureCopyButtons()
        {
            AddCopyButton(txtname);
            AddCopyButton(cmblan);
            AddCopyButton(cmbcat);
            AddCopyButton(txttag);
            AddCopyButton(txtdesc);
            AddCopyButton(txtcode);

            AddCopyButton(txtErrorTitle);
            AddCopyButton(txtErrorLang);
            AddCopyButton(txtErrorDesc);
            AddCopyButton(txtErrorCode);
            AddCopyButton(txtErrorTag);

            AddCopyButton(txtTutorialTitle);
            AddCopyButton(txtTutorialLang);
            AddCopyButton(txtTutorialDesc);
            AddCopyButton(txtTutorialCode);
            AddCopyButton(txtTutorialTag);

            AddCopyButton(txtTemplateCodeTitle);
            AddCopyButton(txtTemplateCodeLang);
            AddCopyButton(txtTemplateCodeDesc);
            AddCopyButton(txtTemplateCodeCode);
            AddCopyButton(txtTemplateCodeTag);
        }

        private void AddCopyButton(Control target)
        {
            var originalRight = target.Right;
            var button = new Button
            {
                Text = "کپی",
                Size = new System.Drawing.Size(36, 24),
                Location = new System.Drawing.Point(originalRight - 38, target.Top),
                Anchor = (target.Anchor & AnchorStyles.Right) != 0
                    ? AnchorStyles.Top | AnchorStyles.Right
                    : AnchorStyles.Top | AnchorStyles.Left,
                TabStop = false,
                Font = new System.Drawing.Font("Tahoma", 7F),
                UseVisualStyleBackColor = true
            };

            target.Width = Math.Max(45, target.Width - 40);
            button.Click += delegate { CopyControlText(target); };
            target.Parent.Controls.Add(button);
            button.BringToFront();
        }

        private void CopyControlText(Control target)
        {
            var value = target.Text;
            if (string.IsNullOrEmpty(value))
                return;

            try
            {
                Clipboard.SetText(value);
            }
            catch (Exception ex)
            {
                ShowError("کپی کردن متن", ex);
            }
        }


        private void InitializeModernShell()
        {
            Text = "CodeBank | مدیریت هوشمند کدها";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new System.Drawing.Size(1280, 860);
            MinimumSize = new System.Drawing.Size(1100, 760);
            BackColor = CodeBankTheme.Background;
            ForeColor = UiInk;
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);

            tabControl1.Dock = DockStyle.Fill;

            var header = new System.Windows.Forms.Panel
            {
                Name = "pnlAppHeader",
                Dock = DockStyle.Top,
                Height = 76,
                BackColor = System.Drawing.Color.FromArgb(15, 23, 42),
                Padding = new Padding(22, 8, 22, 8)
            };

            var brandPanel = new System.Windows.Forms.Panel
            {
                Dock = DockStyle.Right,
                Width = 300,
                BackColor = System.Drawing.Color.Transparent
            };

            var brandTitle = new Label
            {
                Text = "CodeBank",
                Dock = DockStyle.Top,
                Height = 36,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold)
            };

            var brandSubtitle = new Label
            {
                Text = "کتابخانه شخصی قطعه‌کدها",
                Dock = DockStyle.Top,
                Height = 23,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                ForeColor = System.Drawing.Color.FromArgb(148, 163, 184),
                Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular)
            };

            brandPanel.Controls.Add(brandSubtitle);
            brandPanel.Controls.Add(brandTitle);

            var headerMeta = new Label
            {
                Text = "LOCAL LIBRARY   •   SQLITE",
                Dock = DockStyle.Left,
                Width = 240,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                ForeColor = System.Drawing.Color.FromArgb(147, 197, 253),
                Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold)
            };

            header.Controls.Add(brandPanel);
            header.Controls.Add(headerMeta);

            var status = new StatusStrip
            {
                Name = "statusStripMain",
                Dock = DockStyle.Bottom,
                SizingGrip = false,
                BackColor = System.Drawing.Color.White,
                ForeColor = CodeBankTheme.Muted,
                Padding = new Padding(12, 3, 12, 3)
            };
            status.Items.Add(new ToolStripStatusLabel("آماده به کار")
            {
                ForeColor = System.Drawing.Color.FromArgb(15, 118, 110),
                Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold)
            });
            status.Items.Add(new ToolStripStatusLabel("  •  اطلاعات به‌صورت محلی ذخیره می‌شوند")
            {
                ForeColor = CodeBankTheme.Muted,
                Spring = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            });
            status.Items.Add(new ToolStripStatusLabel("CodeBank")
            {
                ForeColor = UiMuted
            });

            Controls.Add(header);
            Controls.Add(status);
            Controls.SetChildIndex(header, 0);
            Controls.SetChildIndex(status, 1);
            Controls.SetChildIndex(tabControl1, 2);

            CodeBankTheme.Apply(this, tabControl1);

            brandTitle.ForeColor = System.Drawing.Color.White;
            brandTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            brandSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            brandSubtitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            headerMeta.ForeColor = System.Drawing.Color.FromArgb(147, 197, 253);
            headerMeta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        }

        private static void ApplyVisualTheme(Control root)
        {
            foreach (Control control in root.Controls)
            {
                bool insideHeader = IsInsideHeader(control);

                if (control is TabPage)
                {
                    control.BackColor = CodeBankTheme.Background;
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

        private void WireEditorDirtyTracking()
        {
            txtname.TextChanged += EditorChanged;
            txtdesc.TextChanged += EditorChanged;
            txtcode.TextChanged += EditorChanged;
            txttag.TextChanged += EditorChanged;
            cmblan.SelectedIndexChanged += EditorChanged;
            cmbcat.SelectedIndexChanged += EditorChanged;
            checkpubper.CheckedChanged += EditorChanged;
        }

        private void EditorChanged(object sender, EventArgs e)
        {
            if (!_isLoading)
                _isDirty = true;
        }

        private void LoadLanguages()
        {
            cmblan.Items.Clear();
            cmblan.Items.AddRange(new object[]
            {
                "C#", "JavaScript", "TypeScript", "Python", "Java",
                "PHP", "Go", "Rust", "C++"
            });
        }

        private void LoadCategories()
        {
            cmbcat.Items.Clear();
            cmbcat.Items.AddRange(new object[]
            {
                ErrorsCategory, TutorialsCategory, TemplatesCategory,
                "الگوها", "الگوریتم", "سایر"
            });
        }

        private void RefreshAllData()
        {
            var wasLoading = _isLoading;
            _isLoading = true;
            try
            {
                LoadDataGrid();
                LoadCategoryList(listErrors, ErrorsCategory);
                LoadCategoryList(listTutorials, TutorialsCategory);
                LoadCategoryList(listBoxTemplateCode, TemplatesCategory);
                RefreshSearchResults();
            }
            finally
            {
                _isLoading = wasLoading;
            }
        }

        private void LoadDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _service.GetAll();
        }

        private void LoadCategoryList(ListBox list, string category)
        {
            list.DataSource = null;
            list.DisplayMember = "Title";
            list.ValueMember = "Id";
            list.DataSource = _service.GetByCategory(category);
        }

        private CodeItem GetSelectedCategoryItem(ListBox list)
        {
            return list.SelectedItem as CodeItem;
        }

        private void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListBox list))
                return;

            if (list == listErrors)
                ListErrors_SelectedIndexChanged(sender, e);
            else if (list == listTutorials)
                ListTutorials_SelectedIndexChanged(sender, e);
            else if (list == listBoxTemplateCode)
                ListBoxTemplateCode_SelectedIndexChanged(sender, e);
        }

        private void ListErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCategoryItem(GetSelectedCategoryItem(listErrors),
                txtErrorTitle, txtErrorDesc, txtErrorCode, txtErrorLang, txtErrorTag, chkErrorPublic);
        }

        private void ListTutorials_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCategoryItem(GetSelectedCategoryItem(listTutorials),
                txtTutorialTitle, txtTutorialDesc, txtTutorialCode, txtTutorialLang, txtTutorialTag, chkTutorialPublic);
        }

        private void ListBoxTemplateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCategoryItem(GetSelectedCategoryItem(listBoxTemplateCode),
                txtTemplateCodeTitle, txtTemplateCodeDesc, txtTemplateCodeCode, txtTemplateCodeLang, txtTemplateCodeTag, chkTemplateCodePublic);
        }

        private void ShowCategoryItem(
            CodeItem item,
            TextBox title,
            TextBox description,
            RichTextBox code,
            TextBox language,
            TextBox tag,
            CheckBox isPublic)
        {
            if (item == null)
            {
                title.Clear();
                description.Clear();
                code.Clear();
                language.Clear();
                tag.Clear();
                isPublic.Checked = false;
                return;
            }

            title.Text = item.Title;
            description.Text = item.Description;
            code.Text = item.Code;
            language.Text = item.Language;
            tag.Text = item.Tag;
            isPublic.Checked = item.IsPublic;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoading || dataGridView1.CurrentRow == null)
                return;

            if (!(dataGridView1.CurrentRow.DataBoundItem is CodeItem item))
                return;

            if (!_isDirty && _editingId == item.Id)
            {
                _selectedGridItemId = item.Id;
                return;
            }

            if (!PrepareForNavigation())
            {
                RestoreGridSelection(_selectedGridItemId);
                return;
            }

            var refreshedItem = _service.GetById(item.Id);
            if (refreshedItem == null)
            {
                RestoreGridSelection(_selectedGridItemId);
                return;
            }

            _selectedGridItemId = refreshedItem.Id;
            RestoreGridSelection(refreshedItem.Id);
            LoadItemIntoEditor(refreshedItem);
        }

        private void RestoreGridSelection(long? itemId)
        {
            var wasLoading = _isLoading;
            _isLoading = true;
            try
            {
                dataGridView1.ClearSelection();

                if (!itemId.HasValue)
                {
                    dataGridView1.CurrentCell = null;
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var item = row.DataBoundItem as CodeItem;
                    if (item == null || item.Id != itemId.Value)
                        continue;

                    row.Selected = true;
                    if (dataGridView1.Columns.Count > 0)
                        dataGridView1.CurrentCell = row.Cells[0];
                    return;
                }

                dataGridView1.CurrentCell = null;
            }
            finally
            {
                _isLoading = wasLoading;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveNewItem();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!_editingId.HasValue)
            {
                MessageBox.Show("ابتدا یک رکورد را برای ویرایش انتخاب کنید.", "ویرایش",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var item = ReadEditor();
                item.Id = _editingId.Value;
                _service.Update(item);

                MessageBox.Show("رکورد با موفقیت بروزرسانی شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isDirty = false;
                RefreshAllData();
                ClearEditor(false);
            }
            catch (Exception ex)
            {
                ShowError("بروزرسانی رکورد", ex);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!_editingId.HasValue)
            {
                MessageBox.Show("ابتدا یک رکورد را انتخاب کنید.", "حذف",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!FormStateService.ConfirmDelete())
                return;

            try
            {
                _service.Delete(_editingId.Value);
                _isDirty = false;
                RefreshAllData();
                ClearEditor(false);

                MessageBox.Show("رکورد با موفقیت حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("حذف رکورد", ex);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearEditor(true);
        }

        private void BtnEditError_Click(object sender, EventArgs e)
        {
            EditCategoryItem(listErrors);
        }

        private void BtnDeleteError_Click(object sender, EventArgs e)
        {
            DeleteCategoryItem(listErrors);
        }

        private void BtnEditTutorial_Click(object sender, EventArgs e)
        {
            EditCategoryItem(listTutorials);
        }

        private void BtnDeleteTutorial_Click(object sender, EventArgs e)
        {
            DeleteCategoryItem(listTutorials);
        }

        private void BtnEditTemplate_Click(object sender, EventArgs e)
        {
            EditCategoryItem(listBoxTemplateCode);
        }

        private void BtnDeleteTemplate_Click(object sender, EventArgs e)
        {
            DeleteCategoryItem(listBoxTemplateCode);
        }

        private void EditCategoryItem(ListBox list)
        {
            var item = GetSelectedCategoryItem(list);
            if (item == null)
            {
                MessageBox.Show("یک رکورد را انتخاب کنید.", "ویرایش",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!PrepareForNavigation())
                return;

            var refreshedItem = _service.GetById(item.Id);
            if (refreshedItem == null)
                return;

            _selectedGridItemId = refreshedItem.Id;
            RestoreGridSelection(refreshedItem.Id);
            LoadItemIntoEditor(refreshedItem);
            tabControl1.SelectedTab = tabpageInsert;
            txtname.Focus();
        }

        private void DeleteCategoryItem(ListBox list)
        {
            var item = GetSelectedCategoryItem(list);
            if (item == null)
            {
                MessageBox.Show("یک رکورد را انتخاب کنید.", "حذف",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!FormStateService.ConfirmDelete())
                return;

            try
            {
                _service.Delete(item.Id);
                _isDirty = false;
                RefreshAllData();
                ClearEditor(false);

                MessageBox.Show("رکورد با موفقیت حذف شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("حذف رکورد", ex);
            }
        }

        private void SaveNewItem()
        {
            try
            {
                var item = ReadEditor();
                _service.Create(item);

                MessageBox.Show("رکورد با موفقیت ذخیره شد.", "موفق",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _isDirty = false;
                RefreshAllData();
                ClearEditor(false);
            }
            catch (Exception ex)
            {
                ShowError("ذخیره رکورد", ex);
            }
        }

        private CodeItem ReadEditor()
        {
            return new CodeItem
            {
                Title = txtname.Text.Trim(),
                Description = txtdesc.Text.Trim(),
                Code = txtcode.Text,
                Language = cmblan.SelectedItem == null ? string.Empty : cmblan.SelectedItem.ToString(),
                Category = cmbcat.SelectedItem == null ? string.Empty : cmbcat.SelectedItem.ToString(),
                Tag = txttag.Text.Trim(),
                IsPublic = checkpubper.Checked
            };
        }

        private void LoadItemIntoEditor(CodeItem item)
        {
            if (item == null)
                return;

            _isLoading = true;
            try
            {
                _editingId = item.Id;
                txtname.Text = item.Title;
                txtdesc.Text = item.Description;
                txtcode.Text = item.Code;
                txttag.Text = item.Tag;
                checkpubper.Checked = item.IsPublic;
                cmblan.SelectedItem = item.Language;
                cmbcat.SelectedItem = item.Category;
                UpdateEditorButtons();
                _isDirty = false;
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void ClearEditor(bool askForUnsavedChanges)
        {
            if (askForUnsavedChanges && _isDirty)
            {
                var result = FormStateService.ConfirmDiscardChanges();

                if (result == DialogResult.Cancel)
                    return;

                if (result == DialogResult.Yes)
                {
                    if (!SaveCurrentItemForClear())
                        return;
                }
            }

            _isLoading = true;
            try
            {
                _editingId = null;
                _selectedGridItemId = null;
                txtname.Clear();
                txtdesc.Clear();
                txtcode.Clear();
                txttag.Clear();
                cmblan.SelectedIndex = -1;
                cmbcat.SelectedIndex = -1;
                checkpubper.Checked = true;
                dataGridView1.ClearSelection();
                txtname.Focus();
                _isDirty = false;
                UpdateEditorButtons();
            }
            finally
            {
                _isLoading = false;
            }
        }

        private bool SaveCurrentItemForClear()
        {
            try
            {
                if (_editingId.HasValue)
                {
                    var item = ReadEditor();
                    item.Id = _editingId.Value;
                    _service.Update(item);
                }
                else
                {
                    _service.Create(ReadEditor());
                }

                _isDirty = false;
                RefreshAllData();
                return true;
            }
            catch (Exception ex)
            {
                ShowError("ذخیره تغییرات", ex);
                return false;
            }
        }

        private bool PrepareForNavigation()
        {
            if (!_isDirty)
                return true;

            var result = FormStateService.ConfirmDiscardChanges();

            if (result == DialogResult.Cancel)
                return false;

            if (result == DialogResult.No)
                return true;

            return SaveCurrentItemForClear();
        }

        private void UpdateEditorButtons()
        {
            btnUpdate.Enabled = _editingId.HasValue;
            btnDelete.Enabled = _editingId.HasValue;
            btnsave.Enabled = !_editingId.HasValue;
        }

        private void ShowError(string operation, Exception ex)
        {
            MessageBox.Show(
                "خطا در " + operation + Environment.NewLine + Environment.NewLine + ex.Message,
                "خطا",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isDirty)
            {
                var result = FormStateService.ConfirmDiscardChanges();

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (result == DialogResult.Yes && !SaveCurrentItemForClear())
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }
    }
}
