using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILivrosTeste.Handler
{
    public class BookList
    {
        public int Id { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Description { get; set; }
        public int? NumberOfPages { get; set; }
        public string Title { get; set; }
        public int? PublishingCompanyId { get; set; }
        public int? LastPage { get; set; }
        public int? LastChapter { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; } 
    }
}
