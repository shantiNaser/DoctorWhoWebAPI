using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class AuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        //public AuthorRepository(DoctorWhoCoreDbContext context)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //}

        public void AddNewAuthor(string name)
        {
            var Author = new tblAuthor { AuthorName = name };
            _context.tblAuthor.Add(Author);
        }
        public void UpdateExistingAuthor(int AuthorID, string newName)
        {
            var Author = _context.tblAuthor.Find(AuthorID);
            Author.AuthorName = newName;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int AuthorID)
        {
            var Author = _context.tblAuthor.Find(AuthorID);
            _context.tblAuthor.Remove(Author);
        
        }

        public IEnumerable<tblAuthor> GetAuthors()
        {
            return _context.tblAuthor.ToList();

        }
    }
}
