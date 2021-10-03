using System;
namespace EF_DoctorWho.Db.Repositories
{
    public interface IEpisodeEnemyRepository
    {
        public void AddEnemyToEpisode(int EpsoideID, int enemID);
    }
}
