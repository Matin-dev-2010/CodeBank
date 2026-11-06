using System.Collections.Generic;
using CodeBank.Models;

namespace CodeBank.Data
{
    public interface ICodeRepository
    {
        List<CodeItem> GetAll();
        List<CodeItem> GetByCategory(string category);
        List<CodeItem> Search(string query);
        CodeItem GetById(long id);
        long Insert(CodeItem item);
        void Update(CodeItem item);
        void Delete(long id);
    }
}
