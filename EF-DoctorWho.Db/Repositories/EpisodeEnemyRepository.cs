namespace EF_DoctorWho.Db.Repositories
{
    public class EpisodeEnemyRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public static void AddEnemyToEpisode(int EpsoideID, string name, string Des)
        {
            // Prepare a new Enemy ...
            var Enmy = new tblEnemy { EnemyName = name, Description = Des };
            _context.tblEnemy.Add(Enmy);
            _context.SaveChanges();
            // Search for the Epsoide that we need to add Enemy to 
            var EPS = _context.tblEpisode.Find(EpsoideID);
            // Add
            EPS.EpisodeEnemy.Add
            (new tblEpisodeEnemy { tblEpisodeID = EpsoideID, tblEnemyID = Enmy.tblEnemyId });
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");

        }
    }
}