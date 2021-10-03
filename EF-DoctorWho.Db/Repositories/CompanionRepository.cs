using System;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class CompanionRepository : ICompanionRepository
    {
        private DoctorWhoCoreDbContext _context;
        public CompanionRepository(DoctorWhoCoreDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public tblCompanion GetCompinain(int ID)
        {
            var Com = _context.tblCompanion.Find(ID);
            if (!CompinainExist(ID))
            {
                throw new ArgumentNullException(nameof(ID));
            }
            return Com;
        }

        public bool CompinainExist(int Id)
        {

            var Coms = _context.tblCompanion.ToList();
            foreach (var C in Coms)
            {
                if (C.tblCompanionID == Id)
                {
                    return true;

                }
            }
            return false;
        }
    }
}