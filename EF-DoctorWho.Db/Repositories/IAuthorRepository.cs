using System;
using System.Collections.Generic;

namespace EF_DoctorWho.Db.Repositories
{
    public interface IAuthorRepository
    {
        public void AddNewAuthor(string name);
        public void UpdateExistingAuthor(int AuthorID, string newName);
        public void DeleteAuthor(int AuthorID);
        public IEnumerable<tblAuthor> GetAuthors();
        public tblAuthor GetAuthor(int authorId);
        public bool AuthorExist(int authorId);
        bool Save();
    }
}
