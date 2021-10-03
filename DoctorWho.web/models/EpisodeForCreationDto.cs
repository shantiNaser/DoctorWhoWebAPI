using System;
namespace DoctorWho.web.models
{
    public class EpisodeForCreationDto
    {

        public int SeriesNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public string EpisodeType { get; set; }

        public string Title { get; set; }

        public DateTime EpisodeDate { get; set; }

        public string Notes { get; set; }

    }
}
