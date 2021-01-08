using System;
using System.Collections.Generic;

namespace APILivrosTeste.Models
{
    public partial class PublishingCompany
    {
        public PublishingCompany()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ChangeDate { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
