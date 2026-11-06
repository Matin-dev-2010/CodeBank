using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeBank.Data;
using CodeBank.Models;
using CodeBank.Services;
using NUnit.Framework;

namespace CodeBank.Tests
{
    [TestFixture]
    public class CodeItemServiceTests
    {
        private InMemoryCodeRepository _repository;
        private CodeItemService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = new InMemoryCodeRepository();
            _service = new CodeItemService(_repository);
        }

        [Test]
        public void Create_ValidItem_StoresItemAndReturnsId()
        {
            var id = _service.Create(ValidItem());

            Assert.That(id, Is.EqualTo(1));
            Assert.That(_repository.GetById(id).Title, Is.EqualTo("Example"));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Create_WithoutTitle_Throws(string title)
        {
            var item = ValidItem();
            item.Title = title;

            Assert.Throws<ArgumentException>(() => _service.Create(item));
            Assert.That(_repository.Items, Is.Empty);
        }

        [Test]
        public void Create_NullItem_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _service.Create(null));
        }

        [Test]
        public void Constructor_NullRepository_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new CodeItemService(null));
        }

        [TestCase("code")]
        [TestCase("language")]
        [TestCase("category")]
        public void Create_WithoutOtherRequiredField_Throws(string field)
        {
            var item = ValidItem();

            if (field == "code") item.Code = " ";
            if (field == "language") item.Language = "";
            if (field == "category") item.Category = null;

            Assert.Throws<ArgumentException>(() => _service.Create(item));
            Assert.That(_repository.Items, Is.Empty);
        }


        [Test]
        public void Update_ValidItem_ChangesStoredItem()
        {
            var item = ValidItem();
            item.Id = _service.Create(item);
            item.Title = "Updated";

            _service.Update(item);

            Assert.That(_repository.GetById(item.Id).Title, Is.EqualTo("Updated"));
        }

        [Test]
        public void Update_WithoutValidId_Throws()
        {
            var item = ValidItem();

            Assert.Throws<ArgumentException>(() => _service.Update(item));
        }

        [Test]
        public void Delete_ExistingItem_RemovesIt()
        {
            var id = _service.Create(ValidItem());

            _service.Delete(id);

            Assert.That(_repository.GetById(id), Is.Null);
        }

        [Test]
        public void Delete_InvalidId_Throws()
        {
            Assert.Throws<ArgumentException>(() => _service.Delete(0));
        }

        [Test]
        public void GetById_InvalidId_ReturnsNullWithoutRepositoryCall()
        {
            Assert.That(_service.GetById(-1), Is.Null);
            Assert.That(_repository.GetByIdCalls, Is.Zero);
        }

        [Test]
        public void GetByCategory_EmptyCategory_Throws()
        {
            Assert.Throws<ArgumentException>(() => _service.GetByCategory(" "));
        }

        [Test]
        public void Search_MatchesTitleCodeAndTag()
        {
            var titleId = _service.Create(new CodeItem
            {
                Title = "Async Examples", Code = "await Task.Delay(1);",
                Language = "C#", Category = "Tutorial", Tag = "async"
            });
            var codeId = _service.Create(new CodeItem
            {
                Title = "Console Sample", Code = "Console.WriteLine(\"hello\");",
                Language = "C#", Category = "Tutorial", Tag = "console"
            });
            var tagId = _service.Create(new CodeItem
            {
                Title = "Array Helpers", Code = "var values = new int[3];",
                Language = "C#", Category = "Snippet", Tag = "collections"
            });

            Assert.That(_service.Search("async").Exists(x => x.Id == titleId), Is.True);
            Assert.That(_service.Search("WRITELINE").Exists(x => x.Id == codeId), Is.True);
            Assert.That(_service.Search("COLLECTIONS").Exists(x => x.Id == tagId), Is.True);
        }

        [Test]
        public void Search_Whitespace_ReturnsEmptyList()
        {
            Assert.That(_service.Search("   "), Is.Empty);
        }

        private static CodeItem ValidItem()
        {
            return new CodeItem
            {
                Title = "Example",
                Description = "Description",
                Code = "Console.WriteLine(1);",
                Language = "C#",
                Category = "Tutorial",
                Tag = "sample",
                IsPublic = true
            };
        }

        private sealed class InMemoryCodeRepository : ICodeRepository
        {
            private readonly List<CodeItem> _items = new List<CodeItem>();
            private long _nextId = 1;

            public IList<CodeItem> Items { get { return _items; } }
            public int GetByIdCalls { get; private set; }

            public List<CodeItem> GetAll()
            {
                return _items.ToList();
            }

            public List<CodeItem> GetByCategory(string category)
            {
                return _items.Where(x => x.Category == category).ToList();
            }

            public List<CodeItem> Search(string query)
            {
                return _items.Where(x =>
                    (x.Title ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Description ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Code ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Language ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Category ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (x.Tag ?? string.Empty).IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            public CodeItem GetById(long id)
            {
                GetByIdCalls++;
                return _items.FirstOrDefault(x => x.Id == id);
            }

            public long Insert(CodeItem item)
            {
                var copy = Copy(item);
                copy.Id = _nextId++;
                _items.Add(copy);
                return copy.Id;
            }

            public void Update(CodeItem item)
            {
                var existing = _items.FirstOrDefault(x => x.Id == item.Id);
                if (existing == null)
                    throw new InvalidOperationException();

                var index = _items.IndexOf(existing);
                _items[index] = Copy(item);
            }

            public void Delete(long id)
            {
                var existing = _items.FirstOrDefault(x => x.Id == id);
                if (existing == null)
                    throw new InvalidOperationException();

                _items.Remove(existing);
            }

            private static CodeItem Copy(CodeItem item)
            {
                return new CodeItem
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Code = item.Code,
                    Language = item.Language,
                    Category = item.Category,
                    Tag = item.Tag,
                    IsPublic = item.IsPublic,
                    CreateAt = item.CreateAt
                };
            }
        }
    }

    [TestFixture]
    public class DatabaseMigrationTests
    {
        private string _root;

        [SetUp]
        public void SetUp()
        {
            _root = Path.Combine(Path.GetTempPath(), "CodeBank.Tests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_root);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_root))
                Directory.Delete(_root, true);
        }

        [Test]
        public void MigrateLegacyDatabase_CopiesDatabaseAndPreservesOriginal()
        {
            var legacy = Path.Combine(_root, "legacy.db");
            var destination = Path.Combine(_root, "user-data", "database.db");
            File.WriteAllText(legacy, "legacy database bytes");

            Database.MigrateLegacyDatabase(legacy, destination);

            Assert.That(File.ReadAllText(destination), Is.EqualTo("legacy database bytes"));
            Assert.That(File.Exists(legacy), Is.True);
        }

        [Test]
        public void MigrateLegacyDatabase_CopiesWalFile()
        {
            var legacy = Path.Combine(_root, "legacy.db");
            var destination = Path.Combine(_root, "database.db");
            File.WriteAllText(legacy, "database");
            File.WriteAllText(legacy + "-wal", "wal");

            Database.MigrateLegacyDatabase(legacy, destination);

            Assert.That(File.ReadAllText(destination + "-wal"), Is.EqualTo("wal"));
        }

        [Test]
        public void MigrateLegacyDatabase_DoesNotOverwriteExistingDestination()
        {
            var legacy = Path.Combine(_root, "legacy.db");
            var destination = Path.Combine(_root, "database.db");
            File.WriteAllText(legacy, "old data");
            File.WriteAllText(destination, "newer user data");

            Database.MigrateLegacyDatabase(legacy, destination);

            Assert.That(File.ReadAllText(destination), Is.EqualTo("newer user data"));
            Assert.That(File.Exists(legacy), Is.True);
        }

        [Test]
        public void MigrateLegacyDatabase_WhenLegacyFileIsMissing_DoesNothing()
        {
            var legacy = Path.Combine(_root, "missing.db");
            var destination = Path.Combine(_root, "database.db");

            Database.MigrateLegacyDatabase(legacy, destination);

            Assert.That(File.Exists(destination), Is.False);
        }
    }
}
