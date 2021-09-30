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
    [Route("api/Epsoides")]
    public class EpsoideController : ControllerBase
    {
        public readonly IEpsoideRepository _EpsoideRepository;
        public readonly IAuthorRepository _AuthorRepository;
        public readonly IDoctorRepository _DoctorRepository;
        public readonly IMapper _mapper;

        public EpsoideController(IEpsoideRepository epsoideRepository, IAuthorRepository authorRepository, IDoctorRepository doctorRepository, IMapper mapper)
        {
            _EpsoideRepository = epsoideRepository ?? throw new ArgumentNullException(nameof(epsoideRepository));
            _AuthorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _DoctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<EpisodeForPrintingDto>> GetEpsoides()
        {
            var Epsoides = _EpsoideRepository.GetEpsoides();
            return Ok(_mapper.Map<IEnumerable<EpisodeForPrintingDto>>(Epsoides));
        }


        [HttpGet("{EpsoideId}", Name = "GetEpsoide")]
        public IActionResult GetEpsoide(int EpsoideId)
        {
            try
            {
                var Eps = _EpsoideRepository.GetEpsoide(EpsoideId);
                return Ok(_mapper.Map<EpisodeForPrintingDto>(Eps));
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("{authorId}/{doctorId}")]
        public IActionResult CreateEpsoide(int authorId, int doctorId, EpisodeForCreationDto Epsoide)
        {
            try
            {
                var Author = _AuthorRepository.GetAuthor(authorId); // -- throw an Exception if Author D.N.E
                var Doctor = _DoctorRepository.GetDoctor(doctorId); // -- throw an Exception if Doctor D.N.E
                var NewEpsoide = _mapper.Map<tblEpisode>(Epsoide);
                EpsoideValidator validater = new EpsoideValidator();
                var result = validater.Validate(Epsoide);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        return BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }

                _EpsoideRepository.AddNewEpsoide(authorId, doctorId, NewEpsoide);
                _EpsoideRepository.Save();

                var EpsoideToReturn = _mapper.Map<EpisodeForPrintingDto>(NewEpsoide);
                return CreatedAtRoute("GetEpsoide", new { EpsoideId = EpsoideToReturn.EpisodeID }, EpsoideToReturn);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }



    }
}
