using System;

namespace CodeBank.Models
{
    public class CodeItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Tag { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreateAt { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Title, Language);
        }
    }
}
