using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class EpsoideRepository : IEpsoideRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public IEnumerable<tblEpisode> GetEpsoides()
        {
            return _context.tblEpisode.ToList();
        }

        public tblEpisode GetEpsoide(int EpsoideId)
        {
            var Eps = _context.tblEpisode.Find(EpsoideId);
            if (!EpsoideExist(EpsoideId))
            {
                throw new ArgumentNullException(nameof(EpsoideId));
            }
            return Eps;
        }

        public bool EpsoideExist(int EpsoideId)
        {

            var Epsoides = _context.tblEpisode.ToList();
            foreach (var Ep in Epsoides)
            {
                if (Ep.tblEpisodeID == EpsoideId)
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


        public void AddNewEpsoide(int AuthorID, int DoctorID, tblEpisode Epsoide)
        {
            if (Epsoide == null)
            {
                throw new ArgumentNullException(nameof(Epsoide));
            }

            Epsoide.tblAuthorID = AuthorID;
            Epsoide.tblDoctorID = DoctorID;
            _context.tblEpisode.Add(Epsoide);
        }



        // Not REady ...



        public void UpdateEpsoide(int EpsoideID, int SNumber, int ENumber, string EType, string Title, DateTime EDate, int AuotherID, int DrID, string Note)
        {
            var Eps = _context.tblEpisode.Find(EpsoideID);
            Eps.SeriesNumber = SNumber;
            Eps.EpisodeNumber = ENumber;
            Eps.EpisodeType = EType;
            Eps.Title = Title;
            Eps.EpisodeDate = EDate;
            Eps.tblAuthorID = AuotherID;
            Eps.tblDoctorID = DrID;
            Eps.Notes = Note;
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public void DeleteEPisode(int id)
        {
            var EPs = _context.tblEpisode.Find(id);
            _context.tblEpisode.Remove(EPs);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
    }
}