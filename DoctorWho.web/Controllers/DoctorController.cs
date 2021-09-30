using System;
using System.Collections.Generic;
using AutoMapper;
using DoctorWho.web.models;
using DoctorWho.web.ValidationAttrbuite.DoctorValidater;
using EF_DoctorWho.Db;
using EF_DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.web.Controllers
{
    [ApiController]
    [Route("api/doctores")]
    public class DoctorController : ControllerBase
    {
        public readonly IDoctorRepository _doctorRepository;
        public readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<DoctorForPrintingDto>> GetDoctores()
        {
            var Doctores = _doctorRepository.GetDoctors();
            return Ok(_mapper.Map<IEnumerable<DoctorForPrintingDto>>(Doctores));
        }

        [HttpGet("{doctorId}",Name = "GetDoctor")]
        public IActionResult GetDoctor(int doctorId)
        {
            try
            {
                var Dr = _doctorRepository.GetDoctor(doctorId);
                return Ok(_mapper.Map<DoctorForPrintingDto>(Dr));
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPut("{doctorId}")]
        public ActionResult UpsertDoctor(int doctorId, DoctorForUpdatingDto doctor)
        {
            try
            {
                var Dr = _doctorRepository.GetDoctor(doctorId);
                if (Dr == null)
                {
                    // To Review ... it create the Dr with Incremantel id not Id we provided ...
                    // if the Dr D.N.E .. I will create it
                    var DrToAdd = _mapper.Map<tblDoctor>(doctor);
                    DrToAdd.tblDoctorID = doctorId;
                    _doctorRepository.AddNewDoctor(doctorId, DrToAdd);
                    _doctorRepository.Save();
                    var DrNotExistToReturn = _mapper.Map<DoctorForPrintingDto>(DrToAdd);
                    return CreatedAtRoute("GetDoctor", new { DoctorId = DrNotExistToReturn.DoctorID }, DrNotExistToReturn);
                }


                // Check Validater for the Updating an existing Doctor
                DoctorForUpdatingValidator validater = new DoctorForUpdatingValidator();
                var result = validater.Validate(doctor);
                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        return BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    }
                }

                _mapper.Map(doctor, Dr);
                _doctorRepository.Save();

                var DrToReturn = _mapper.Map<DoctorForPrintingDto>(Dr);
                return CreatedAtRoute("GetDoctor", new { DoctorId = DrToReturn.DoctorID }, DrToReturn);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }


        [HttpDelete("{doctorId}")]
        public ActionResult Deletedoctor(int doctorId)
        {
            try
            {
                _doctorRepository.DeleteExistingDoctor(doctorId);
                _doctorRepository.Save();
                return NoContent();
            }
            catch(ArgumentNullException)
            {
                return NotFound(); // 404 status code
            } 
        }

    }

}