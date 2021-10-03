using System;
namespace DoctorWho.web.models
{
    public class EpisodeForPrintingDto
    {

        public int EpisodeID { get; set; }

        public int SeriesNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string EpisodeType { get; set; }

        public string Title { get; set; }

        public DateTime EpisodeDate { get; set; }

        // Fk for tblAutor
        public int AuthorID { get; set; }

        // Fk for tblDoctor
        public int DoctorID { get; set; }

        public string Notes { get; set; }

    }
}
