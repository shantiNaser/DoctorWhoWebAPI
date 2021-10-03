using System;
using System.Collections.Generic;

namespace EF_DoctorWho.Db.Repositories
{
    public interface IEpsoideRepository
    {
        public IEnumerable<tblEpisode> GetEpsoides();
        public tblEpisode GetEpsoide(int EpsoideId);
        public bool EpsoideExist(int EpsoideId);
        public void AddNewEpsoide(int AuthorID, int DoctorID, tblEpisode Epsoide);
        public bool Save();
    }
}
