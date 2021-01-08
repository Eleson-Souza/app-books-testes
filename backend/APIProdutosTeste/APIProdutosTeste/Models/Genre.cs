using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenre = new HashSet<BookGenre>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual ICollection<BookGenre> BookGenre { get; set; }
    }
}
