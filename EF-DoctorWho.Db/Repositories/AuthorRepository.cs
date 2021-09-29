using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();

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

        public tblAuthor GetAuthor(int authorId)
        {
            if (!AuthorExist(authorId))
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            return _context.tblAuthor.Find(authorId);
        }


        public bool AuthorExist(int authorId)
        {
            var Authors = _context.tblAuthor.ToList();
            foreach (var author in Authors)
            {
                if(author.tblAutorID == authorId)
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

    }
}
