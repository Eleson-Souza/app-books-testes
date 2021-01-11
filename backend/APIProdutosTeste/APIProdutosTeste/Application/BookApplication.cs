using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using APILivrosTeste.Context;
using APILivrosTeste.Handler;
using APILivrosTeste.Models;

namespace APILivrosTeste.Application
{
    public class BookApplication
    {
        private ApiContext _context;

        public BookApplication(ApiContext context)
        {
            _context = context;
        }


        public List<BookList> GetAllBooks()
        {

            List<BookList> book = (from b in _context.Book 
                                   select new BookList
                                   {
                                       Title = b.Title,
                                       ChangeDate = b.ChangeDate,
                                       CreationDate = b.CreationDate,
                                       Description = b.Description,
                                       Id = b.Id,
                                       LastChapter = b.LastChapter,
                                       LastPage = b.LastPage,
                                       NumberOfPages = b.NumberOfPages,
                                       PublishingCompanyId = b.PublishingCompanyId,
                                       PurchaseDate = b.PurchaseDate,
                                   }).ToList();

            if(book.Count == 0)
            {
                return null;
            }

            return book;
        }

        public ResponseModel GetBookById(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var books = _context.Book.Where(item => item.Id == id).ToList();
                Book firstBook = books.FirstOrDefault();

                if (firstBook != null)
                {
                    response.Status = StatusCodes.Status200OK;
                    response.DataBook = firstBook;
                }
                else
                {
                    response.Status = StatusCodes.Status404NotFound;
                    response.Message = "Não foi encontrado nenhum livro com esse ID!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";
                
                return response;
            }
        }

        public string InsertBook(Book book)
        {
            try
            {
                if(book.Title != "")
                { 
                    _context.Book.Add(book);
                    _context.SaveChanges();

                    return "Livro cadastrado com sucesso!";
                }
                else
                {
                    return "Livro inválido!";
                }
            }
            catch (Exception)
            {
                
                return null;
            }
        }

        public ResponseModel UpdateBook(Book book)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var bookSearch = GetBookById(book.Id).DataBook;

                if(bookSearch == null)
                {
                    response.Status = StatusCodes.Status404NotFound;
                    response.Message = "Este livro não existe no banco de dados!";

                    return response;
                }

                bookSearch.PurchaseDate= book.PurchaseDate;
                bookSearch.Description = book.Description;
                bookSearch.NumberOfPages = book.NumberOfPages;
                bookSearch.Title = book.Title;
                bookSearch.PublishingCompanyId= book.PublishingCompanyId;
                bookSearch.LastPage = book.LastPage;
                bookSearch.LastChapter = book.LastChapter;
                bookSearch.ChangeDate= DateTime.Now;

                _context.Update(bookSearch);
                _context.SaveChanges();

                response.Status = StatusCodes.Status200OK;
                response.Message = $"O livro '{bookSearch.Title}' foi atualizado com sucesso!";

                return response;
                
            }
            catch (Exception)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Houve um erro ao se comunicar com o banco de dados!";

                return response;
            }
        }
        public ResponseModel DeleteBook(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (id != null)
                {
                    var book = (from b in _context.Book
                                where b.Id == id
                                select b).FirstOrDefault();

                    if (book != null)
                    {
                        _context.Book.Remove(book);
                        _context.SaveChanges();

                        response.Status = StatusCodes.Status200OK;
                        response.Message = $"Livro {book.Title} deletado com sucesso!";
                    }
                    else
                    {
                        response.Status = StatusCodes.Status404NotFound;
                        response.Message = "Nenhum livro encontrado com esse ID!";
                    }
                }
                else
                {
                    response.Status = StatusCodes.Status400BadRequest;
                    response.Message = "O Id informado está inválido!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = StatusCodes.Status500InternalServerError;
                response.Message = "Erro ao se comunicar com o banco de dados!";

                return response;
            }
        }
    }
}
