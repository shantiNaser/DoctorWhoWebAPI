using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class EpsoideRepository : IEpsoideRepository
    {
        private readonly DoctorWhoCoreDbContext _context;
        public EpsoideRepository(DoctorWhoCoreDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<tblEpisode> GetEpsoides()
        {
            return _context.tblEpisode.ToList();
        }

        public tblEpisode GetEpsoide(int EpsoideId)
        {
            var Eps = _context.tblEpisode.Find(EpsoideId);
            if (!EpsoideExist(EpsoideId))
            {
                throw new ArgumentNullException(nameof(EpsoideId));
            }
            return Eps;
        }

        public bool EpsoideExist(int EpsoideId)
        {

            var Epsoides = _context.tblEpisode.ToList();
            foreach (var Ep in Epsoides)
            {
                if (Ep.tblEpisodeID == EpsoideId)
                {
                    return true;

                }
            }
            return false;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        public void AddNewEpsoide(int AuthorID, int DoctorID, tblEpisode Epsoide)
        {
            if (Epsoide == null)
            {
                throw new ArgumentNullException(nameof(Epsoide));
            }

            Epsoide.tblAuthorID = AuthorID;
            Epsoide.tblDoctorID = DoctorID;
            _context.tblEpisode.Add(Epsoide);
        }
    }
}