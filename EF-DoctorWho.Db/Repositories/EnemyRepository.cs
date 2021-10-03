using System;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class EnemyRepository : IEnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EnemyRepository(DoctorWhoCoreDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public tblEnemy GetEnemy(int ID)
        {
            var Enmy = _context.tblEnemy.Find(ID);
            if (!EnemyExist(ID))
            {
                throw new ArgumentNullException(nameof(ID));
            }
            return Enmy;
        }

        public bool EnemyExist(int Id)
        {

            var Enemy = _context.tblEnemy.ToList();
            foreach (var En in Enemy)
            {
                if (En.tblEnemyId == Id)
                {
                    return true;

                }
            }
            return false;
        }
    }
}