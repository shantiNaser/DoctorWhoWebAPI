using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF_DoctorWho.Db.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public IEnumerable<tblDoctor> GetDoctors()
        {
            return _context.tblDoctor.FromSqlInterpolated($"select * from tblDoctor").ToList();
        }

        public tblDoctor GetDoctor(int doctorId)
        {
            var Dr = _context.tblDoctor.Find(doctorId);
            if (!DoctorExist(doctorId))
            {
                throw new ArgumentNullException(nameof(doctorId));
            }
            return Dr;
        }

        public bool DoctorExist(int doctorId)
        {

            var Drs = _context.tblDoctor.ToList();
            foreach (var Dr in Drs)
            {
                if (Dr.tblDoctorID == doctorId)
                {
                    return true;

                }
            }
            return false;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void AddNewDoctor(int doctorId, tblDoctor doctor)
        {
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor));
            }

            var Dr = new tblDoctor
            {
                DoctorName = doctor.DoctorName,
                DoctorNumber = doctor.DoctorNumber,
                BirthDate = doctor.BirthDate,
                FirstEpisodeDate = doctor.FirstEpisodeDate,
                LastEpisodeDate = doctor.LastEpisodeDate

            };
            _context.tblDoctor.Add(Dr);
        }


        public void DeleteExistingDoctor(int DrID)
        {
            
            var Dr = _context.tblDoctor.Find(DrID);
            if(!DoctorExist(DrID))
            {
                throw new ArgumentNullException(nameof(DrID));
            }
            _context.tblDoctor.Remove(Dr);
        }


       

    }
}