using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class Book
    {
        public Book()
        {
            BookAuthor = new HashSet<BookAuthor>();
            BookGenre = new HashSet<BookGenre>();
        }

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

        public virtual PublishingCompany PublishingCompany { get; set; }
        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
        public virtual ICollection<BookGenre> BookGenre { get; set; }
    }
}
