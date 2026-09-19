using System;
using System.Collections.Generic;
using CodeBank.Data;
using CodeBank.Models;

namespace CodeBank.Services
{
    public class CodeItemService
    {
        private readonly CodeRepository _repository;

        public CodeItemService(CodeRepository repository)
        {
            _repository = repository;
        }

        public List<CodeItem> GetAll()
        {
            return _repository.GetAll();
        }

        public List<CodeItem> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("دسته‌بندی نامعتبر است.", "category");

            return _repository.GetByCategory(category);
        }

        public CodeItem GetById(long id)
        {
            if (id <= 0)
                return null;

            return _repository.GetById(id);
        }

        public long Create(CodeItem item)
        {
            Validate(item);
            return _repository.Insert(item);
        }

        public void Update(CodeItem item)
        {
            if (item == null || item.Id <= 0)
                throw new ArgumentException("رکورد برای بروزرسانی معتبر نیست.", "item");

            Validate(item);
            _repository.Update(item);
        }

        public void Delete(long id)
        {
            if (id <= 0)
                throw new ArgumentException("شناسه رکورد معتبر نیست.", "id");

            _repository.Delete(id);
        }

        private static void Validate(CodeItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            if (string.IsNullOrWhiteSpace(item.Title))
                throw new ArgumentException("عنوان الزامی است.");

            if (string.IsNullOrWhiteSpace(item.Code))
                throw new ArgumentException("کد الزامی است.");

            if (string.IsNullOrWhiteSpace(item.Language))
                throw new ArgumentException("زبان برنامه‌نویسی الزامی است.");

            if (string.IsNullOrWhiteSpace(item.Category))
                throw new ArgumentException("دسته‌بندی الزامی است.");
        }
    }
}
