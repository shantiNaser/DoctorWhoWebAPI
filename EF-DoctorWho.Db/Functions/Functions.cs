using System;
using System.Linq;

namespace EF_DoctorWho.Db.Functions
{
    public class Functions
    {
        private DoctorWhoCoreDbContext _context;
        public Functions(DoctorWhoCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        private  void CompanionsFunctionResult(int EpsoideId)
        {
            var Name = from C in _context.tblCompanion
                       join EC in _context.tblEpisodeCompanion on C.tblCompanionID equals EC.tblCompanionID
                       select _context.CompanionsFunctionResult(EpsoideId);
            System.Console.WriteLine(Name.Take(1).ToList().First());
        }

        private  void EnemyFunctionResult(int EpsoideId)
        {
            var Name = from E in _context.tblEnemy
                       join EE in _context.tblEpisodeEnemy on E.tblEnemyId equals EE.tblEnemyID
                       select _context.EnemiesFunctionResult(EpsoideId);
            System.Console.WriteLine(Name.Take(1).ToList().First());
        }

    }
}