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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageInsert = new System.Windows.Forms.TabPage();
            this.titleLabel = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.cmblan = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.cmbcat = new System.Windows.Forms.ComboBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.txttag = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.RichTextBox();
            this.checkpubper = new System.Windows.Forms.CheckBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPublic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txttabpageErrors = new System.Windows.Forms.TabPage();
            this.listErrors = new System.Windows.Forms.ListBox();
            this.errorTitleLabel = new System.Windows.Forms.Label();
            this.txtErrorTitle = new System.Windows.Forms.TextBox();
            this.errorLangLabel = new System.Windows.Forms.Label();
            this.txtErrorLang = new System.Windows.Forms.TextBox();
            this.errorDescLabel = new System.Windows.Forms.Label();
            this.txtErrorDesc = new System.Windows.Forms.TextBox();
            this.errorCodeLabel = new System.Windows.Forms.Label();
            this.txtErrorCode = new System.Windows.Forms.RichTextBox();
            this.errorTagLabel = new System.Windows.Forms.Label();
            this.txtErrorTag = new System.Windows.Forms.TextBox();
            this.chkErrorPublic = new System.Windows.Forms.CheckBox();
            this.btnEditError = new System.Windows.Forms.Button();
            this.btnDeleteError = new System.Windows.Forms.Button();
            this.tabpageTutorials = new System.Windows.Forms.TabPage();
            this.listTutorials = new System.Windows.Forms.ListBox();
            this.tutorialTitleLabel = new System.Windows.Forms.Label();
            this.txtTutorialTitle = new System.Windows.Forms.TextBox();
            this.tutorialLangLabel = new System.Windows.Forms.Label();
            this.txtTutorialLang = new System.Windows.Forms.TextBox();
            this.tutorialDescLabel = new System.Windows.Forms.Label();
            this.txtTutorialDesc = new System.Windows.Forms.TextBox();
            this.tutorialCodeLabel = new System.Windows.Forms.Label();
            this.txtTutorialCode = new System.Windows.Forms.RichTextBox();
            this.tutorialTagLabel = new System.Windows.Forms.Label();
            this.txtTutorialTag = new System.Windows.Forms.TextBox();
            this.chkTutorialPublic = new System.Windows.Forms.CheckBox();
            this.btnEditTutorial = new System.Windows.Forms.Button();
            this.btnDeleteTutorial = new System.Windows.Forms.Button();
            this.tabpageTemplateCode = new System.Windows.Forms.TabPage();
            this.listBoxTemplateCode = new System.Windows.Forms.ListBox();
            this.templateTitleLabel = new System.Windows.Forms.Label();
            this.txtTemplateCodeTitle = new System.Windows.Forms.TextBox();
            this.templateLangLabel = new System.Windows.Forms.Label();
            this.txtTemplateCodeLang = new System.Windows.Forms.TextBox();
            this.templateDescLabel = new System.Windows.Forms.Label();
            this.txtTemplateCodeDesc = new System.Windows.Forms.TextBox();
            this.templateCodeLabel = new System.Windows.Forms.Label();
            this.txtTemplateCodeCode = new System.Windows.Forms.RichTextBox();
            this.templateTagLabel = new System.Windows.Forms.Label();
            this.txtTemplateCodeTag = new System.Windows.Forms.TextBox();
            this.chkTemplateCodePublic = new System.Windows.Forms.CheckBox();
            this.btnEditTemplate = new System.Windows.Forms.Button();
            this.btnDeleteTemplate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabpageInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.txttabpageErrors.SuspendLayout();
            this.tabpageTutorials.SuspendLayout();
            this.tabpageTemplateCode.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageInsert);
            this.tabControl1.Controls.Add(this.txttabpageErrors);
            this.tabControl1.Controls.Add(this.tabpageTutorials);
            this.tabControl1.Controls.Add(this.tabpageTemplateCode);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 659);
            this.tabControl1.TabIndex = 0;
            // 
            // tabpageInsert
            // 
            this.tabpageInsert.Controls.Add(this.titleLabel);
            this.tabpageInsert.Controls.Add(this.txtname);
            this.tabpageInsert.Controls.Add(this.languageLabel);
            this.tabpageInsert.Controls.Add(this.cmblan);
            this.tabpageInsert.Controls.Add(this.categoryLabel);
            this.tabpageInsert.Controls.Add(this.cmbcat);
            this.tabpageInsert.Controls.Add(this.tagLabel);
            this.tabpageInsert.Controls.Add(this.txttag);
            this.tabpageInsert.Controls.Add(this.descLabel);
            this.tabpageInsert.Controls.Add(this.txtdesc);
            this.tabpageInsert.Controls.Add(this.codeLabel);
            this.tabpageInsert.Controls.Add(this.txtcode);
            this.tabpageInsert.Controls.Add(this.checkpubper);
            this.tabpageInsert.Controls.Add(this.btnsave);
            this.tabpageInsert.Controls.Add(this.btnUpdate);
            this.tabpageInsert.Controls.Add(this.btnDelete);
            this.tabpageInsert.Controls.Add(this.btnClear);
            this.tabpageInsert.Controls.Add(this.dataGridView1);
            this.tabpageInsert.Location = new System.Drawing.Point(4, 28);
            this.tabpageInsert.Name = "tabpageInsert";
            this.tabpageInsert.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabpageInsert.Size = new System.Drawing.Size(935, 627);
            this.tabpageInsert.TabIndex = 0;
            this.tabpageInsert.Text = "مدیریت کدها";
            this.tabpageInsert.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(13, 13);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(34, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "عنوان";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(13, 30);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(232, 20);
            this.txtname.TabIndex = 1;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(257, 13);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(27, 13);
            this.languageLabel.TabIndex = 2;
            this.languageLabel.Text = "زبان";
            // 
            // cmblan
            // 
            this.cmblan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblan.Location = new System.Drawing.Point(257, 30);
            this.cmblan.Name = "cmblan";
            this.cmblan.Size = new System.Drawing.Size(129, 21);
            this.cmblan.TabIndex = 3;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(399, 13);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(53, 13);
            this.categoryLabel.TabIndex = 4;
            this.categoryLabel.Text = "دسته‌بندی";
            // 
            // cmbcat
            // 
            this.cmbcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcat.Location = new System.Drawing.Point(399, 30);
            this.cmbcat.Name = "cmbcat";
            this.cmbcat.Size = new System.Drawing.Size(129, 21);
            this.cmbcat.TabIndex = 5;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Location = new System.Drawing.Point(540, 13);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(18, 13);
            this.tagLabel.TabIndex = 6;
            this.tagLabel.Text = "تگ";
            // 
            // txttag
            // 
            this.txttag.Location = new System.Drawing.Point(540, 30);
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(155, 20);
            this.txttag.TabIndex = 7;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(13, 65);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(49, 13);
            this.descLabel.TabIndex = 8;
            this.descLabel.Text = "توضیحات";
            // 
            // txtdesc
            // 
            this.txtdesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdesc.Location = new System.Drawing.Point(13, 82);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(682, 57);
            this.txtdesc.TabIndex = 9;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(13, 156);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(19, 13);
            this.codeLabel.TabIndex = 10;
            this.codeLabel.Text = "کد";
            // 
            // txtcode
            // 
            this.txtcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcode.Location = new System.Drawing.Point(13, 173);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(682, 226);
            this.txtcode.TabIndex = 11;
            this.txtcode.Text = "";
            // 
            // checkpubper
            // 
            this.checkpubper.AutoSize = true;
            this.checkpubper.Checked = true;
            this.checkpubper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkpubper.Location = new System.Drawing.Point(13, 412);
            this.checkpubper.Name = "checkpubper";
            this.checkpubper.Size = new System.Drawing.Size(59, 17);
            this.checkpubper.TabIndex = 12;
            this.checkpubper.Text = "عمومی";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(107, 406);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(120, 30);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "ذخیره رکورد جدید";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(236, 406);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 30);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "بروزرسانی";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(339, 406);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 30);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(424, 406);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 30);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "پاک کردن";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Language,
            this.Category,
            this.isPublic,
            this.CreateAt});
            this.dataGridView1.Location = new System.Drawing.Point(13, 451);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(887, 165);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "شناسه";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 70;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "عنوان";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Language
            // 
            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "زبان";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "دسته‌بندی";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // isPublic
            // 
            this.isPublic.DataPropertyName = "IsPublic";
            this.isPublic.HeaderText = "عمومی";
            this.isPublic.Name = "isPublic";
            this.isPublic.ReadOnly = true;
            // 
            // CreateAt
            // 
            this.CreateAt.DataPropertyName = "CreateAt";
            this.CreateAt.HeaderText = "تاریخ ایجاد";
            this.CreateAt.Name = "CreateAt";
            this.CreateAt.ReadOnly = true;
            // 
            // txttabpageErrors
            // 
            this.txttabpageErrors.Controls.Add(this.listErrors);
            this.txttabpageErrors.Controls.Add(this.errorTitleLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorTitle);
            this.txttabpageErrors.Controls.Add(this.errorLangLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorLang);
            this.txttabpageErrors.Controls.Add(this.errorDescLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorDesc);
            this.txttabpageErrors.Controls.Add(this.errorCodeLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorCode);
            this.txttabpageErrors.Controls.Add(this.errorTagLabel);
            this.txttabpageErrors.Controls.Add(this.txtErrorTag);
            this.txttabpageErrors.Controls.Add(this.chkErrorPublic);
            this.txttabpageErrors.Controls.Add(this.btnEditError);
            this.txttabpageErrors.Controls.Add(this.btnDeleteError);
            this.txttabpageErrors.Location = new System.Drawing.Point(4, 28);
            this.txttabpageErrors.Name = "txttabpageErrors";
            this.txttabpageErrors.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.txttabpageErrors.Size = new System.Drawing.Size(935, 627);
            this.txttabpageErrors.TabIndex = 1;
            this.txttabpageErrors.Text = "خطاها";
            this.txttabpageErrors.UseVisualStyleBackColor = true;
            // 
            // listErrors
            // 
            this.listErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listErrors.DisplayMember = "Title";
            this.listErrors.Location = new System.Drawing.Point(7, 7);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(215, 537);
            this.listErrors.TabIndex = 0;
            this.listErrors.ValueMember = "Id";
            this.listErrors.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // errorTitleLabel
            // 
            this.errorTitleLabel.AutoSize = true;
            this.errorTitleLabel.Location = new System.Drawing.Point(236, 13);
            this.errorTitleLabel.Name = "errorTitleLabel";
            this.errorTitleLabel.Size = new System.Drawing.Size(34, 13);
            this.errorTitleLabel.TabIndex = 1;
            this.errorTitleLabel.Text = "عنوان";
            // 
            // txtErrorTitle
            // 
            this.txtErrorTitle.Location = new System.Drawing.Point(236, 30);
            this.txtErrorTitle.Name = "txtErrorTitle";
            this.txtErrorTitle.Size = new System.Drawing.Size(258, 20);
            this.txtErrorTitle.TabIndex = 2;
            // 
            // errorLangLabel
            // 
            this.errorLangLabel.AutoSize = true;
            this.errorLangLabel.Location = new System.Drawing.Point(506, 13);
            this.errorLangLabel.Name = "errorLangLabel";
            this.errorLangLabel.Size = new System.Drawing.Size(27, 13);
            this.errorLangLabel.TabIndex = 3;
            this.errorLangLabel.Text = "زبان";
            // 
            // txtErrorLang
            // 
            this.txtErrorLang.Location = new System.Drawing.Point(506, 30);
            this.txtErrorLang.Name = "txtErrorLang";
            this.txtErrorLang.Size = new System.Drawing.Size(155, 20);
            this.txtErrorLang.TabIndex = 4;
            // 
            // errorDescLabel
            // 
            this.errorDescLabel.AutoSize = true;
            this.errorDescLabel.Location = new System.Drawing.Point(236, 65);
            this.errorDescLabel.Name = "errorDescLabel";
            this.errorDescLabel.Size = new System.Drawing.Size(49, 13);
            this.errorDescLabel.TabIndex = 5;
            this.errorDescLabel.Text = "توضیحات";
            // 
            // txtErrorDesc
            // 
            this.txtErrorDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorDesc.Location = new System.Drawing.Point(236, 82);
            this.txtErrorDesc.Multiline = true;
            this.txtErrorDesc.Name = "txtErrorDesc";
            this.txtErrorDesc.Size = new System.Drawing.Size(425, 61);
            this.txtErrorDesc.TabIndex = 6;
            // 
            // errorCodeLabel
            // 
            this.errorCodeLabel.AutoSize = true;
            this.errorCodeLabel.Location = new System.Drawing.Point(236, 156);
            this.errorCodeLabel.Name = "errorCodeLabel";
            this.errorCodeLabel.Size = new System.Drawing.Size(19, 13);
            this.errorCodeLabel.TabIndex = 7;
            this.errorCodeLabel.Text = "کد";
            // 
            // txtErrorCode
            // 
            this.txtErrorCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorCode.Location = new System.Drawing.Point(236, 173);
            this.txtErrorCode.Name = "txtErrorCode";
            this.txtErrorCode.Size = new System.Drawing.Size(425, 209);
            this.txtErrorCode.TabIndex = 8;
            this.txtErrorCode.Text = "";
            // 
            // errorTagLabel
            // 
            this.errorTagLabel.AutoSize = true;
            this.errorTagLabel.Location = new System.Drawing.Point(236, 394);
            this.errorTagLabel.Name = "errorTagLabel";
            this.errorTagLabel.Size = new System.Drawing.Size(18, 13);
            this.errorTagLabel.TabIndex = 9;
            this.errorTagLabel.Text = "تگ";
            // 
            // txtErrorTag
            // 
            this.txtErrorTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtErrorTag.Location = new System.Drawing.Point(236, 412);
            this.txtErrorTag.Name = "txtErrorTag";
            this.txtErrorTag.Size = new System.Drawing.Size(172, 20);
            this.txtErrorTag.TabIndex = 10;
            // 
            // chkErrorPublic
            // 
            this.chkErrorPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkErrorPublic.AutoSize = true;
            this.chkErrorPublic.Location = new System.Drawing.Point(429, 414);
            this.chkErrorPublic.Name = "chkErrorPublic";
            this.chkErrorPublic.Size = new System.Drawing.Size(59, 17);
            this.chkErrorPublic.TabIndex = 11;
            this.chkErrorPublic.Text = "عمومی";
            // 
            // btnEditError
            // 
            this.btnEditError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditError.Location = new System.Drawing.Point(506, 407);
            this.btnEditError.Name = "btnEditError";
            this.btnEditError.Size = new System.Drawing.Size(73, 30);
            this.btnEditError.TabIndex = 12;
            this.btnEditError.Text = "ویرایش";
            this.btnEditError.UseVisualStyleBackColor = true;
            this.btnEditError.Click += new System.EventHandler(this.BtnEditError_Click);
            // 
            // btnDeleteError
            // 
            this.btnDeleteError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteError.Location = new System.Drawing.Point(587, 407);
            this.btnDeleteError.Name = "btnDeleteError";
            this.btnDeleteError.Size = new System.Drawing.Size(73, 30);
            this.btnDeleteError.TabIndex = 13;
            this.btnDeleteError.Text = "حذف";
            this.btnDeleteError.UseVisualStyleBackColor = true;
            this.btnDeleteError.Click += new System.EventHandler(this.BtnDeleteError_Click);
            // 
            // tabpageTutorials
            // 
            this.tabpageTutorials.Controls.Add(this.listTutorials);
            this.tabpageTutorials.Controls.Add(this.tutorialTitleLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTitle);
            this.tabpageTutorials.Controls.Add(this.tutorialLangLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialLang);
            this.tabpageTutorials.Controls.Add(this.tutorialDescLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialDesc);
            this.tabpageTutorials.Controls.Add(this.tutorialCodeLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialCode);
            this.tabpageTutorials.Controls.Add(this.tutorialTagLabel);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTag);
            this.tabpageTutorials.Controls.Add(this.chkTutorialPublic);
            this.tabpageTutorials.Controls.Add(this.btnEditTutorial);
            this.tabpageTutorials.Controls.Add(this.btnDeleteTutorial);
            this.tabpageTutorials.Location = new System.Drawing.Point(4, 28);
            this.tabpageTutorials.Name = "tabpageTutorials";
            this.tabpageTutorials.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabpageTutorials.Size = new System.Drawing.Size(935, 627);
            this.tabpageTutorials.TabIndex = 2;
            this.tabpageTutorials.Text = "آموزشی";
            this.tabpageTutorials.UseVisualStyleBackColor = true;
            // 
            // listTutorials
            // 
            this.listTutorials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listTutorials.DisplayMember = "Title";
            this.listTutorials.Location = new System.Drawing.Point(7, 7);
            this.listTutorials.Name = "listTutorials";
            this.listTutorials.Size = new System.Drawing.Size(215, 537);
            this.listTutorials.TabIndex = 0;
            this.listTutorials.ValueMember = "Id";
            this.listTutorials.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // tutorialTitleLabel
            // 
            this.tutorialTitleLabel.AutoSize = true;
            this.tutorialTitleLabel.Location = new System.Drawing.Point(236, 13);
            this.tutorialTitleLabel.Name = "tutorialTitleLabel";
            this.tutorialTitleLabel.Size = new System.Drawing.Size(34, 13);
            this.tutorialTitleLabel.TabIndex = 1;
            this.tutorialTitleLabel.Text = "عنوان";
            // 
            // txtTutorialTitle
            // 
            this.txtTutorialTitle.Location = new System.Drawing.Point(236, 30);
            this.txtTutorialTitle.Name = "txtTutorialTitle";
            this.txtTutorialTitle.Size = new System.Drawing.Size(258, 20);
            this.txtTutorialTitle.TabIndex = 2;
            // 
            // tutorialLangLabel
            // 
            this.tutorialLangLabel.AutoSize = true;
            this.tutorialLangLabel.Location = new System.Drawing.Point(506, 13);
            this.tutorialLangLabel.Name = "tutorialLangLabel";
            this.tutorialLangLabel.Size = new System.Drawing.Size(27, 13);
            this.tutorialLangLabel.TabIndex = 3;
            this.tutorialLangLabel.Text = "زبان";
            // 
            // txtTutorialLang
            // 
            this.txtTutorialLang.Location = new System.Drawing.Point(506, 30);
            this.txtTutorialLang.Name = "txtTutorialLang";
            this.txtTutorialLang.Size = new System.Drawing.Size(155, 20);
            this.txtTutorialLang.TabIndex = 4;
            // 
            // tutorialDescLabel
            // 
            this.tutorialDescLabel.AutoSize = true;
            this.tutorialDescLabel.Location = new System.Drawing.Point(236, 65);
            this.tutorialDescLabel.Name = "tutorialDescLabel";
            this.tutorialDescLabel.Size = new System.Drawing.Size(49, 13);
            this.tutorialDescLabel.TabIndex = 5;
            this.tutorialDescLabel.Text = "توضیحات";
            // 
            // txtTutorialDesc
            // 
            this.txtTutorialDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTutorialDesc.Location = new System.Drawing.Point(236, 82);
            this.txtTutorialDesc.Multiline = true;
            this.txtTutorialDesc.Name = "txtTutorialDesc";
            this.txtTutorialDesc.Size = new System.Drawing.Size(425, 61);
            this.txtTutorialDesc.TabIndex = 6;
            // 
            // tutorialCodeLabel
            // 
            this.tutorialCodeLabel.AutoSize = true;
            this.tutorialCodeLabel.Location = new System.Drawing.Point(236, 156);
            this.tutorialCodeLabel.Name = "tutorialCodeLabel";
            this.tutorialCodeLabel.Size = new System.Drawing.Size(19, 13);
            this.tutorialCodeLabel.TabIndex = 7;
            this.tutorialCodeLabel.Text = "کد";
            // 
            // txtTutorialCode
            // 
            this.txtTutorialCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTutorialCode.Location = new System.Drawing.Point(236, 173);
            this.txtTutorialCode.Name = "txtTutorialCode";
            this.txtTutorialCode.Size = new System.Drawing.Size(425, 209);
            this.txtTutorialCode.TabIndex = 8;
            this.txtTutorialCode.Text = "";
            // 
            // tutorialTagLabel
            // 
            this.tutorialTagLabel.AutoSize = true;
            this.tutorialTagLabel.Location = new System.Drawing.Point(236, 394);
            this.tutorialTagLabel.Name = "tutorialTagLabel";
            this.tutorialTagLabel.Size = new System.Drawing.Size(18, 13);
            this.tutorialTagLabel.TabIndex = 9;
            this.tutorialTagLabel.Text = "تگ";
            // 
            // txtTutorialTag
            // 
            this.txtTutorialTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTutorialTag.Location = new System.Drawing.Point(236, 412);
            this.txtTutorialTag.Name = "txtTutorialTag";
            this.txtTutorialTag.Size = new System.Drawing.Size(172, 20);
            this.txtTutorialTag.TabIndex = 10;
            // 
            // chkTutorialPublic
            // 
            this.chkTutorialPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTutorialPublic.AutoSize = true;
            this.chkTutorialPublic.Location = new System.Drawing.Point(429, 414);
            this.chkTutorialPublic.Name = "chkTutorialPublic";
            this.chkTutorialPublic.Size = new System.Drawing.Size(59, 17);
            this.chkTutorialPublic.TabIndex = 11;
            this.chkTutorialPublic.Text = "عمومی";
            // 
            // btnEditTutorial
            // 
            this.btnEditTutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTutorial.Location = new System.Drawing.Point(506, 407);
            this.btnEditTutorial.Name = "btnEditTutorial";
            this.btnEditTutorial.Size = new System.Drawing.Size(73, 30);
            this.btnEditTutorial.TabIndex = 12;
            this.btnEditTutorial.Text = "ویرایش";
            this.btnEditTutorial.UseVisualStyleBackColor = true;
            this.btnEditTutorial.Click += new System.EventHandler(this.BtnEditTutorial_Click);
            // 
            // btnDeleteTutorial
            // 
            this.btnDeleteTutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTutorial.Location = new System.Drawing.Point(587, 407);
            this.btnDeleteTutorial.Name = "btnDeleteTutorial";
            this.btnDeleteTutorial.Size = new System.Drawing.Size(73, 30);
            this.btnDeleteTutorial.TabIndex = 13;
            this.btnDeleteTutorial.Text = "حذف";
            this.btnDeleteTutorial.UseVisualStyleBackColor = true;
            this.btnDeleteTutorial.Click += new System.EventHandler(this.BtnDeleteTutorial_Click);
            // 
            // tabpageTemplateCode
            // 
            this.tabpageTemplateCode.Controls.Add(this.listBoxTemplateCode);
            this.tabpageTemplateCode.Controls.Add(this.templateTitleLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTitle);
            this.tabpageTemplateCode.Controls.Add(this.templateLangLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeLang);
            this.tabpageTemplateCode.Controls.Add(this.templateDescLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeDesc);
            this.tabpageTemplateCode.Controls.Add(this.templateCodeLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeCode);
            this.tabpageTemplateCode.Controls.Add(this.templateTagLabel);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTag);
            this.tabpageTemplateCode.Controls.Add(this.chkTemplateCodePublic);
            this.tabpageTemplateCode.Controls.Add(this.btnEditTemplate);
            this.tabpageTemplateCode.Controls.Add(this.btnDeleteTemplate);
            this.tabpageTemplateCode.Location = new System.Drawing.Point(4, 28);
            this.tabpageTemplateCode.Name = "tabpageTemplateCode";
            this.tabpageTemplateCode.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.tabpageTemplateCode.Size = new System.Drawing.Size(935, 627);
            this.tabpageTemplateCode.TabIndex = 3;
            this.tabpageTemplateCode.Text = "کد آماده";
            this.tabpageTemplateCode.UseVisualStyleBackColor = true;
            // 
            // listBoxTemplateCode
            // 
            this.listBoxTemplateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxTemplateCode.DisplayMember = "Title";
            this.listBoxTemplateCode.Location = new System.Drawing.Point(7, 7);
            this.listBoxTemplateCode.Name = "listBoxTemplateCode";
            this.listBoxTemplateCode.Size = new System.Drawing.Size(215, 537);
            this.listBoxTemplateCode.TabIndex = 0;
            this.listBoxTemplateCode.ValueMember = "Id";
            this.listBoxTemplateCode.SelectedIndexChanged += new System.EventHandler(this.CategoryList_SelectedIndexChanged);
            // 
            // templateTitleLabel
            // 
            this.templateTitleLabel.AutoSize = true;
            this.templateTitleLabel.Location = new System.Drawing.Point(236, 13);
            this.templateTitleLabel.Name = "templateTitleLabel";
            this.templateTitleLabel.Size = new System.Drawing.Size(34, 13);
            this.templateTitleLabel.TabIndex = 1;
            this.templateTitleLabel.Text = "عنوان";
            // 
            // txtTemplateCodeTitle
            // 
            this.txtTemplateCodeTitle.Location = new System.Drawing.Point(236, 30);
            this.txtTemplateCodeTitle.Name = "txtTemplateCodeTitle";
            this.txtTemplateCodeTitle.Size = new System.Drawing.Size(258, 20);
            this.txtTemplateCodeTitle.TabIndex = 2;
            // 
            // templateLangLabel
            // 
            this.templateLangLabel.AutoSize = true;
            this.templateLangLabel.Location = new System.Drawing.Point(506, 13);
            this.templateLangLabel.Name = "templateLangLabel";
            this.templateLangLabel.Size = new System.Drawing.Size(27, 13);
            this.templateLangLabel.TabIndex = 3;
            this.templateLangLabel.Text = "زبان";
            // 
            // txtTemplateCodeLang
            // 
            this.txtTemplateCodeLang.Location = new System.Drawing.Point(506, 30);
            this.txtTemplateCodeLang.Name = "txtTemplateCodeLang";
            this.txtTemplateCodeLang.Size = new System.Drawing.Size(155, 20);
            this.txtTemplateCodeLang.TabIndex = 4;
            // 
            // templateDescLabel
            // 
            this.templateDescLabel.AutoSize = true;
            this.templateDescLabel.Location = new System.Drawing.Point(236, 65);
            this.templateDescLabel.Name = "templateDescLabel";
            this.templateDescLabel.Size = new System.Drawing.Size(49, 13);
            this.templateDescLabel.TabIndex = 5;
            this.templateDescLabel.Text = "توضیحات";
            // 
            // txtTemplateCodeDesc
            // 
            this.txtTemplateCodeDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateCodeDesc.Location = new System.Drawing.Point(236, 82);
            this.txtTemplateCodeDesc.Multiline = true;
            this.txtTemplateCodeDesc.Name = "txtTemplateCodeDesc";
            this.txtTemplateCodeDesc.Size = new System.Drawing.Size(425, 61);
            this.txtTemplateCodeDesc.TabIndex = 6;
            // 
            // templateCodeLabel
            // 
            this.templateCodeLabel.AutoSize = true;
            this.templateCodeLabel.Location = new System.Drawing.Point(236, 156);
            this.templateCodeLabel.Name = "templateCodeLabel";
            this.templateCodeLabel.Size = new System.Drawing.Size(19, 13);
            this.templateCodeLabel.TabIndex = 7;
            this.templateCodeLabel.Text = "کد";
            // 
            // txtTemplateCodeCode
            // 
            this.txtTemplateCodeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateCodeCode.Location = new System.Drawing.Point(236, 173);
            this.txtTemplateCodeCode.Name = "txtTemplateCodeCode";
            this.txtTemplateCodeCode.Size = new System.Drawing.Size(425, 209);
            this.txtTemplateCodeCode.TabIndex = 8;
            this.txtTemplateCodeCode.Text = "";
            // 
            // templateTagLabel
            // 
            this.templateTagLabel.AutoSize = true;
            this.templateTagLabel.Location = new System.Drawing.Point(236, 394);
            this.templateTagLabel.Name = "templateTagLabel";
            this.templateTagLabel.Size = new System.Drawing.Size(18, 13);
            this.templateTagLabel.TabIndex = 9;
            this.templateTagLabel.Text = "تگ";
            // 
            // txtTemplateCodeTag
            // 
            this.txtTemplateCodeTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTemplateCodeTag.Location = new System.Drawing.Point(236, 412);
            this.txtTemplateCodeTag.Name = "txtTemplateCodeTag";
            this.txtTemplateCodeTag.Size = new System.Drawing.Size(172, 20);
            this.txtTemplateCodeTag.TabIndex = 10;
            // 
            // chkTemplateCodePublic
            // 
            this.chkTemplateCodePublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTemplateCodePublic.AutoSize = true;
            this.chkTemplateCodePublic.Location = new System.Drawing.Point(429, 414);
            this.chkTemplateCodePublic.Name = "chkTemplateCodePublic";
            this.chkTemplateCodePublic.Size = new System.Drawing.Size(59, 17);
            this.chkTemplateCodePublic.TabIndex = 11;
            this.chkTemplateCodePublic.Text = "عمومی";
            // 
            // btnEditTemplate
            // 
            this.btnEditTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTemplate.Location = new System.Drawing.Point(506, 407);
            this.btnEditTemplate.Name = "btnEditTemplate";
            this.btnEditTemplate.Size = new System.Drawing.Size(73, 30);
            this.btnEditTemplate.TabIndex = 12;
            this.btnEditTemplate.Text = "ویرایش";
            this.btnEditTemplate.UseVisualStyleBackColor = true;
            this.btnEditTemplate.Click += new System.EventHandler(this.BtnEditTemplate_Click);
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTemplate.Location = new System.Drawing.Point(587, 407);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(73, 30);
            this.btnDeleteTemplate.TabIndex = 13;
            this.btnDeleteTemplate.Text = "حذف";
            this.btnDeleteTemplate.UseVisualStyleBackColor = true;
            this.btnDeleteTemplate.Click += new System.EventHandler(this.BtnDeleteTemplate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(935, 627);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "درباره";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Mitra", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(69, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(763, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "سلام دوستان این نسخه فقط برای انتشار و تجربه ی کار شما با برنامه ساخته شده و هنوز" +
    " کامل نشده است و در حال توسعه است.";
            // 
            // frmCodeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 659);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(774, 569);
            this.Name = "frmCodeBank";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeBank - مدیریت کدها";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabpageInsert.ResumeLayout(false);
            this.tabpageInsert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.txttabpageErrors.ResumeLayout(false);
            this.txttabpageErrors.PerformLayout();
            this.tabpageTutorials.ResumeLayout(false);
            this.tabpageTutorials.PerformLayout();
            this.tabpageTemplateCode.ResumeLayout(false);
            this.tabpageTemplateCode.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label errorTitleLabel;
        private System.Windows.Forms.Label errorLangLabel;
        private System.Windows.Forms.Label errorDescLabel;
        private System.Windows.Forms.Label errorCodeLabel;
        private System.Windows.Forms.Label errorTagLabel;
        private System.Windows.Forms.Label tutorialTitleLabel;
        private System.Windows.Forms.Label tutorialLangLabel;
        private System.Windows.Forms.Label tutorialDescLabel;
        private System.Windows.Forms.Label tutorialCodeLabel;
        private System.Windows.Forms.Label tutorialTagLabel;
        private System.Windows.Forms.Label templateTitleLabel;
        private System.Windows.Forms.Label templateLangLabel;
        private System.Windows.Forms.Label templateDescLabel;
        private System.Windows.Forms.Label templateCodeLabel;
        private System.Windows.Forms.Label templateTagLabel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
    }
}
