using System.Data.SQLite;

namespace CodeBank.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();

                const string sql = @"
CREATE TABLE IF NOT EXISTS CodeFormFile (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Description TEXT,
    Code TEXT NOT NULL,
    Language TEXT NOT NULL,
    Category TEXT NOT NULL,
    Tag TEXT,
    isPublic INTEGER NOT NULL DEFAULT 1,
    CreateAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS IX_CodeFormFile_Category
ON CodeFormFile(Category);

CREATE INDEX IF NOT EXISTS IX_CodeFormFile_CreateAt
ON CodeFormFile(CreateAt);
";

                using (var command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
