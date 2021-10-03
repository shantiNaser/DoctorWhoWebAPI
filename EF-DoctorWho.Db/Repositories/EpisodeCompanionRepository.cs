namespace EF_DoctorWho.Db.Repositories
{
    public class EpisodeCompanionRepository : IEpisodeCompanionRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public void AddCompianToEpisode(int EpsoideID, int ComID)
        {

            var ComEpsoide = new tblEpisodeCompanion
            {
                tblEpisodeID = EpsoideID,
                tblCompanionID = ComID
            };

            _context.tblEpisodeCompanion.Add(ComEpsoide);
            _context.SaveChanges();

        }
    }
}