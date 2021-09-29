using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class CompanionRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public static void AddNewCompanion(string Name, string WhoPlay)
        {
            var Com = new tblCompanion { companionName = Name, WhoPlayed = WhoPlay };
            _context.tblCompanion.Add(Com);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public static void UpdateExistingCompanion(int id, string Name, string WhoPlay)
        {
            var Com = _context.tblCompanion.Find(id);
            Com.companionName = Name;
            Com.WhoPlayed = WhoPlay;
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public static void DeleteExistingCompanion(int id)
        {
            var Com = _context.tblCompanion.Find(id);
            _context.tblCompanion.Remove(Com);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }

        public static void SearchCompanionByID(int ID)
        {
            var Com = _context.tblCompanion.Where(C => C.tblCompanionID == ID).ToList();
            System.Console.WriteLine(Com.First().companionName);
        }
    }
}