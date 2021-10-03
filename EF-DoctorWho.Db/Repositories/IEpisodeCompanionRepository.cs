using System;
namespace EF_DoctorWho.Db.Repositories
{
    public interface IEpisodeCompanionRepository 
    {
        public void AddCompianToEpisode(int EpsoideID, int ComID);
    }
}
