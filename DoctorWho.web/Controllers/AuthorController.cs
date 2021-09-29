using System;
using EF_DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorReposotry;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorReposotry = authorRepository ?? throw new ArgumentException(nameof(authorRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthores()
        {
            var AuthoresFromRepo = _authorReposotry.GetAuthors();
            return Ok(AuthoresFromRepo);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(int authorId)
        {
            try
            {
                var AuthorFromRepo = _authorReposotry.GetAuthor(authorId);
                return Ok(AuthorFromRepo);
            }
            catch(ArgumentNullException)
            {
                // if the Author that Consumer search D.N.E
                // The response body was return contain status code => 404 and Msg tell where the Problem 
                return NotFound("The Author you Try To search Does Not Exist");
            }
            
            
        }

    }
}
