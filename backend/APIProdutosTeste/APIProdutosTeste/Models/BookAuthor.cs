using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class BookAuthor
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}
