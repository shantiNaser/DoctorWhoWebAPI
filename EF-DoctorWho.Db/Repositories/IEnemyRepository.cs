using System;
namespace EF_DoctorWho.Db.Repositories
{
    public interface IEnemyRepository
    {
        public tblEnemy GetEnemy(int ID);
        public bool EnemyExist(int Id);
    }
}
