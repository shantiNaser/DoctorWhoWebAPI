using System;
using System.Collections.Generic;

namespace EF_DoctorWho.Db.Repositories
{
    public interface IAuthorRepository
    {
        public void AddNewAuthor(tblAuthor author);
        public void DeleteAuthor(int AuthorID);
        public IEnumerable<tblAuthor> GetAuthors();
        public tblAuthor GetAuthor(int authorId);
        public bool AuthorExist(int authorId);
        bool Save();
    }
}
