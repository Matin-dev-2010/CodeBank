using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CodeBank.Data;
using CodeBank.Models;
using CodeBank.Services;

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
            WireEditorDirtyTracking();
            CodeBankTheme.Apply(this);
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
            var searchLabel = CreateLabel("جستجوی کدها", 710, 13);
            _searchTextBox = new TextBox
            {
                Name = "txtSearchSnippets",
                Location = new System.Drawing.Point(710, 32),
                Size = new System.Drawing.Size(190, 25),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            _searchResultsList = new ListBox
            {
                Name = "lstSearchResults",
                Location = new System.Drawing.Point(710, 66),
                Size = new System.Drawing.Size(190, 333),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right,
                FormattingEnabled = true,
                IntegralHeight = false
            };
            _searchResultsList.Format += SearchResults_Format;
            _searchTextBox.TextChanged += SearchTextBox_TextChanged;
            _searchResultsList.SelectedIndexChanged += SearchResults_SelectedIndexChanged;

            tabpageInsert.Controls.Add(searchLabel);
            tabpageInsert.Controls.Add(_searchTextBox);
            tabpageInsert.Controls.Add(_searchResultsList);
            searchLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchLabel.BringToFront();
            _searchTextBox.BringToFront();
            _searchResultsList.BringToFront();
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
