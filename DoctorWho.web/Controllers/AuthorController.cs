using System;
using System.Collections.Generic;
using AutoMapper;
using DoctorWho.web.models;
using DoctorWho.web.ValidationAttrbuite;
using EF_DoctorWho.Db;
using EF_DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorReposotry;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorReposotry = authorRepository ?? throw new ArgumentException(nameof(authorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorForPrintingDto>> GetAuthores()
        {
            var AuthoresFromRepo = _authorReposotry.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorForPrintingDto>>(AuthoresFromRepo));
        }


        [HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult GetAuthor(int AuthorId)
        {
            try
            {
                var AuthorFromRepo = _authorReposotry.GetAuthor(AuthorId);
                return Ok(_mapper.Map<AuthorForPrintingDto>(AuthorFromRepo));

            }
            catch(ArgumentNullException)
            {
                // if the Author that Consumer search D.N.E
                // The response body was return contain status code => 404 and Msg tell where the Problem 
                return NotFound("The Author you Try To search Does Not Exist");
            }
  
        }

        [HttpPost()]
        public IActionResult CreateAuthor(AuthorForManipulatinonDto author)
        {
            try
            {
                var NewAuthor = _mapper.Map<tblAuthor>(author);
                AuthorValidator validater = new AuthorValidator();
                var result = validater.Validate(NewAuthor);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        return BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }

                _authorReposotry.AddNewAuthor(NewAuthor);
                _authorReposotry.Save();

                var authorToReturn = _mapper.Map<AuthorForPrintingDto>(NewAuthor);

                // To Review => Here when the data was Return AuthorId is take the default value (0)
                return CreatedAtRoute("GetAuthor", new { AuthorId = authorToReturn.AuthorID },authorToReturn);
            }
            catch(ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPut("{authorId}")]
        public IActionResult UpdateAuthor(int authorId, AuthorForManipulatinonDto author)
        {
            try
            {
                var authorToUpdate = _authorReposotry.GetAuthor(authorId);
                // The next Line will
                // 1. Map from EF-DoctorWho.Db To AuthorForManipulatinonDto
                // 2. apply the changes ...
                // 3. Map back from EF-DoctorWho.Db to AuthorForManipulatinonDto
                _mapper.Map(author, authorToUpdate);
                _authorReposotry.Save();
                return NoContent();


            }
            catch(ArgumentNullException)
            {
                return NotFound();
            }

        }

    }
}
