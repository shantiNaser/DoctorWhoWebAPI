using System.Linq;

namespace EF_DoctorWho.Db.Repositories
{
    public class EnemyRepository
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public static void AddNewEnemys(string Name, string Desc)
        {
            var Enm = new tblEnemy { EnemyName = Name, Description = Desc };
            _context.tblEnemy.Add(Enm);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public static void updateExistingEnemys(int Id, string Name, string Desc)
        {
            var Enm = _context.tblEnemy.Find(Id);
            Enm.EnemyName = Name;
            Enm.Description = Desc;
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public static void DeleteExistingEnemys(int ID)
        {
            var Enm = _context.tblEnemy.Find(ID);
            _context.tblEnemy.Remove(Enm);
            _context.SaveChanges();
            System.Console.WriteLine("Process was Done Successfully");
        }
        public static void SearchEnemyByID(int ID)
        {
            var Enmy = _context.tblEnemy.Where(s => s.tblEnemyId == ID).ToList();
            System.Console.WriteLine(Enmy.First().EnemyName);
        }
    }
}