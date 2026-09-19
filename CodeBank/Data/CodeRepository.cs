using System;
using System.Collections.Generic;
using System.Data.SQLite;
using CodeBank.Models;

namespace CodeBank.Data
{
    public class CodeRepository
    {
        public List<CodeItem> GetAll()
        {
            const string sql = @"
SELECT Id, Title, Description, Code, Language, Category, Tag, isPublic, CreateAt
FROM CodeFormFile
ORDER BY CreateAt DESC, Id DESC;";

            return ExecuteList(sql);
        }

        public List<CodeItem> GetByCategory(string category)
        {
            const string sql = @"
SELECT Id, Title, Description, Code, Language, Category, Tag, isPublic, CreateAt
FROM CodeFormFile
WHERE Category = @Category
ORDER BY CreateAt DESC, Id DESC;";

            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Category", category);
                connection.Open();
                return ReadList(command);
            }
        }

        public CodeItem GetById(long id)
        {
            const string sql = @"
SELECT Id, Title, Description, Code, Language, Category, Tag, isPublic, CreateAt
FROM CodeFormFile
WHERE Id = @Id
LIMIT 1;";

            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return Map(reader);
                }
            }
        }

        public long Insert(CodeItem item)
        {
            const string sql = @"
INSERT INTO CodeFormFile
(Title, Description, Code, Language, Category, Tag, isPublic)
VALUES
(@Title, @Description, @Code, @Language, @Category, @Tag, @IsPublic);

SELECT last_insert_rowid();";

            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                AddParameters(command, item);
                connection.Open();
                return Convert.ToInt64(command.ExecuteScalar());
            }
        }

        public void Update(CodeItem item)
        {
            const string sql = @"
UPDATE CodeFormFile
SET Title = @Title,
    Description = @Description,
    Code = @Code,
    Language = @Language,
    Category = @Category,
    Tag = @Tag,
    isPublic = @IsPublic
WHERE Id = @Id;";

            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                AddParameters(command, item);
                command.Parameters.AddWithValue("@Id", item.Id);
                connection.Open();

                if (command.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("رکورد موردنظر برای بروزرسانی پیدا نشد.");
            }
        }

        public void Delete(long id)
        {
            const string sql = "DELETE FROM CodeFormFile WHERE Id = @Id;";

            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();

                if (command.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("رکورد موردنظر برای حذف پیدا نشد.");
            }
        }

        private static List<CodeItem> ExecuteList(string sql)
        {
            using (var connection = Database.CreateConnection())
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                return ReadList(command);
            }
        }

        private static List<CodeItem> ReadList(SQLiteCommand command)
        {
            var items = new List<CodeItem>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    items.Add(Map(reader));
            }

            return items;
        }

        private static CodeItem Map(SQLiteDataReader reader)
        {
            return new CodeItem
            {
                Id = Convert.ToInt64(reader["Id"]),
                Title = Convert.ToString(reader["Title"]),
                Description = reader["Description"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Description"]),
                Code = Convert.ToString(reader["Code"]),
                Language = Convert.ToString(reader["Language"]),
                Category = Convert.ToString(reader["Category"]),
                Tag = reader["Tag"] == DBNull.Value ? string.Empty : Convert.ToString(reader["Tag"]),
                IsPublic = Convert.ToInt32(reader["isPublic"]) == 1,
                CreateAt = reader["CreateAt"] == DBNull.Value ? System.DateTime.MinValue : Convert.ToDateTime(reader["CreateAt"])
            };
        }

        private static void AddParameters(SQLiteCommand command, CodeItem item)
        {
            command.Parameters.AddWithValue("@Title", item.Title);
            command.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(item.Description) ? (object)DBNull.Value : item.Description);
            command.Parameters.AddWithValue("@Code", item.Code);
            command.Parameters.AddWithValue("@Language", item.Language);
            command.Parameters.AddWithValue("@Category", item.Category);
            command.Parameters.AddWithValue("@Tag", string.IsNullOrWhiteSpace(item.Tag) ? (object)DBNull.Value : item.Tag);
            command.Parameters.AddWithValue("@IsPublic", item.IsPublic ? 1 : 0);
        }
    }
}
