using System;
using System.Linq;

namespace EF_DoctorWho.Db
{
    public class EpisodesView
    {
        private static DoctorWhoCoreDbContext _context = new DoctorWhoCoreDbContext();
        public string AuthorName { get; set; }
        public string DoctorName { get; set; }
        public string viewEpisodes { get; set; }
        public string Enemies { get; set; }

        public static void PrintEpsiodeViewData()
        {
            var Data = _context.viewEpisodes.ToList();
            foreach (var item in Data)
            {
                Console.WriteLine(item.AuthorName + " " + item.DoctorName + " " + item.viewEpisodes + " " + item.Enemies);
            }
        }





    }
}