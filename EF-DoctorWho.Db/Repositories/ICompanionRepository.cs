using System;
namespace EF_DoctorWho.Db.Repositories
{
    public interface ICompanionRepository
    {
        public tblCompanion GetCompinain(int ID);
        public bool CompinainExist(int Id);
    }
}
