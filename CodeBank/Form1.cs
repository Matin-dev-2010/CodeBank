using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CodeBank
{
    public partial class frmCodeBank : Form
    {
        public frmCodeBank()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper.CreateTables();
            LoadDataGridView();
            LoadDataTabErrors();
            LoadDataTabTutorials();
            LoadDataTabTemplateCode();

            cmblan.Items.AddRange(new string[] { "C#", "JavaScript", "Python", "Java", "PHP", "Go", "Rust", "C++" });
            cmbcat.Items.AddRange(new string[] { "خطاها", "اموزشی", "کد اماده", "الگوها", "الگوریتم", "سایر" });
        }

        private void ClearFields()
        {
            txtname.Clear();
            txtdesc.Clear();
            txtcode.Clear();
            cmblan.SelectedIndex = -1;
            cmbcat.SelectedIndex = -1;
            txttag.Clear();
            checkpubper.Checked = true;
            txtname.Focus();
        }

        private void LoadDataGridView()
        {
            try
            {
                // ۱. غیرفعال کردن تولید خودکار ستون‌ها
                dataGridView1.AutoGenerateColumns = false;

                // ۲. اتصال هر ستون به فیلد دیتابیس
                dataGridView1.Columns["Id"].DataPropertyName = "Id";
                dataGridView1.Columns["Title"].DataPropertyName = "Title";
                dataGridView1.Columns["Language"].DataPropertyName = "Language";
                dataGridView1.Columns["Category"].DataPropertyName = "Category";
                dataGridView1.Columns["isPublic"].DataPropertyName = "isPublic";
                dataGridView1.Columns["CreateAt"].DataPropertyName = "CreateAt";

                // ۳. دریافت داده از دیتابیس
                DataTable dt = DatabaseHelper.LoadAllData();
                
                // ۴. اتصال به DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری: {ex.Message}");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string title = txtname.Text.Trim();
            string description = txtdesc.Text.Trim();
            string code = txtcode.Text;
            string language = cmblan.SelectedItem?.ToString() ?? "";
            string category = cmbcat.SelectedItem?.ToString() ?? "";
            string tag = txttag.Text.Trim();
            bool isPublic = checkpubper.Checked;
            

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("لطفاً عنوان را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtname.Focus();
                return;
            }

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("لطفاً کد را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcode.Focus();
                return;
            }

            if (string.IsNullOrEmpty(language))
            {
                MessageBox.Show("لطفاً زبان برنامه‌نویسی را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmblan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("لطفاً دسته بندی خودتان را انتخاب کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbcat.Focus();
                return;
            }

            try
            {
                DatabaseHelper.SaveData(title, description, code, language, category, tag, isPublic);
                MessageBox.Show("اطلاعات با موفقیت ذخیره شد", "موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                LoadDataGridView();
                LoadDataTabErrors();
                LoadDataTabTutorials();
                LoadDataTabTemplateCode();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"خطا در ذخیره سازی: {ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataTabErrors()
        {
            try
            {
                DataTable dt = DatabaseHelper.LoadDataByCategory("خطاها");

                
                listErrors.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string titleTabError = row["Title"].ToString();
                    string lnaguageTabError = row["Language"].ToString();
                    string displayTextTabErrorList = $"{titleTabError} ({lnaguageTabError})";
                    listErrors.Items.Add(displayTextTabErrorList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری خطاها: {ex.Message}");
            }
        }

        private void listErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ۱. اگر چیزی انتخاب نشده بود، برگرد
            if (listErrors.SelectedIndex == -1)
                return;

            // ۲. گرفتن عنوان انتخاب‌شده (بدون زبان)
            string selectedItem = listErrors.SelectedItem.ToString();
            string title = selectedItem.Split('(')[0].Trim(); // "اتصال به SQLite"

            // ۳. جستجو در دیتابیس بر اساس عنوان
            DataTable dt = DatabaseHelper.LoadDataByCategory("خطاها");
            DataRow[] rows = dt.Select($"Title = '{title.Replace("'", "''")}'");

            if (rows.Length == 0)
                return;

            DataRow row = rows[0];

            // ۴. نمایش در TextBoxها
            txtErrorTitle.Text = row["Title"].ToString();
            txtErrorDesc.Text = row["Description"].ToString();
            txtErrorCode.Text = row["Code"].ToString();
            txtErrorLang.Text = row["Language"].ToString();
            txtErrorTag.Text = row["Tag"].ToString();
            chkErrorPublic.Checked = row["isPublic"].ToString() == "1";
        }

        private void LoadDataTabTutorials()
        {
            try
            {
                DataTable dt = DatabaseHelper.LoadDataByCategory("اموزشی");
                listTutorials.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string title = row["Title"].ToString();
                    string language = row["Language"].ToString();
                    listTutorials.Items.Add($"{title} ({language})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری آموزشی: {ex.Message}");
            }
        }

        private void listTutorials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTutorials.SelectedIndex == -1)
                return;

            string selectedItem = listTutorials.SelectedItem.ToString();
            string title = selectedItem.Split('(')[0].Trim();

            DataTable dt = DatabaseHelper.LoadDataByCategory("اموزشی");
            DataRow[] rows = dt.Select($"Title = '{title.Replace("'", "''")}'");
            

            if (rows.Length == 0)
                return;

            DataRow row = rows[0];

            txtTutorialTitle.Text = row["Title"].ToString();
            txtTutorialDesc.Text = row["Description"].ToString();
            txtTutorialCode.Text = row["Code"].ToString();
            txtTutorialLang.Text = row["Language"].ToString();
            txtTutorialTag.Text = row["Tag"].ToString();
            chkTutorialPublic.Checked = row["isPublic"].ToString() == "1";
        }

        private void LoadDataTabTemplateCode()
        {
            try
            {
                DataTable dt = DatabaseHelper.LoadDataByCategory("کد اماده");
                listBoxTemplateCode.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string title = row["Title"].ToString();
                    string language = row["Language"].ToString();
                    listBoxTemplateCode.Items.Add($"{title} ({language})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در بارگذاری کد های اماده: {ex.Message}");
            }
        }

        private void listBoxTemplateCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTemplateCode.SelectedIndex == -1)
                return;

            string selectedItem = listBoxTemplateCode.SelectedItem.ToString();
            string title = selectedItem.Split('(')[0].Trim();

            DataTable dt = DatabaseHelper.LoadDataByCategory("کد اماده");
            DataRow[] rows = dt.Select($"Title = '{title.Replace("'", "''")}'");


            if (rows.Length == 0)
                return;

            DataRow row = rows[0];

            txtTemplateCodeTitle.Text = row["Title"].ToString();
            txtTemplateCodeDesc.Text = row["Description"].ToString();
            txtTemplateCodeCode.Text = row["Code"].ToString();
            txtTemplateCodeLang.Text = row["Language"].ToString();
            txtTemplateCodeTag.Text = row["Tag"].ToString();
            chkTemplateCodeisPublic.Checked = row["isPublic"].ToString() == "1";
        }
    }


    public static class DatabaseHelper
    {
        // ✅ اصلاح: Data Source (با C)
        private static string connectionstring = "Data Source=database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionstring);
        }

        public static void CreateTables()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"
                CREATE TABLE IF NOT EXISTS CodeFormFile (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Description TEXT,
                    Code TEXT NOT NULL,
                    Language TEXT NOT NULL,
                    Category TEXT NOT NULL,
                    Tag TEXT, 
                    isPublic INTEGER,
                    CreateAt DATETIME DEFAULT CURRENT_TIMESTAMP
                );
            ";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void SaveData(string Title, string Description, string Code, string Language, string Category, string Tag, bool isPublic)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT OR REPLACE INTO CodeFormFile 
            (Title, Description, Code, Language, Category, Tag, isPublic) 
            VALUES (@Title, @Description, @Code, @Language, @Category, @Tag, @isPublic)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Code", Code);
                    cmd.Parameters.AddWithValue("@Language", Language);
                    cmd.Parameters.AddWithValue("@Category", (object)Category ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tag", (object)Tag ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@isPublic", isPublic ? 1 : 0);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable LoadAllData()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Title, Language, Category, CASE WHEN isPublic = 1 THEN 'بله' ELSE 'خیر' END AS isPublic, CreateAt FROM CodeFormFile ORDER BY CreateAt DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable LoadDataByCategory(string category)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Title, Language, Category, isPublic, CreateAt, Code, Description, Tag " +
                               "FROM CodeFormFile " +
                               "WHERE Category = @Category " +
                               "ORDER BY CreateAt DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
