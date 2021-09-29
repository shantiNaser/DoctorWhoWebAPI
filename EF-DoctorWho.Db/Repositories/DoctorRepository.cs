using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF_DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public  void AddNewDoctor(string Drname, int DrNumber, DateTime BD, DateTime FEPS, DateTime LEPS)
        {
            var Dr = new tblDoctor
            {
                DoctorName = Drname,
                DoctorNumber = DrNumber,
                BirthDate = BD,
                FirstEpisodeDate = FEPS,
                LastEpisodeDate = LEPS

            };
            _context.tblDoctor.Add(Dr);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public  void UpdateExistingDoctor(int DrID, string Drname, int DrNumber, DateTime BD, DateTime FEPS, DateTime LEPS)
        {
            var Dr = _context.tblDoctor.Find(DrID);
            Dr.DoctorName = Drname;
            Dr.DoctorNumber = DrNumber;
            Dr.BirthDate = BD;
            Dr.FirstEpisodeDate = FEPS;
            Dr.LastEpisodeDate = LEPS;
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public  void DeleteExistingDoctor(int DrID)
        {
            var Dr = _context.tblDoctor.Find(DrID);
            _context.tblDoctor.Remove(Dr);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }

        public IEnumerable<tblDoctor> GetAllAvailableDoctor()
        {
            return _context.tblDoctor.FromSqlInterpolated($"select * from tblDoctor").ToList();
        }

    }
}