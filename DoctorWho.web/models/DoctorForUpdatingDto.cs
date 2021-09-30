using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorWho.web.models
{
    public class DoctorForUpdatingDto
    {
        public int? DoctorNumber { get; set; }

        public string DoctorName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? FirstEpisodeDate { get; set; }

        public DateTime? LastEpisodeDate { get; set; }
    }
}
