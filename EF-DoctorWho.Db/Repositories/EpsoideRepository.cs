using System;

namespace EF_DoctorWho.Db.Repositories
{
    public class EpsoideRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public static void AddNewEpsoide(int SNumber, int ENumber, string EType, string Title, DateTime EDate, int AuotherID, int DrID, string Note)
        {
            var Eps = new tblEpisode
            {
                SeriesNumber = SNumber,
                EpisodeNumber = ENumber,
                EpisodeType = EType,
                Title = Title,
                EpisodeDate = EDate,
                tblAuthorID = AuotherID,
                tblDoctorID = DrID,
                Notes = Note
            };
            _context.tblEpisode.Add(Eps);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");

        }
        public static void UpdateEpsoide(int EpsoideID, int SNumber, int ENumber, string EType, string Title, DateTime EDate, int AuotherID, int DrID, string Note)
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
        public static void DeleteEPisode(int id)
        {
            var EPs = _context.tblEpisode.Find(id);
            _context.tblEpisode.Remove(EPs);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
    }
}