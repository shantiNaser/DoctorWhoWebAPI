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
        public readonly IEnemyRepository _EnemyRepository;
        public readonly IEpisodeEnemyRepository _EpisodeEnemyRepository;
        public readonly ICompanionRepository _CompanionRepository;
        public readonly IEpisodeCompanionRepository _EpisodeCompanionRepository;
        public readonly IMapper _mapper;

        public EpsoideController(IEpsoideRepository epsoideRepository, IAuthorRepository authorRepository
            , IDoctorRepository doctorRepository, IEnemyRepository enemyRepository
            , IEpisodeEnemyRepository episodeEnemyRepository
            , ICompanionRepository companionRepository
            , IEpisodeCompanionRepository episodeCompanionRepository ,IMapper mapper)
        {
            _EpsoideRepository = epsoideRepository ?? throw new ArgumentNullException(nameof(epsoideRepository));
            _AuthorRepository = authorRepository ?? throw new ArgumentNullException(nameof(authorRepository));
            _DoctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
            _EnemyRepository = enemyRepository ?? throw new ArgumentNullException(nameof(enemyRepository));
            _EpisodeEnemyRepository = episodeEnemyRepository ?? throw new ArgumentNullException(nameof(episodeEnemyRepository));
            _CompanionRepository = companionRepository ?? throw new ArgumentNullException(nameof(companionRepository));
            _EpisodeCompanionRepository = episodeCompanionRepository ?? throw new ArgumentNullException(nameof(episodeCompanionRepository));
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

        [HttpPost("CreateEpsoide/{authorId}/{doctorId}")]
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


        [HttpPost("AddEnemyToEpisode/{episodeId}/{enemieId}")]
        public IActionResult AddEnemyToEpisode(int episodeId, int enemieId)
        {
            try
            {
                var Epsoide = _EpsoideRepository.GetEpsoide(episodeId);
                var Enemy = _EnemyRepository.GetEnemy(enemieId);
                _EpisodeEnemyRepository.AddEnemyToEpisode(episodeId, enemieId);
                return Ok();
            }
            catch(ArgumentNullException)
            {
                return NotFound();
            }

        }

        [HttpPost("AddCompinainToEpisode/{episodeId}/{CompinainId}")]
        public IActionResult AddCompinainToEpisode(int episodeId, int CompinainId)
        {
            try
            {
                var Epsoide = _EpsoideRepository.GetEpsoide(episodeId);
                var Com = _CompanionRepository.GetCompinain(CompinainId);
                _EpisodeCompanionRepository.AddCompianToEpisode(episodeId, CompinainId);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }



    }
}
