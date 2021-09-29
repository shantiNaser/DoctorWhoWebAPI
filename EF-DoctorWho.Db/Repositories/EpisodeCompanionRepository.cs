namespace EF_DoctorWho.Db.Repositories
{
    public class EpisodeCompanionRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

        public static void AddCompanionToEpisode(int EpsoideID, string COMName, string WhoPlay)
        {
            // Prepare a new Companion ...
            var Com = new tblCompanion { companionName = COMName, WhoPlayed = WhoPlay };
            _context.tblCompanion.Add(Com);
            _context.SaveChanges();
            // Search for the Epsoide that we need to add Companin to 
            var EPS = _context.tblEpisode.Find(EpsoideID);
            // Add
            EPS.EpisodeCompanion.Add
            (new tblEpisodeCompanion { tblEpisodeID = EpsoideID, tblCompanionID = Com.tblCompanionID });
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");

        }
    }
}