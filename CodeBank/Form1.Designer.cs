namespace CodeBank
{
    partial class frmCodeBank
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabpageInsert;
        private System.Windows.Forms.TabPage txttabpageErrors;
        private System.Windows.Forms.TabPage tabpageTutorials;
        private System.Windows.Forms.TabPage tabpageTemplateCode;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPublic;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateAt;

        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.RichTextBox txtcode;
        private System.Windows.Forms.ComboBox cmblan;
        private System.Windows.Forms.ComboBox cmbcat;
        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.CheckBox checkpubper;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.ListBox listErrors;
        private System.Windows.Forms.TextBox txtErrorTitle;
        private System.Windows.Forms.TextBox txtErrorDesc;
        private System.Windows.Forms.RichTextBox txtErrorCode;
        private System.Windows.Forms.TextBox txtErrorLang;
        private System.Windows.Forms.TextBox txtErrorTag;
        private System.Windows.Forms.CheckBox chkErrorPublic;
        private System.Windows.Forms.Button btnEditError;
        private System.Windows.Forms.Button btnDeleteError;

        private System.Windows.Forms.ListBox listTutorials;
        private System.Windows.Forms.TextBox txtTutorialTitle;
        private System.Windows.Forms.TextBox txtTutorialDesc;
        private System.Windows.Forms.RichTextBox txtTutorialCode;
        private System.Windows.Forms.TextBox txtTutorialLang;
        private System.Windows.Forms.TextBox txtTutorialTag;
        private System.Windows.Forms.CheckBox chkTutorialPublic;
        private System.Windows.Forms.Button btnEditTutorial;
        private System.Windows.Forms.Button btnDeleteTutorial;

        private System.Windows.Forms.ListBox listBoxTemplateCode;
        private System.Windows.Forms.TextBox txtTemplateCodeTitle;
        private System.Windows.Forms.TextBox txtTemplateCodeDesc;
        private System.Windows.Forms.RichTextBox txtTemplateCodeCode;
        private System.Windows.Forms.TextBox txtTemplateCodeLang;
        private System.Windows.Forms.TextBox txtTemplateCodeTag;
        private System.Windows.Forms.CheckBox chkTemplateCodePublic;
        private System.Windows.Forms.Button btnEditTemplate;
        private System.Windows.Forms.Button btnDeleteTemplate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageInsert = new System.Windows.Forms.TabPage();
            this.txttabpageErrors = new System.Windows.Forms.TabPage();
            this.tabpageTutorials = new System.Windows.Forms.TabPage();
            this.tabpageTemplateCode = new System.Windows.Forms.TabPage();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPublic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.txtname = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.RichTextBox();
            this.cmblan = new System.Windows.Forms.ComboBox();
            this.cmbcat = new System.Windows.Forms.ComboBox();
            this.txttag = new System.Windows.Forms.TextBox();
            this.checkpubper = new System.Windows.Forms.CheckBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.listErrors = new System.Windows.Forms.ListBox();
            this.txtErrorTitle = new System.Windows.Forms.TextBox();
            this.txtErrorDesc = new System.Windows.Forms.TextBox();
            this.txtErrorCode = new System.Windows.Forms.RichTextBox();
            this.txtErrorLang = new System.Windows.Forms.TextBox();
            this.txtErrorTag = new System.Windows.Forms.TextBox();
            this.chkErrorPublic = new System.Windows.Forms.CheckBox();
            this.btnEditError = new System.Windows.Forms.Button();
            this.btnDeleteError = new System.Windows.Forms.Button();

            this.listTutorials = new System.Windows.Forms.ListBox();
            this.txtTutorialTitle = new System.Windows.Forms.TextBox();
            this.txtTutorialDesc = new System.Windows.Forms.TextBox();
            this.txtTutorialCode = new System.Windows.Forms.RichTextBox();
            this.txtTutorialLang = new System.Windows.Forms.TextBox();
            this.txtTutorialTag = new System.Windows.Forms.TextBox();
            this.chkTutorialPublic = new System.Windows.Forms.CheckBox();
            this.btnEditTutorial = new System.Windows.Forms.Button();
            this.btnDeleteTutorial = new System.Windows.Forms.Button();

            this.listBoxTemplateCode = new System.Windows.Forms.ListBox();
            this.txtTemplateCodeTitle = new System.Windows.Forms.TextBox();
            this.txtTemplateCodeDesc = new System.Windows.Forms.TextBox();
            this.txtTemplateCodeCode = new System.Windows.Forms.RichTextBox();
            this.txtTemplateCodeLang = new System.Windows.Forms.TextBox();
            this.txtTemplateCodeTag = new System.Windows.Forms.TextBox();
            this.chkTemplateCodePublic = new System.Windows.Forms.CheckBox();
            this.btnEditTemplate = new System.Windows.Forms.Button();
            this.btnDeleteTemplate = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabpageInsert.SuspendLayout();
            this.txttabpageErrors.SuspendLayout();
            this.tabpageTutorials.SuspendLayout();
            this.tabpageTemplateCode.SuspendLayout();
            this.SuspendLayout();

            // Main TabControl
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 760);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Controls.Add(this.tabpageInsert);
            this.tabControl1.Controls.Add(this.txttabpageErrors);
            this.tabControl1.Controls.Add(this.tabpageTutorials);
            this.tabControl1.Controls.Add(this.tabpageTemplateCode);

            // Insert tab
            this.tabpageInsert.Text = "مدیریت کدها";
            this.tabpageInsert.Name = "tabpageInsert";
            this.tabpageInsert.Padding = new System.Windows.Forms.Padding(8);
            this.tabpageInsert.UseVisualStyleBackColor = true;

            // Insert labels
            System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label();
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(15, 15);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(40, 15);
            titleLabel.Text = "عنوان";

            System.Windows.Forms.Label languageLabel = new System.Windows.Forms.Label();
            languageLabel.AutoSize = true;
            languageLabel.Location = new System.Drawing.Point(300, 15);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new System.Drawing.Size(27, 15);
            languageLabel.Text = "زبان";

            System.Windows.Forms.Label categoryLabel = new System.Windows.Forms.Label();
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new System.Drawing.Point(465, 15);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new System.Drawing.Size(59, 15);
            categoryLabel.Text = "دسته‌بندی";

            System.Windows.Forms.Label tagLabel = new System.Windows.Forms.Label();
            tagLabel.AutoSize = true;
            tagLabel.Location = new System.Drawing.Point(630, 15);
            tagLabel.Name = "tagLabel";
            tagLabel.Size = new System.Drawing.Size(20, 15);
            tagLabel.Text = "تگ";

            System.Windows.Forms.Label descLabel = new System.Windows.Forms.Label();
            descLabel.AutoSize = true;
            descLabel.Location = new System.Drawing.Point(15, 75);
            descLabel.Name = "descLabel";
            descLabel.Size = new System.Drawing.Size(54, 15);
            descLabel.Text = "توضیحات";

            System.Windows.Forms.Label codeLabel = new System.Windows.Forms.Label();
            codeLabel.AutoSize = true;
            codeLabel.Location = new System.Drawing.Point(15, 180);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new System.Drawing.Size(22, 15);
            codeLabel.Text = "کد";

            this.txtname.Location = new System.Drawing.Point(15, 35);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(270, 23);

            this.cmblan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblan.Location = new System.Drawing.Point(300, 35);
            this.cmblan.Name = "cmblan";
            this.cmblan.Size = new System.Drawing.Size(150, 23);

            this.cmbcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcat.Location = new System.Drawing.Point(465, 35);
            this.cmbcat.Name = "cmbcat";
            this.cmbcat.Size = new System.Drawing.Size(150, 23);

            this.txttag.Location = new System.Drawing.Point(630, 35);
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(180, 23);

            this.txtdesc.Location = new System.Drawing.Point(15, 95);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(795, 65);
            this.txtdesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtcode.Location = new System.Drawing.Point(15, 200);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(795, 260);
            this.txtcode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.checkpubper.AutoSize = true;
            this.checkpubper.Checked = true;
            this.checkpubper.Location = new System.Drawing.Point(15, 475);
            this.checkpubper.Name = "checkpubper";
            this.checkpubper.Size = new System.Drawing.Size(55, 19);
            this.checkpubper.Text = "عمومی";

            this.btnsave.Location = new System.Drawing.Point(125, 468);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(140, 35);
            this.btnsave.Text = "ذخیره رکورد جدید";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnUpdate.Location = new System.Drawing.Point(275, 468);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 35);
            this.btnUpdate.Text = "بروزرسانی";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(395, 468);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 35);
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(495, 468);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.Text = "پاک کردن";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.Id, this.Title, this.Language, this.Category, this.isPublic, this.CreateAt});
            this.dataGridView1.Location = new System.Drawing.Point(15, 520);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1035, 190);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);

            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "شناسه";
            this.Id.Name = "Id";
            this.Id.Width = 70;

            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "عنوان";
            this.Title.Name = "Title";

            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "زبان";
            this.Language.Name = "Language";

            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "دسته‌بندی";
            this.Category.Name = "Category";

            this.isPublic.DataPropertyName = "IsPublic";
            this.isPublic.HeaderText = "عمومی";
            this.isPublic.Name = "isPublic";

            this.CreateAt.DataPropertyName = "CreateAt";
            this.CreateAt.HeaderText = "تاریخ ایجاد";
            this.CreateAt.Name = "CreateAt";

            this.tabpageInsert.Controls.Add(titleLabel);
            this.tabpageInsert.Controls.Add(this.txtname);
            this.tabpageInsert.Controls.Add(languageLabel);
            this.tabpageInsert.Controls.Add(this.cmblan);
            this.tabpageInsert.Controls.Add(categoryLabel);
            this.tabpageInsert.Controls.Add(this.cmbcat);
            this.tabpageInsert.Controls.Add(tagLabel);
            this.tabpageInsert.Controls.Add(this.txttag);
            this.tabpageInsert.Controls.Add(descLabel);
            this.tabpageInsert.Controls.Add(this.txtdesc);
            this.tabpageInsert.Controls.Add(codeLabel);
            this.tabpageInsert.Controls.Add(this.txtcode);
            this.tabpageInsert.Controls.Add(this.checkpubper);
            this.tabpageInsert.Controls.Add(this.btnsave);
            this.tabpageInsert.Controls.Add(this.btnUpdate);
            this.tabpageInsert.Controls.Add(this.btnDelete);
            this.tabpageInsert.Controls.Add(this.btnClear);
            this.tabpageInsert.Controls.Add(this.dataGridView1);

            // Errors tab
            this.txttabpageErrors.Text = "خطاها";
            this.txttabpageErrors.Name = "txttabpageErrors";
            this.txttabpageErrors.Padding = new System.Windows.Forms.Padding(8);
            this.txttabpageErrors.UseVisualStyleBackColor = true;

            // Tutorials tab
            this.tabpageTutorials.Text = "آموزشی";
            this.tabpageTutorials.Name = "tabpageTutorials";
            this.tabpageTutorials.Padding = new System.Windows.Forms.Padding(8);
            this.tabpageTutorials.UseVisualStyleBackColor = true;

            // Template tab
            this.tabpageTemplateCode.Text = "کد آماده";
            this.tabpageTemplateCode.Name = "tabpageTemplateCode";
            this.tabpageTemplateCode.Padding = new System.Windows.Forms.Padding(8);
            this.tabpageTemplateCode.UseVisualStyleBackColor = true;

            // Errors controls
            this.listErrors.Location = new System.Drawing.Point(8, 8);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(250, 620);
            this.listErrors.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.listErrors.DisplayMember = "Title";
            this.listErrors.ValueMember = "Id";
            this.listErrors.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);

            this.txtErrorTitle.Location = new System.Drawing.Point(275, 35);
            this.txtErrorTitle.Name = "txtErrorTitle";
            this.txtErrorTitle.Size = new System.Drawing.Size(300, 23);

            this.txtErrorLang.Location = new System.Drawing.Point(590, 35);
            this.txtErrorLang.Name = "txtErrorLang";
            this.txtErrorLang.Size = new System.Drawing.Size(180, 23);

            this.txtErrorDesc.Location = new System.Drawing.Point(275, 95);
            this.txtErrorDesc.Multiline = true;
            this.txtErrorDesc.Name = "txtErrorDesc";
            this.txtErrorDesc.Size = new System.Drawing.Size(495, 70);
            this.txtErrorDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtErrorCode.Location = new System.Drawing.Point(275, 200);
            this.txtErrorCode.Name = "txtErrorCode";
            this.txtErrorCode.Size = new System.Drawing.Size(495, 240);
            this.txtErrorCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtErrorTag.Location = new System.Drawing.Point(275, 475);
            this.txtErrorTag.Name = "txtErrorTag";
            this.txtErrorTag.Size = new System.Drawing.Size(200, 23);
            this.txtErrorTag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.chkErrorPublic.AutoSize = true;
            this.chkErrorPublic.Location = new System.Drawing.Point(500, 478);
            this.chkErrorPublic.Name = "chkErrorPublic";
            this.chkErrorPublic.Size = new System.Drawing.Size(55, 19);
            this.chkErrorPublic.Text = "عمومی";
            this.chkErrorPublic.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.btnEditError.Location = new System.Drawing.Point(590, 470);
            this.btnEditError.Name = "btnEditError";
            this.btnEditError.Size = new System.Drawing.Size(85, 35);
            this.btnEditError.Text = "ویرایش";
            this.btnEditError.UseVisualStyleBackColor = true;
            this.btnEditError.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            this.btnDeleteError.Location = new System.Drawing.Point(685, 470);
            this.btnDeleteError.Name = "btnDeleteError";
            this.btnDeleteError.Size = new System.Drawing.Size(85, 35);
            this.btnDeleteError.Text = "حذف";
            this.btnDeleteError.UseVisualStyleBackColor = true;
            this.btnDeleteError.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            System.Windows.Forms.Label errorTitleLabel = new System.Windows.Forms.Label();
            errorTitleLabel.AutoSize = true;
            errorTitleLabel.Location = new System.Drawing.Point(275, 15);
            errorTitleLabel.Text = "عنوان";

            System.Windows.Forms.Label errorLangLabel = new System.Windows.Forms.Label();
            errorLangLabel.AutoSize = true;
            errorLangLabel.Location = new System.Drawing.Point(590, 15);
            errorLangLabel.Text = "زبان";

            System.Windows.Forms.Label errorDescLabel = new System.Windows.Forms.Label();
            errorDescLabel.AutoSize = true;
            errorDescLabel.Location = new System.Drawing.Point(275, 75);
            errorDescLabel.Text = "توضیحات";

            System.Windows.Forms.Label errorCodeLabel = new System.Windows.Forms.Label();
            errorCodeLabel.AutoSize = true;
            errorCodeLabel.Location = new System.Drawing.Point(275, 180);
            errorCodeLabel.Text = "کد";

            System.Windows.Forms.Label errorTagLabel = new System.Windows.Forms.Label();
            errorTagLabel.AutoSize = true;
            errorTagLabel.Location = new System.Drawing.Point(275, 455);
            errorTagLabel.Text = "تگ";

            this.txttabpageErrors.Controls.Add(this.listErrors);
            this.txttabpageErrors.Controls.Add(errorTitleLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorTitle);
            this.txttabpageErrors.Controls.Add(errorLangLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorLang);
            this.txttabpageErrors.Controls.Add(errorDescLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorDesc);
            this.txttabpageErrors.Controls.Add(errorCodeLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorCode);
            this.txttabpageErrors.Controls.Add(errorTagLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorTag);
            this.txttabpageErrors.Controls.Add(this.chkErrorPublic);
            this.txttabpageErrors.Controls.Add(this.btnEditError);
            this.txttabpageErrors.Controls.Add(this.btnDeleteError);

            this.btnEditError.Click += new System.EventHandler(this.BtnEditError_Click);
            this.btnDeleteError.Click += new System.EventHandler(this.BtnDeleteError_Click);

            // Tutorials controls
            this.listTutorials.Location = new System.Drawing.Point(8, 8);
            this.listTutorials.Name = "listTutorials";
            this.listTutorials.Size = new System.Drawing.Size(250, 620);
            this.listTutorials.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.listTutorials.DisplayMember = "Title";
            this.listTutorials.ValueMember = "Id";
            this.listTutorials.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);

            this.txtTutorialTitle.Location = new System.Drawing.Point(275, 35);
            this.txtTutorialTitle.Name = "txtTutorialTitle";
            this.txtTutorialTitle.Size = new System.Drawing.Size(300, 23);

            this.txtTutorialLang.Location = new System.Drawing.Point(590, 35);
            this.txtTutorialLang.Name = "txtTutorialLang";
            this.txtTutorialLang.Size = new System.Drawing.Size(180, 23);

            this.txtTutorialDesc.Location = new System.Drawing.Point(275, 95);
            this.txtTutorialDesc.Multiline = true;
            this.txtTutorialDesc.Name = "txtTutorialDesc";
            this.txtTutorialDesc.Size = new System.Drawing.Size(495, 70);
            this.txtTutorialDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtTutorialCode.Location = new System.Drawing.Point(275, 200);
            this.txtTutorialCode.Name = "txtTutorialCode";
            this.txtTutorialCode.Size = new System.Drawing.Size(495, 240);
            this.txtTutorialCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtTutorialTag.Location = new System.Drawing.Point(275, 475);
            this.txtTutorialTag.Name = "txtTutorialTag";
            this.txtTutorialTag.Size = new System.Drawing.Size(200, 23);
            this.txtTutorialTag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.chkTutorialPublic.AutoSize = true;
            this.chkTutorialPublic.Location = new System.Drawing.Point(500, 478);
            this.chkTutorialPublic.Name = "chkTutorialPublic";
            this.chkTutorialPublic.Size = new System.Drawing.Size(55, 19);
            this.chkTutorialPublic.Text = "عمومی";
            this.chkTutorialPublic.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.btnEditTutorial.Location = new System.Drawing.Point(590, 470);
            this.btnEditTutorial.Name = "btnEditTutorial";
            this.btnEditTutorial.Size = new System.Drawing.Size(85, 35);
            this.btnEditTutorial.Text = "ویرایش";
            this.btnEditTutorial.UseVisualStyleBackColor = true;
            this.btnEditTutorial.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            this.btnDeleteTutorial.Location = new System.Drawing.Point(685, 470);
            this.btnDeleteTutorial.Name = "btnDeleteTutorial";
            this.btnDeleteTutorial.Size = new System.Drawing.Size(85, 35);
            this.btnDeleteTutorial.Text = "حذف";
            this.btnDeleteTutorial.UseVisualStyleBackColor = true;
            this.btnDeleteTutorial.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            System.Windows.Forms.Label tutorialTitleLabel = new System.Windows.Forms.Label();
            tutorialTitleLabel.AutoSize = true;
            tutorialTitleLabel.Location = new System.Drawing.Point(275, 15);
            tutorialTitleLabel.Text = "عنوان";

            System.Windows.Forms.Label tutorialLangLabel = new System.Windows.Forms.Label();
            tutorialLangLabel.AutoSize = true;
            tutorialLangLabel.Location = new System.Drawing.Point(590, 15);
            tutorialLangLabel.Text = "زبان";

            System.Windows.Forms.Label tutorialDescLabel = new System.Windows.Forms.Label();
            tutorialDescLabel.AutoSize = true;
            tutorialDescLabel.Location = new System.Drawing.Point(275, 75);
            tutorialDescLabel.Text = "توضیحات";

            System.Windows.Forms.Label tutorialCodeLabel = new System.Windows.Forms.Label();
            tutorialCodeLabel.AutoSize = true;
            tutorialCodeLabel.Location = new System.Drawing.Point(275, 180);
            tutorialCodeLabel.Text = "کد";

            System.Windows.Forms.Label tutorialTagLabel = new System.Windows.Forms.Label();
            tutorialTagLabel.AutoSize = true;
            tutorialTagLabel.Location = new System.Drawing.Point(275, 455);
            tutorialTagLabel.Text = "تگ";

            this.tabpageTutorials.Controls.Add(this.listTutorials);
            this.tabpageTutorials.Controls.Add(tutorialTitleLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTitle);
            this.tabpageTutorials.Controls.Add(tutorialLangLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialLang);
            this.tabpageTutorials.Controls.Add(tutorialDescLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialDesc);
            this.tabpageTutorials.Controls.Add(tutorialCodeLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialCode);
            this.tabpageTutorials.Controls.Add(tutorialTagLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTag);
            this.tabpageTutorials.Controls.Add(this.chkTutorialPublic);
            this.tabpageTutorials.Controls.Add(this.btnEditTutorial);
            this.tabpageTutorials.Controls.Add(this.btnDeleteTutorial);

            this.btnEditTutorial.Click += new System.EventHandler(this.BtnEditTutorial_Click);
            this.btnDeleteTutorial.Click += new System.EventHandler(this.BtnDeleteTutorial_Click);

            // Template controls
            this.listBoxTemplateCode.Location = new System.Drawing.Point(8, 8);
            this.listBoxTemplateCode.Name = "listBoxTemplateCode";
            this.listBoxTemplateCode.Size = new System.Drawing.Size(250, 620);
            this.listBoxTemplateCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.listBoxTemplateCode.DisplayMember = "Title";
            this.listBoxTemplateCode.ValueMember = "Id";
            this.listBoxTemplateCode.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);

            this.txtTemplateCodeTitle.Location = new System.Drawing.Point(275, 35);
            this.txtTemplateCodeTitle.Name = "txtTemplateCodeTitle";
            this.txtTemplateCodeTitle.Size = new System.Drawing.Size(300, 23);

            this.txtTemplateCodeLang.Location = new System.Drawing.Point(590, 35);
            this.txtTemplateCodeLang.Name = "txtTemplateCodeLang";
            this.txtTemplateCodeLang.Size = new System.Drawing.Size(180, 23);

            this.txtTemplateCodeDesc.Location = new System.Drawing.Point(275, 95);
            this.txtTemplateCodeDesc.Multiline = true;
            this.txtTemplateCodeDesc.Name = "txtTemplateCodeDesc";
            this.txtTemplateCodeDesc.Size = new System.Drawing.Size(495, 70);
            this.txtTemplateCodeDesc.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtTemplateCodeCode.Location = new System.Drawing.Point(275, 200);
            this.txtTemplateCodeCode.Name = "txtTemplateCodeCode";
            this.txtTemplateCodeCode.Size = new System.Drawing.Size(495, 240);
            this.txtTemplateCodeCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.txtTemplateCodeTag.Location = new System.Drawing.Point(275, 475);
            this.txtTemplateCodeTag.Name = "txtTemplateCodeTag";
            this.txtTemplateCodeTag.Size = new System.Drawing.Size(200, 23);
            this.txtTemplateCodeTag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.chkTemplateCodePublic.AutoSize = true;
            this.chkTemplateCodePublic.Location = new System.Drawing.Point(500, 478);
            this.chkTemplateCodePublic.Name = "chkTemplateCodePublic";
            this.chkTemplateCodePublic.Size = new System.Drawing.Size(55, 19);
            this.chkTemplateCodePublic.Text = "عمومی";
            this.chkTemplateCodePublic.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;

            this.btnEditTemplate.Location = new System.Drawing.Point(590, 470);
            this.btnEditTemplate.Name = "btnEditTemplate";
            this.btnEditTemplate.Size = new System.Drawing.Size(85, 35);
            this.btnEditTemplate.Text = "ویرایش";
            this.btnEditTemplate.UseVisualStyleBackColor = true;
            this.btnEditTemplate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            this.btnDeleteTemplate.Location = new System.Drawing.Point(685, 470);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(85, 35);
            this.btnDeleteTemplate.Text = "حذف";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;

            System.Windows.Forms.Label templateTitleLabel = new System.Windows.Forms.Label();
            templateTitleLabel.AutoSize = true;
            templateTitleLabel.Location = new System.Drawing.Point(275, 15);
            templateTitleLabel.Text = "عنوان";

            System.Windows.Forms.Label templateLangLabel = new System.Windows.Forms.Label();
            templateLangLabel.AutoSize = true;
            templateLangLabel.Location = new System.Drawing.Point(590, 15);
            templateLangLabel.Text = "زبان";

            System.Windows.Forms.Label templateDescLabel = new System.Windows.Forms.Label();
            templateDescLabel.AutoSize = true;
            templateDescLabel.Location = new System.Drawing.Point(275, 75);
            templateDescLabel.Text = "توضیحات";

            System.Windows.Forms.Label templateCodeLabel = new System.Windows.Forms.Label();
            templateCodeLabel.AutoSize = true;
            templateCodeLabel.Location = new System.Drawing.Point(275, 180);
            templateCodeLabel.Text = "کد";

            System.Windows.Forms.Label templateTagLabel = new System.Windows.Forms.Label();
            templateTagLabel.AutoSize = true;
            templateTagLabel.Location = new System.Drawing.Point(275, 455);
            templateTagLabel.Text = "تگ";

            this.tabpageTemplateCode.Controls.Add(this.listBoxTemplateCode);
            this.tabpageTemplateCode.Controls.Add(templateTitleLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTitle);
            this.tabpageTemplateCode.Controls.Add(templateLangLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeLang);
            this.tabpageTemplateCode.Controls.Add(templateDescLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeDesc);
            this.tabpageTemplateCode.Controls.Add(templateCodeLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeCode);
            this.tabpageTemplateCode.Controls.Add(templateTagLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTag);
            this.tabpageTemplateCode.Controls.Add(this.chkTemplateCodePublic);
            this.tabpageTemplateCode.Controls.Add(this.btnEditTemplate);
            this.tabpageTemplateCode.Controls.Add(this.btnDeleteTemplate);

            this.btnEditTemplate.Click += new System.EventHandler(this.BtnEditTemplate_Click);
            this.btnDeleteTemplate.Click += new System.EventHandler(this.BtnDeleteTemplate_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 760);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "frmCodeBank";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeBank - مدیریت کدها";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.tabpageInsert.ResumeLayout(false);
            this.tabpageInsert.PerformLayout();
            this.txttabpageErrors.ResumeLayout(false);
            this.txttabpageErrors.PerformLayout();
            this.tabpageTutorials.ResumeLayout(false);
            this.tabpageTutorials.PerformLayout();
            this.tabpageTemplateCode.ResumeLayout(false);
            this.tabpageTemplateCode.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
