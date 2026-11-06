using System;
using System.Data.SQLite;
using System.IO;

namespace CodeBank.Data
{
    public static class Database
    {
        private static readonly string DatabaseDirectory =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Matin-dev-2010",
                "CodeBank");

        private static readonly string DatabasePath =
            Path.Combine(DatabaseDirectory, "database.db");

        private static readonly string LegacyDatabasePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");

        public static SQLiteConnection CreateConnection()
        {
            EnsureDatabaseLocation();

            var builder = new SQLiteConnectionStringBuilder
            {
                DataSource = DatabasePath,
                Version = 3
            };

            return new SQLiteConnection(builder.ConnectionString);
        }

        private static void EnsureDatabaseLocation()
        {
            Directory.CreateDirectory(DatabaseDirectory);
            MigrateLegacyDatabase(LegacyDatabasePath, DatabasePath);
        }

        internal static void MigrateLegacyDatabase(string legacyPath, string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(legacyPath))
                throw new ArgumentException("مسیر دیتابیس قدیمی معتبر نیست.", "legacyPath");

            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException("مسیر دیتابیس جدید معتبر نیست.", "destinationPath");

            if (File.Exists(destinationPath) || !File.Exists(legacyPath))
                return;

            var destinationDirectory = Path.GetDirectoryName(destinationPath);
            if (!string.IsNullOrEmpty(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var temporaryPath = destinationPath + ".migration";
            var copiedSidecars = new[] { "-wal", "-journal" };
            var databaseMoved = false;
            var movedSidecars = new System.Collections.Generic.List<string>();

            try
            {
                DeleteIfExists(temporaryPath);
                foreach (var suffix in copiedSidecars)
                    DeleteIfExists(temporaryPath + suffix);

                File.Copy(legacyPath, temporaryPath, false);

                foreach (var suffix in copiedSidecars)
                {
                    var sourceSidecar = legacyPath + suffix;
                    if (File.Exists(sourceSidecar))
                        File.Copy(sourceSidecar, temporaryPath + suffix, false);
                }

                File.Move(temporaryPath, destinationPath);
                databaseMoved = true;

                foreach (var suffix in copiedSidecars)
                {
                    var temporarySidecar = temporaryPath + suffix;
                    if (!File.Exists(temporarySidecar))
                        continue;

                    var destinationSidecar = destinationPath + suffix;
                    File.Move(temporarySidecar, destinationSidecar);
                    movedSidecars.Add(destinationSidecar);
                }
            }
            catch
            {
                if (databaseMoved)
                {
                    DeleteIfExists(destinationPath);
                    foreach (var sidecar in movedSidecars)
                        DeleteIfExists(sidecar);
                }

                throw;
            }
            finally
            {
                DeleteIfExists(temporaryPath);
                foreach (var suffix in copiedSidecars)
                    DeleteIfExists(temporaryPath + suffix);
            }
        }

        private static void DeleteIfExists(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
