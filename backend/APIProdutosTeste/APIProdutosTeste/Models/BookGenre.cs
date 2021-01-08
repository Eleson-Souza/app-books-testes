﻿using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
