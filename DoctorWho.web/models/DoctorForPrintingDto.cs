using System;
namespace DoctorWho.web.models
{
    public class DoctorForPrintingDto
    {
        
        public int DoctorID { get; set; }
        public int DoctorNumber { get; set; }

        public string DoctorName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime FirstEpisodeDate { get; set; }

        public DateTime LastEpisodeDate { get; set; }

    }
}
