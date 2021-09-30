using System;
using System.Collections.Generic;

namespace EF_DoctorWho.Db.Repositories
{
    public interface IDoctorRepository
    {
        public IEnumerable<tblDoctor> GetDoctors();
        public tblDoctor GetDoctor(int doctorId);
        public bool DoctorExist(int doctorId);
        public void AddNewDoctor(int doctorId, tblDoctor doctor);
        public void DeleteExistingDoctor(int DrID);
        public bool Save();
    }
}
