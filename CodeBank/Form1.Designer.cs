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
            components = new System.ComponentModel.Container();

            tabControl1 = new System.Windows.Forms.TabControl();
            tabpageInsert = new System.Windows.Forms.TabPage();
            txttabpageErrors = new System.Windows.Forms.TabPage();
            tabpageTutorials = new System.Windows.Forms.TabPage();
            tabpageTemplateCode = new System.Windows.Forms.TabPage();

            dataGridView1 = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            isPublic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();

            txtname = new System.Windows.Forms.TextBox();
            txtdesc = new System.Windows.Forms.TextBox();
            txtcode = new System.Windows.Forms.RichTextBox();
            cmblan = new System.Windows.Forms.ComboBox();
            cmbcat = new System.Windows.Forms.ComboBox();
            txttag = new System.Windows.Forms.TextBox();
            checkpubper = new System.Windows.Forms.CheckBox();
            btnsave = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();

            listErrors = new System.Windows.Forms.ListBox();
            txtErrorTitle = new System.Windows.Forms.TextBox();
            txtErrorDesc = new System.Windows.Forms.TextBox();
            txtErrorCode = new System.Windows.Forms.RichTextBox();
            txtErrorLang = new System.Windows.Forms.TextBox();
            txtErrorTag = new System.Windows.Forms.TextBox();
            chkErrorPublic = new System.Windows.Forms.CheckBox();
            btnEditError = new System.Windows.Forms.Button();
            btnDeleteError = new System.Windows.Forms.Button();

            listTutorials = new System.Windows.Forms.ListBox();
            txtTutorialTitle = new System.Windows.Forms.TextBox();
            txtTutorialDesc = new System.Windows.Forms.TextBox();
            txtTutorialCode = new System.Windows.Forms.RichTextBox();
            txtTutorialLang = new System.Windows.Forms.TextBox();
            txtTutorialTag = new System.Windows.Forms.TextBox();
            chkTutorialPublic = new System.Windows.Forms.CheckBox();
            btnEditTutorial = new System.Windows.Forms.Button();
            btnDeleteTutorial = new System.Windows.Forms.Button();

            listBoxTemplateCode = new System.Windows.Forms.ListBox();
            txtTemplateCodeTitle = new System.Windows.Forms.TextBox();
            txtTemplateCodeDesc = new System.Windows.Forms.TextBox();
            txtTemplateCodeCode = new System.Windows.Forms.RichTextBox();
            txtTemplateCodeLang = new System.Windows.Forms.TextBox();
            txtTemplateCodeTag = new System.Windows.Forms.TextBox();
            chkTemplateCodePublic = new System.Windows.Forms.CheckBox();
            btnEditTemplate = new System.Windows.Forms.Button();
            btnDeleteTemplate = new System.Windows.Forms.Button();

            tabControl1.SuspendLayout();
            tabpageInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            SuspendLayout();

            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Controls.Add(tabpageInsert);
            tabControl1.Controls.Add(txttabpageErrors);
            tabControl1.Controls.Add(tabpageTutorials);
            tabControl1.Controls.Add(tabpageTemplateCode);

            tabpageInsert.Text = "مدیریت کدها";
            txttabpageErrors.Text = "خطاها";
            tabpageTutorials.Text = "آموزشی";
            tabpageTemplateCode.Text = "کد آماده";

            tabpageInsert.Padding = new System.Windows.Forms.Padding(8);
            tabpageInsert.AutoScroll = true;

            var titleLabel = CreateLabel("عنوان", 15, 15);
            txtname.Location = new System.Drawing.Point(15, 35);
            txtname.Size = new System.Drawing.Size(270, 25);

            var languageLabel = CreateLabel("زبان", 300, 15);
            cmblan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmblan.Location = new System.Drawing.Point(300, 35);
            cmblan.Size = new System.Drawing.Size(150, 25);

            var categoryLabel = CreateLabel("دسته‌بندی", 465, 15);
            cmbcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbcat.Location = new System.Drawing.Point(465, 35);
            cmbcat.Size = new System.Drawing.Size(150, 25);

            var tagLabel = CreateLabel("تگ", 630, 15);
            txttag.Location = new System.Drawing.Point(630, 35);
            txttag.Size = new System.Drawing.Size(180, 25);

            var descLabel = CreateLabel("توضیحات", 15, 75);
            txtdesc.Location = new System.Drawing.Point(15, 95);
            txtdesc.Size = new System.Drawing.Size(795, 65);
            txtdesc.Multiline = true;

            var codeLabel = CreateLabel("کد", 15, 180);
            txtcode.Location = new System.Drawing.Point(15, 200);
            txtcode.Size = new System.Drawing.Size(795, 260);
            txtcode.Anchor = System.Windows.Forms.AnchorStyles.Top |
                             System.Windows.Forms.AnchorStyles.Left |
                             System.Windows.Forms.AnchorStyles.Right;

            checkpubper.Text = "عمومی";
            checkpubper.Checked = true;
            checkpubper.AutoSize = true;
            checkpubper.Location = new System.Drawing.Point(15, 475);

            btnsave.Text = "ذخیره رکورد جدید";
            btnsave.Location = new System.Drawing.Point(125, 468);
            btnsave.Size = new System.Drawing.Size(140, 35);
            btnsave.Click += new System.EventHandler(this.BtnSave_Click);

            btnUpdate.Text = "بروزرسانی";
            btnUpdate.Location = new System.Drawing.Point(275, 468);
            btnUpdate.Size = new System.Drawing.Size(110, 35);
            btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);

            btnDelete.Text = "حذف";
            btnDelete.Location = new System.Drawing.Point(395, 468);
            btnDelete.Size = new System.Drawing.Size(90, 35);
            btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            btnClear.Text = "پاک کردن";
            btnClear.Location = new System.Drawing.Point(495, 468);
            btnClear.Size = new System.Drawing.Size(100, 35);
            btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            dataGridView1.Location = new System.Drawing.Point(15, 520);
            dataGridView1.Size = new System.Drawing.Size(795, 190);
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top |
                                   System.Windows.Forms.AnchorStyles.Bottom |
                                   System.Windows.Forms.AnchorStyles.Left |
                                   System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                Id, Title, Language, Category, isPublic, CreateAt
            });
            dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);

            Id.DataPropertyName = "Id";
            Id.HeaderText = "شناسه";
            Id.Name = "Id";
            Id.Width = 60;

            Title.DataPropertyName = "Title";
            Title.HeaderText = "عنوان";
            Title.Name = "Title";

            Language.DataPropertyName = "Language";
            Language.HeaderText = "زبان";
            Language.Name = "Language";

            Category.DataPropertyName = "Category";
            Category.HeaderText = "دسته‌بندی";
            Category.Name = "Category";

            isPublic.DataPropertyName = "IsPublic";
            isPublic.HeaderText = "عمومی";
            isPublic.Name = "isPublic";

            CreateAt.DataPropertyName = "CreateAt";
            CreateAt.HeaderText = "تاریخ ایجاد";
            CreateAt.Name = "CreateAt";

            tabpageInsert.Controls.Add(titleLabel);
            tabpageInsert.Controls.Add(txtname);
            tabpageInsert.Controls.Add(languageLabel);
            tabpageInsert.Controls.Add(cmblan);
            tabpageInsert.Controls.Add(categoryLabel);
            tabpageInsert.Controls.Add(cmbcat);
            tabpageInsert.Controls.Add(tagLabel);
            tabpageInsert.Controls.Add(txttag);
            tabpageInsert.Controls.Add(descLabel);
            tabpageInsert.Controls.Add(txtdesc);
            tabpageInsert.Controls.Add(codeLabel);
            tabpageInsert.Controls.Add(txtcode);
            tabpageInsert.Controls.Add(checkpubper);
            tabpageInsert.Controls.Add(btnsave);
            tabpageInsert.Controls.Add(btnUpdate);
            tabpageInsert.Controls.Add(btnDelete);
            tabpageInsert.Controls.Add(btnClear);
            tabpageInsert.Controls.Add(dataGridView1);

            SetupCategoryTab(txttabpageErrors, listErrors, txtErrorTitle, txtErrorDesc,
                txtErrorCode, txtErrorLang, txtErrorTag, chkErrorPublic,
                btnEditError, btnDeleteError);

            SetupCategoryTab(tabpageTutorials, listTutorials, txtTutorialTitle, txtTutorialDesc,
                txtTutorialCode, txtTutorialLang, txtTutorialTag, chkTutorialPublic,
                btnEditTutorial, btnDeleteTutorial);

            SetupCategoryTab(tabpageTemplateCode, listBoxTemplateCode, txtTemplateCodeTitle, txtTemplateCodeDesc,
                txtTemplateCodeCode, txtTemplateCodeLang, txtTemplateCodeTag, chkTemplateCodePublic,
                btnEditTemplate, btnDeleteTemplate);

            btnEditError.Click += new System.EventHandler(this.BtnEditError_Click);
            btnDeleteError.Click += new System.EventHandler(this.BtnDeleteError_Click);
            btnEditTutorial.Click += new System.EventHandler(this.BtnEditTutorial_Click);
            btnDeleteTutorial.Click += new System.EventHandler(this.BtnDeleteTutorial_Click);
            btnEditTemplate.Click += new System.EventHandler(this.BtnEditTemplate_Click);
            btnDeleteTemplate.Click += new System.EventHandler(this.BtnDeleteTemplate_Click);

            Name = "frmCodeBank";
            Text = "CodeBank - مدیریت کدها";
            ClientSize = new System.Drawing.Size(1100, 760);
            MinimumSize = new System.Drawing.Size(900, 650);
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Load += new System.EventHandler(this.Form1_Load);

            Controls.Add(tabControl1);

            tabControl1.ResumeLayout(false);
            tabpageInsert.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ResumeLayout(false);
        }
    }
}
