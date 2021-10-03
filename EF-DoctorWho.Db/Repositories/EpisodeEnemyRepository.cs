namespace EF_DoctorWho.Db.Repositories
{
    public class EpisodeEnemyRepository : IEpisodeEnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public void AddEnemyToEpisode(int EpsoideID, int enemID)
        {

            var EpsoideEnemy = new tblEpisodeEnemy
            {
                tblEpisodeID = EpsoideID,
                tblEnemyID = enemID
            };

            _context.tblEpisodeEnemy.Add(EpsoideEnemy);
            _context.SaveChanges();

        }

       
    }
}