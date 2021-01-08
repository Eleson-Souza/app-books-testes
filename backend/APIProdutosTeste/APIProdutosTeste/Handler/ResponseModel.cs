using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILivrosTeste.Models;

namespace APILivrosTeste.Handler
{
    /* classe serve de objeto para a classe application, de forma que possa enviar 
    informações relevantes como status code e mensagem via objeto para o controller. */
    public class ResponseModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Book DataBook { get; set; }
        public Author DataAuthor { get; set; }
        public List<Author> DataAuthors { get; set; }
        public BookAuthor DataBookAuthor { get; set; }
        public List<BookAuthor> DataBooksAuthors { get; set; }
    }
}
