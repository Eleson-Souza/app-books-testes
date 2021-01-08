using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthor = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationaly { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual ICollection<BookAuthor> BookAuthor { get; set; }
    }
}
