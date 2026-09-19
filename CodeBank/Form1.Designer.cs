namespace CodeBank
{
    partial class frmCodeBank
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabpageInsert = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPublic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkpubper = new System.Windows.Forms.CheckBox();
            this.txttag = new System.Windows.Forms.TextBox();
            this.cmbcat = new System.Windows.Forms.ComboBox();
            this.cmblan = new System.Windows.Forms.ComboBox();
            this.txtcode = new System.Windows.Forms.RichTextBox();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txttabpageErrors = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.txtErrorLang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkErrorPublic = new System.Windows.Forms.CheckBox();
            this.txtErrorTag = new System.Windows.Forms.TextBox();
            this.txtErrorCode = new System.Windows.Forms.RichTextBox();
            this.txtErrorDesc = new System.Windows.Forms.TextBox();
            this.txtErrorTitle = new System.Windows.Forms.TextBox();
            this.listErrors = new System.Windows.Forms.ListBox();
            this.tabpageTutorials = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTutorialLang = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.chkTutorialPublic = new System.Windows.Forms.CheckBox();
            this.txtTutorialTag = new System.Windows.Forms.TextBox();
            this.txtTutorialCode = new System.Windows.Forms.RichTextBox();
            this.txtTutorialDesc = new System.Windows.Forms.TextBox();
            this.txtTutorialTitle = new System.Windows.Forms.TextBox();
            this.listTutorials = new System.Windows.Forms.ListBox();
            this.tabpageTemplateCode = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTemplateCodeLang = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chkTemplateCodeisPublic = new System.Windows.Forms.CheckBox();
            this.txtTemplateCodeTag = new System.Windows.Forms.TextBox();
            this.txtTemplateCodeCode = new System.Windows.Forms.RichTextBox();
            this.txtTemplateCodeDesc = new System.Windows.Forms.TextBox();
            this.txtTemplateCodeTitle = new System.Windows.Forms.TextBox();
            this.listBoxTemplateCode = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabpageInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.txttabpageErrors.SuspendLayout();
            this.tabpageTutorials.SuspendLayout();
            this.tabpageTemplateCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabpageInsert);
            this.tabControl1.Controls.Add(this.txttabpageErrors);
            this.tabControl1.Controls.Add(this.tabpageTutorials);
            this.tabControl1.Controls.Add(this.tabpageTemplateCode);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(878, 341);
            this.tabControl1.TabIndex = 30;
            // 
            // tabpageInsert
            // 
            this.tabpageInsert.Controls.Add(this.dataGridView1);
            this.tabpageInsert.Controls.Add(this.label6);
            this.tabpageInsert.Controls.Add(this.label5);
            this.tabpageInsert.Controls.Add(this.label4);
            this.tabpageInsert.Controls.Add(this.label3);
            this.tabpageInsert.Controls.Add(this.label2);
            this.tabpageInsert.Controls.Add(this.label1);
            this.tabpageInsert.Controls.Add(this.checkpubper);
            this.tabpageInsert.Controls.Add(this.txttag);
            this.tabpageInsert.Controls.Add(this.cmbcat);
            this.tabpageInsert.Controls.Add(this.cmblan);
            this.tabpageInsert.Controls.Add(this.txtcode);
            this.tabpageInsert.Controls.Add(this.txtdesc);
            this.tabpageInsert.Controls.Add(this.txtname);
            this.tabpageInsert.Controls.Add(this.btnsave);
            this.tabpageInsert.Location = new System.Drawing.Point(4, 22);
            this.tabpageInsert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageInsert.Name = "tabpageInsert";
            this.tabpageInsert.Size = new System.Drawing.Size(870, 315);
            this.tabpageInsert.TabIndex = 0;
            this.tabpageInsert.Text = "Insert";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Language,
            this.Category,
            this.isPublic,
            this.CreateAt,
            this.Title});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(519, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(351, 315);
            this.dataGridView1.TabIndex = 50;
            // 
            // Id
            // 
            this.Id.HeaderText = "شناسه";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Language
            // 
            this.Language.HeaderText = "زبان";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "دسته بندی";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // isPublic
            // 
            this.isPublic.HeaderText = "عمومی";
            this.isPublic.Name = "isPublic";
            this.isPublic.ReadOnly = true;
            // 
            // CreateAt
            // 
            this.CreateAt.HeaderText = "تاریخ ایجاد";
            this.CreateAt.Name = "CreateAt";
            this.CreateAt.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "عنوان";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(249, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Tags";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Language";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Name";
            // 
            // checkpubper
            // 
            this.checkpubper.AutoSize = true;
            this.checkpubper.Checked = true;
            this.checkpubper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkpubper.Location = new System.Drawing.Point(315, 181);
            this.checkpubper.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkpubper.Name = "checkpubper";
            this.checkpubper.Size = new System.Drawing.Size(62, 17);
            this.checkpubper.TabIndex = 36;
            this.checkpubper.Text = "isPublic";
            // 
            // txttag
            // 
            this.txttag.Location = new System.Drawing.Point(297, 118);
            this.txttag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txttag.Multiline = true;
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(93, 39);
            this.txttag.TabIndex = 35;
            // 
            // cmbcat
            // 
            this.cmbcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcat.Location = new System.Drawing.Point(297, 63);
            this.cmbcat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbcat.Name = "cmbcat";
            this.cmbcat.Size = new System.Drawing.Size(93, 21);
            this.cmbcat.TabIndex = 34;
            // 
            // cmblan
            // 
            this.cmblan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmblan.Location = new System.Drawing.Point(297, 14);
            this.cmblan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmblan.Name = "cmblan";
            this.cmblan.Size = new System.Drawing.Size(93, 21);
            this.cmblan.TabIndex = 33;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(46, 147);
            this.txtcode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(153, 82);
            this.txtcode.TabIndex = 32;
            this.txtcode.Text = "";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(67, 65);
            this.txtdesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(153, 58);
            this.txtdesc.TabIndex = 31;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(46, 22);
            this.txtname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtname.Multiline = true;
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(153, 31);
            this.txtname.TabIndex = 30;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(196, 246);
            this.btnsave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(94, 36);
            this.btnsave.TabIndex = 29;
            this.btnsave.Text = "Save";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txttabpageErrors
            // 
            this.txttabpageErrors.Controls.Add(this.label12);
            this.txttabpageErrors.Controls.Add(this.txtErrorLang);
            this.txttabpageErrors.Controls.Add(this.label8);
            this.txttabpageErrors.Controls.Add(this.label9);
            this.txttabpageErrors.Controls.Add(this.label10);
            this.txttabpageErrors.Controls.Add(this.label11);
            this.txttabpageErrors.Controls.Add(this.chkErrorPublic);
            this.txttabpageErrors.Controls.Add(this.txtErrorTag);
            this.txttabpageErrors.Controls.Add(this.txtErrorCode);
            this.txttabpageErrors.Controls.Add(this.txtErrorDesc);
            this.txttabpageErrors.Controls.Add(this.txtErrorTitle);
            this.txttabpageErrors.Controls.Add(this.listErrors);
            this.txttabpageErrors.Location = new System.Drawing.Point(4, 22);
            this.txttabpageErrors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txttabpageErrors.Name = "txttabpageErrors";
            this.txttabpageErrors.Size = new System.Drawing.Size(870, 315);
            this.txttabpageErrors.TabIndex = 1;
            this.txttabpageErrors.Text = "Errors";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Language";
            // 
            // txtErrorLang
            // 
            this.txtErrorLang.Location = new System.Drawing.Point(281, 24);
            this.txtErrorLang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrorLang.Multiline = true;
            this.txtErrorLang.Name = "txtErrorLang";
            this.txtErrorLang.Size = new System.Drawing.Size(153, 31);
            this.txtErrorLang.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 264);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "Tags";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 182);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "Code";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 93);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 24);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Name";
            // 
            // chkErrorPublic
            // 
            this.chkErrorPublic.AutoSize = true;
            this.chkErrorPublic.Checked = true;
            this.chkErrorPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkErrorPublic.Location = new System.Drawing.Point(281, 93);
            this.chkErrorPublic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkErrorPublic.Name = "chkErrorPublic";
            this.chkErrorPublic.Size = new System.Drawing.Size(62, 17);
            this.chkErrorPublic.TabIndex = 54;
            this.chkErrorPublic.Text = "isPublic";
            // 
            // txtErrorTag
            // 
            this.txtErrorTag.Location = new System.Drawing.Point(43, 254);
            this.txtErrorTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrorTag.Multiline = true;
            this.txtErrorTag.Name = "txtErrorTag";
            this.txtErrorTag.Size = new System.Drawing.Size(153, 39);
            this.txtErrorTag.TabIndex = 53;
            // 
            // txtErrorCode
            // 
            this.txtErrorCode.Location = new System.Drawing.Point(43, 154);
            this.txtErrorCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrorCode.Name = "txtErrorCode";
            this.txtErrorCode.Size = new System.Drawing.Size(153, 82);
            this.txtErrorCode.TabIndex = 52;
            this.txtErrorCode.Text = "";
            // 
            // txtErrorDesc
            // 
            this.txtErrorDesc.Location = new System.Drawing.Point(67, 75);
            this.txtErrorDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrorDesc.Multiline = true;
            this.txtErrorDesc.Name = "txtErrorDesc";
            this.txtErrorDesc.Size = new System.Drawing.Size(153, 58);
            this.txtErrorDesc.TabIndex = 51;
            // 
            // txtErrorTitle
            // 
            this.txtErrorTitle.Location = new System.Drawing.Point(43, 23);
            this.txtErrorTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtErrorTitle.Multiline = true;
            this.txtErrorTitle.Name = "txtErrorTitle";
            this.txtErrorTitle.Size = new System.Drawing.Size(153, 31);
            this.txtErrorTitle.TabIndex = 50;
            // 
            // listErrors
            // 
            this.listErrors.Dock = System.Windows.Forms.DockStyle.Right;
            this.listErrors.FormattingEnabled = true;
            this.listErrors.Location = new System.Drawing.Point(721, 0);
            this.listErrors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(149, 315);
            this.listErrors.TabIndex = 0;
            this.listErrors.SelectedIndexChanged += new System.EventHandler(this.listErrors_SelectedIndexChanged);
            // 
            // tabpageTutorials
            // 
            this.tabpageTutorials.Controls.Add(this.label13);
            this.tabpageTutorials.Controls.Add(this.txtTutorialLang);
            this.tabpageTutorials.Controls.Add(this.label14);
            this.tabpageTutorials.Controls.Add(this.label15);
            this.tabpageTutorials.Controls.Add(this.label16);
            this.tabpageTutorials.Controls.Add(this.label17);
            this.tabpageTutorials.Controls.Add(this.chkTutorialPublic);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTag);
            this.tabpageTutorials.Controls.Add(this.txtTutorialCode);
            this.tabpageTutorials.Controls.Add(this.txtTutorialDesc);
            this.tabpageTutorials.Controls.Add(this.txtTutorialTitle);
            this.tabpageTutorials.Controls.Add(this.listTutorials);
            this.tabpageTutorials.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabpageTutorials.Location = new System.Drawing.Point(4, 22);
            this.tabpageTutorials.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageTutorials.Name = "tabpageTutorials";
            this.tabpageTutorials.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageTutorials.Size = new System.Drawing.Size(870, 315);
            this.tabpageTutorials.TabIndex = 2;
            this.tabpageTutorials.Text = "Tutorials";
            this.tabpageTutorials.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Language";
            // 
            // txtTutorialLang
            // 
            this.txtTutorialLang.Location = new System.Drawing.Point(280, 24);
            this.txtTutorialLang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTutorialLang.Multiline = true;
            this.txtTutorialLang.Name = "txtTutorialLang";
            this.txtTutorialLang.Size = new System.Drawing.Size(153, 31);
            this.txtTutorialLang.TabIndex = 71;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 264);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Tags";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 182);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 68;
            this.label15.Text = "Code";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 93);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "Description";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 24);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 70;
            this.label17.Text = "Name";
            // 
            // chkTutorialPublic
            // 
            this.chkTutorialPublic.AutoSize = true;
            this.chkTutorialPublic.Checked = true;
            this.chkTutorialPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTutorialPublic.Location = new System.Drawing.Point(280, 93);
            this.chkTutorialPublic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkTutorialPublic.Name = "chkTutorialPublic";
            this.chkTutorialPublic.Size = new System.Drawing.Size(62, 17);
            this.chkTutorialPublic.TabIndex = 66;
            this.chkTutorialPublic.Text = "isPublic";
            // 
            // txtTutorialTag
            // 
            this.txtTutorialTag.Location = new System.Drawing.Point(41, 254);
            this.txtTutorialTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTutorialTag.Multiline = true;
            this.txtTutorialTag.Name = "txtTutorialTag";
            this.txtTutorialTag.Size = new System.Drawing.Size(153, 39);
            this.txtTutorialTag.TabIndex = 65;
            // 
            // txtTutorialCode
            // 
            this.txtTutorialCode.Location = new System.Drawing.Point(41, 154);
            this.txtTutorialCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTutorialCode.Name = "txtTutorialCode";
            this.txtTutorialCode.Size = new System.Drawing.Size(153, 82);
            this.txtTutorialCode.TabIndex = 64;
            this.txtTutorialCode.Text = "";
            // 
            // txtTutorialDesc
            // 
            this.txtTutorialDesc.Location = new System.Drawing.Point(66, 75);
            this.txtTutorialDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTutorialDesc.Multiline = true;
            this.txtTutorialDesc.Name = "txtTutorialDesc";
            this.txtTutorialDesc.Size = new System.Drawing.Size(153, 58);
            this.txtTutorialDesc.TabIndex = 63;
            // 
            // txtTutorialTitle
            // 
            this.txtTutorialTitle.Location = new System.Drawing.Point(41, 23);
            this.txtTutorialTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTutorialTitle.Multiline = true;
            this.txtTutorialTitle.Name = "txtTutorialTitle";
            this.txtTutorialTitle.Size = new System.Drawing.Size(153, 31);
            this.txtTutorialTitle.TabIndex = 62;
            // 
            // listTutorials
            // 
            this.listTutorials.Dock = System.Windows.Forms.DockStyle.Right;
            this.listTutorials.FormattingEnabled = true;
            this.listTutorials.Location = new System.Drawing.Point(719, 2);
            this.listTutorials.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listTutorials.Name = "listTutorials";
            this.listTutorials.Size = new System.Drawing.Size(149, 311);
            this.listTutorials.TabIndex = 61;
            this.listTutorials.SelectedIndexChanged += new System.EventHandler(this.listTutorials_SelectedIndexChanged);
            // 
            // tabpageTemplateCode
            // 
            this.tabpageTemplateCode.Controls.Add(this.label18);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeLang);
            this.tabpageTemplateCode.Controls.Add(this.label19);
            this.tabpageTemplateCode.Controls.Add(this.label20);
            this.tabpageTemplateCode.Controls.Add(this.label21);
            this.tabpageTemplateCode.Controls.Add(this.label22);
            this.tabpageTemplateCode.Controls.Add(this.chkTemplateCodeisPublic);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTag);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeCode);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeDesc);
            this.tabpageTemplateCode.Controls.Add(this.txtTemplateCodeTitle);
            this.tabpageTemplateCode.Controls.Add(this.listBoxTemplateCode);
            this.tabpageTemplateCode.Location = new System.Drawing.Point(4, 22);
            this.tabpageTemplateCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageTemplateCode.Name = "tabpageTemplateCode";
            this.tabpageTemplateCode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabpageTemplateCode.Size = new System.Drawing.Size(870, 315);
            this.tabpageTemplateCode.TabIndex = 3;
            this.tabpageTemplateCode.Text = "Template Code";
            this.tabpageTemplateCode.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(209, 30);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 84;
            this.label18.Text = "Language";
            // 
            // txtTemplateCodeLang
            // 
            this.txtTemplateCodeLang.Location = new System.Drawing.Point(279, 24);
            this.txtTemplateCodeLang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTemplateCodeLang.Multiline = true;
            this.txtTemplateCodeLang.Name = "txtTemplateCodeLang";
            this.txtTemplateCodeLang.Size = new System.Drawing.Size(153, 31);
            this.txtTemplateCodeLang.TabIndex = 83;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 264);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 79;
            this.label19.Text = "Tags";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 182);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 80;
            this.label20.Text = "Code";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 93);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 13);
            this.label21.TabIndex = 81;
            this.label21.Text = "Description";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 24);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 82;
            this.label22.Text = "Name";
            // 
            // chkTemplateCodeisPublic
            // 
            this.chkTemplateCodeisPublic.AutoSize = true;
            this.chkTemplateCodeisPublic.Checked = true;
            this.chkTemplateCodeisPublic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTemplateCodeisPublic.Location = new System.Drawing.Point(279, 93);
            this.chkTemplateCodeisPublic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkTemplateCodeisPublic.Name = "chkTemplateCodeisPublic";
            this.chkTemplateCodeisPublic.Size = new System.Drawing.Size(62, 17);
            this.chkTemplateCodeisPublic.TabIndex = 78;
            this.chkTemplateCodeisPublic.Text = "isPublic";
            // 
            // txtTemplateCodeTag
            // 
            this.txtTemplateCodeTag.Location = new System.Drawing.Point(41, 254);
            this.txtTemplateCodeTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTemplateCodeTag.Multiline = true;
            this.txtTemplateCodeTag.Name = "txtTemplateCodeTag";
            this.txtTemplateCodeTag.Size = new System.Drawing.Size(153, 39);
            this.txtTemplateCodeTag.TabIndex = 77;
            // 
            // txtTemplateCodeCode
            // 
            this.txtTemplateCodeCode.Location = new System.Drawing.Point(41, 154);
            this.txtTemplateCodeCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTemplateCodeCode.Name = "txtTemplateCodeCode";
            this.txtTemplateCodeCode.Size = new System.Drawing.Size(153, 82);
            this.txtTemplateCodeCode.TabIndex = 76;
            this.txtTemplateCodeCode.Text = "";
            // 
            // txtTemplateCodeDesc
            // 
            this.txtTemplateCodeDesc.Location = new System.Drawing.Point(65, 75);
            this.txtTemplateCodeDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTemplateCodeDesc.Multiline = true;
            this.txtTemplateCodeDesc.Name = "txtTemplateCodeDesc";
            this.txtTemplateCodeDesc.Size = new System.Drawing.Size(153, 58);
            this.txtTemplateCodeDesc.TabIndex = 75;
            // 
            // txtTemplateCodeTitle
            // 
            this.txtTemplateCodeTitle.Location = new System.Drawing.Point(41, 23);
            this.txtTemplateCodeTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTemplateCodeTitle.Multiline = true;
            this.txtTemplateCodeTitle.Name = "txtTemplateCodeTitle";
            this.txtTemplateCodeTitle.Size = new System.Drawing.Size(153, 31);
            this.txtTemplateCodeTitle.TabIndex = 74;
            // 
            // listBoxTemplateCode
            // 
            this.listBoxTemplateCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxTemplateCode.FormattingEnabled = true;
            this.listBoxTemplateCode.Location = new System.Drawing.Point(719, 2);
            this.listBoxTemplateCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxTemplateCode.Name = "listBoxTemplateCode";
            this.listBoxTemplateCode.Size = new System.Drawing.Size(149, 311);
            this.listBoxTemplateCode.TabIndex = 73;
            this.listBoxTemplateCode.SelectedIndexChanged += new System.EventHandler(this.listBoxTemplateCode_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 140);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 29;
            // 
            // frmCodeBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 341);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmCodeBank";
            this.Text = "مدیریت کدها";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage txttabpageErrors;
        private System.Windows.Forms.TabPage tabpageInsert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkpubper;
        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.ComboBox cmbcat;
        private System.Windows.Forms.ComboBox cmblan;
        private System.Windows.Forms.RichTextBox txtcode;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Language;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn isPublic;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtErrorLang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkErrorPublic;
        private System.Windows.Forms.TextBox txtErrorTag;
        private System.Windows.Forms.RichTextBox txtErrorCode;
        private System.Windows.Forms.TextBox txtErrorDesc;
        private System.Windows.Forms.TextBox txtErrorTitle;
        private System.Windows.Forms.ListBox listErrors;
        private System.Windows.Forms.TabPage tabpageTutorials;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTutorialLang;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkTutorialPublic;
        private System.Windows.Forms.TextBox txtTutorialTag;
        private System.Windows.Forms.RichTextBox txtTutorialCode;
        private System.Windows.Forms.TextBox txtTutorialDesc;
        private System.Windows.Forms.TextBox txtTutorialTitle;
        private System.Windows.Forms.ListBox listTutorials;
        private System.Windows.Forms.TabPage tabpageTemplateCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTemplateCodeLang;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkTemplateCodeisPublic;
        private System.Windows.Forms.TextBox txtTemplateCodeTag;
        private System.Windows.Forms.RichTextBox txtTemplateCodeCode;
        private System.Windows.Forms.TextBox txtTemplateCodeDesc;
        private System.Windows.Forms.TextBox txtTemplateCodeTitle;
        private System.Windows.Forms.ListBox listBoxTemplateCode;
    }
}

