using System;
using System.Data.SQLite;
using System.IO;

namespace CodeBank.Data
{
    public static class Database
    {
        private static readonly string DatabasePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        private static readonly string ConnectionString =
            string.Format("Data Source={0};Version=3;", DatabasePath);

        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
