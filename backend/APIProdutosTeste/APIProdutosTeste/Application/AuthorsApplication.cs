using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILivrosTeste.Context;
using APILivrosTeste.Handler;
using APILivrosTeste.Models;

namespace APILivrosTeste.Application
{
    public class AuthorsApplication
    {
        private ApiContext _context;
        private ResponseModel response = new ResponseModel();

        public AuthorsApplication(ApiContext context)
        {
            _context = context;
        }

        public ResponseModel GetAllAuthors()
        {
            try
            {
                var authors = _context.Author.Select(aut => aut).ToList();

                if (authors == null)
                {
                    response.Status = 404;
                    response.Message = "A listagem de autores está vazia!";
                }

                response.DataAuthors = authors;

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel GetAuthor(int id)
        {
            try
            {
                var author = _context.Author.Where(aut => aut.Id == id).FirstOrDefault();

                if(author != null)
                {
                    response.Status = 200;
                    response.DataAuthor = author;
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Não há nenhum autor com esse Id!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel InsertAuthor(Author author)
        {
            try
            {
                author.CreationDate = DateTime.Now;

                _context.Author.Add(author);
                _context.SaveChanges();

                response.DataAuthors = _context.Author.Select(item => item).ToList();
                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel UpdateAuthor(Author author)
        {
            try
            {
                var findAuthor = _context.Author.Where(aut => aut.Id == author.Id).FirstOrDefault();

                if(findAuthor != null)
                {
                    findAuthor.Nome = author.Nome;
                    findAuthor.Sobrenome = author.Sobrenome;
                    findAuthor.DateOfBirth = author.DateOfBirth;
                    findAuthor.Nationaly = author.Nationaly;
                    findAuthor.CreationDate = author.CreationDate;
                    findAuthor.ChangeDate = DateTime.Now;

                    _context.Author.Update(findAuthor);
                    _context.SaveChanges();

                    response.Status = 200;
                    response.Message = "Autor atualizado com sucesso!";
                }
                else
                {
                    response.Status = 404;
                    response.Message = "Não existe um autor com o Id informado!";
                }

                return response;
            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";

                return response;
            }
        }

        public ResponseModel DeleteAuthor(int id)
        {
            try
            {
                var findAuthor = (from aut in _context.Author
                                  where aut.Id == id
                                  select aut).FirstOrDefault();

                if(findAuthor != null)
                {
                    _context.Remove(findAuthor);
                    _context.SaveChanges();

                    response.Status = 200;
                    response.Message = "Autor excluído com sucesso!";
                }
                else
                {
                    response.Status = 404;
                    response.Message = "O autor informado não existe no banco de dados!";
                }

                return response;

            }
            catch (Exception)
            {
                response.Status = 500;
                response.Message = "Houve um erro interno ao acessar o banco de dados!";

                return response;
            }
        }
    }
}
