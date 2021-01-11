using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILivrosTeste.Context;
using APILivrosTeste.Models;
using APILivrosTeste.Application;
using Microsoft.AspNetCore.Cors;

namespace APILivrosTeste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private ApiContext _context;

        public BookController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("")]
        public IActionResult AllBooks()
        {
            try
            {
                var response = new BookApplication(_context).GetAllBooks();

                if(response == null)
                {
                    return NotFound("Nenhum Livro encontrado!");
                }

                return Ok(response);
            } 
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpGet]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var response = new BookApplication(_context).GetBookById(id);

                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if(response.Status == 500)
                {
                    return new StatusCodeResult(500);
                }

                return Ok(response.DataBook);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("")]
        public IActionResult InsertBook([FromBody]Book book)
        {
            try
            {
                var response = new BookApplication(_context).InsertBook(book);

                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpPut]
        [EnableCors("MyPolicy")]
        [Route("")]
        public IActionResult UpdateBook([FromBody]Book receivedBook)
        {
            try
            {
                var response = new BookApplication(_context).UpdateBook(receivedBook);

                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if (response.Status == 500)
                {
                    return NotFound(response.Message);
                }

                return Ok(response.Message);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpDelete]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var response = new BookApplication(_context).DeleteBook(id);

                if(response.Status == 400)
                {
                    return BadRequest(response.Message);
                }
                else if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if(response.Status == 500)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.Message);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }
    }
}
