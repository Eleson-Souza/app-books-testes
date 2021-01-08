using APILivrosTeste.Application;
using APILivrosTeste.Context;
using APILivrosTeste.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APILivrosTeste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private ApiContext _context;

        public AuthorsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var response = new AuthorsApplication(_context).GetAllAuthors();

                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if(response.Status == 500)
                {
                    return new StatusCodeResult(500);
                }

                return Ok(response.DataAuthors);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAuthor(int id)
        {
            try
            {
                var response = new AuthorsApplication(_context).GetAuthor(id);

                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if(response.Status == 500)
                {
                    return new StatusCodeResult(500);
                }

                return Ok(response.DataAuthor);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult InsertAuthor([FromBody]Author author)
        {
            try
            {
                var response = new AuthorsApplication(_context).InsertAuthor(author);

                if(response.Status == 500)
                {
                    return new StatusCodeResult(500);
                }

                return Ok(response.DataAuthors);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpPut]
        [Route("")]
        public IActionResult UpdateAuthor([FromBody]Author author)
        {
            try
            {
                var response = new AuthorsApplication(_context).UpdateAuthor(author);

                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if (response.Status == 500)
                {
                    return new StatusCodeResult(500);
                }

                return Ok(response.Message);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao se comunicar com o banco de dados!");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                var response = new AuthorsApplication(_context).DeleteAuthor(id);
                
                if(response.Status == 404)
                {
                    return NotFound(response.Message);
                }
                else if(response.Status == 500)
                {
                    return new StatusCodeResult(500);
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
