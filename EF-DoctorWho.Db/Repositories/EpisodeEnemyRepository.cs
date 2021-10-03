using System;

namespace EF_DoctorWho.Db.Repositories
{
    public class EpisodeEnemyRepository : IEpisodeEnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EpisodeEnemyRepository(DoctorWhoCoreDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
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