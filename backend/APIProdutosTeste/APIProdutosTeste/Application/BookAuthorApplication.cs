using APILivrosTeste.Context;
using APILivrosTeste.Handler;
using APILivrosTeste.Models;
using System;
using System.Linq;

namespace APILivrosTeste.Application
{
    public class BookAuthorApplication
    {
        private ApiContext _context;
        private ResponseModel response = new ResponseModel();

        public BookAuthorApplication(ApiContext context)
        {
            _context = context;
        }

        public ResponseModel InsertBookAuthor(BookAuthor bookAuthor)
        {
            try
            {
                bookAuthor.CreationDate = DateTime.Now;

                _context.BookAuthor.Add(bookAuthor);
                _context.SaveChanges();

                response.DataBooksAuthors = _context.BookAuthor.Select(item => item).ToList();

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel UpdateBookAuthor(BookAuthor bookAuthor, int id)
        {
            try
            {
                var authorBookSearch = _context.BookAuthor.Where(booAut => booAut.Id == id).FirstOrDefault();

                if (authorBookSearch != null)
                {
                    authorBookSearch.BookId = bookAuthor.BookId;
                    authorBookSearch.AuthorId = bookAuthor.AuthorId;
                    authorBookSearch.CreationDate = bookAuthor.CreationDate;
                    authorBookSearch.ChangeDate = DateTime.Now;

                    _context.BookAuthor.Update(authorBookSearch);
                    _context.SaveChanges();

                    response.Status = 200;
                    response.Message = "Atualização realizada com sucesso!";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "O código informado não existe na base de dados!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel DeleteBookAuthor(int id)
        {
            try
            {
                var authorBookSearch = _context.BookAuthor.Where(booAut => booAut.Id == id).FirstOrDefault();

                if (authorBookSearch != null)
                {
                    _context.BookAuthor.Remove(authorBookSearch);
                    _context.SaveChanges();

                    response.Status = 200;
                    response.Message = "Exclusão realizada com sucesso!";
                }
                else
                {
                    response.Status = 400;
                    response.Message = "O código passado não pertence a nenhum registro!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel GetAllBookAuthor()
        {
            try
            {
                var allBookAuthor = _context.BookAuthor.Select(item => item).ToList();

                response.DataBooksAuthors = allBookAuthor;

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel GetOneBookAuthor(int id)
        {
            try
            {
                var bookAuthorSearch = _context.BookAuthor.Where(booAut => booAut.Id == id).FirstOrDefault();

                if (bookAuthorSearch != null)
                {
                    response.DataBookAuthor = bookAuthorSearch;
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Não foi encontrado nenhum registro com esse ID";
                }


                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro ao acessar o banco de dados!";

                return response;
            }
        }
    }
}
