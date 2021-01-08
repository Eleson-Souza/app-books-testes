using APILivrosTeste.Application;
using APILivrosTeste.Context;
using APILivrosTeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APILivrosTeste.Controllers
{
    [Route("books-authors")]
    [ApiController]
    public class BooksAuthorsController : ControllerBase
    {
        private ApiContext _context;
        private BookAuthorApplication bookAuthorApplication;

        public BooksAuthorsController(ApiContext context)
        {
            _context = context;
            bookAuthorApplication = new BookAuthorApplication(context);
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllBookAuthor()
        {
            try
            {
                var response = bookAuthorApplication.GetAllBookAuthor();

                if (response.Status == 500)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.DataBooksAuthors);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDetailBookAuthor(int id)
        {
            try
            {
                var response = bookAuthorApplication.GetOneBookAuthor(id);

                if (response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if (response.Status == 500)
                {
                    return BadRequest(response.Message);
                }

                return Ok(response.DataBookAuthor);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult InsertBookAuthor([FromBody] BookAuthor bookAuthor)
        {
            try
            {
                var response = bookAuthorApplication.InsertBookAuthor(bookAuthor);

                if (response.Status == 500)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
                }

                return StatusCode(201, response.DataBooksAuthors);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateBookAuthor(int id, [FromBody] BookAuthor bookAuthor)
        {
            try
            {
                var response = bookAuthorApplication.UpdateBookAuthor(bookAuthor, id);

                if (response.Status == 400)
                {
                    return BadRequest(response.Message);
                }
                else if (response.Status == 500)
                {
                    return StatusCode(500, response.Message);
                }

                return Ok(response.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult UpdateBookAuthor(int id)
        {
            try
            {
                var response = bookAuthorApplication.DeleteBookAuthor(id);

                if(response.Status == 400)
                {
                    return BadRequest(response.Message);
                } 
                else if(response.Status == 500)
                {
                    return StatusCode(500, response.Message);
                }

                return Ok(response.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
