using System;
using System.Data.SQLite;

namespace CodeBank.Data
{
    public static class DatabaseInitializer
    {
        private const int CurrentSchemaVersion = 1;

        public static void Initialize()
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    int databaseVersion;
                    using (var versionCommand = new SQLiteCommand("PRAGMA user_version;", connection, transaction))
                    {
                        databaseVersion = Convert.ToInt32(versionCommand.ExecuteScalar());
                    }

                    if (databaseVersion > CurrentSchemaVersion)
                    {
                        throw new InvalidOperationException(
                            "نسخه دیتابیس از نسخه پشتیبانی‌شده برنامه جدیدتر است. برنامه را به‌روزرسانی کنید.");
                    }

                    if (databaseVersion < 1)
                    {
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

                        using (var command = new SQLiteCommand(sql, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                        }

                        using (var versionCommand = new SQLiteCommand(
                            "PRAGMA user_version = 1;", connection, transaction))
                        {
                            versionCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
