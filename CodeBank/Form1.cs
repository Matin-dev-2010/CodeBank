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

        private const string ErrorsCategory = "خطاها";
        private const string TutorialsCategory = "اموزشی";
        private const string TemplatesCategory = "کد اماده";

        public frmCodeBank()
        {
            InitializeComponent();

            _service = new CodeItemService(new CodeRepository());

            ConfigureUi();
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
            LoadDataGrid();
            LoadCategoryList(listErrors, ErrorsCategory);
            LoadCategoryList(listTutorials, TutorialsCategory);
            LoadCategoryList(listBoxTemplateCode, TemplatesCategory);
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
            var list = sender as ListBox;
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

            var item = dataGridView1.CurrentRow.DataBoundItem as CodeItem;
            if (item == null)
                return;

            if (!PrepareForNavigation())
                return;

            LoadItemIntoEditor(item);
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

            LoadItemIntoEditor(item);
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
