using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DoctorWho.Db
{
    public class tblDoctor
    {
        public tblDoctor()
        {
            Episode = new List<tblEpisode>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tblDoctorID { get; set; }
        public int DoctorNumber { get; set; }
        [MaxLength(20)]
        public string DoctorName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime FirstEpisodeDate { get; set; }

        public DateTime LastEpisodeDate { get; set; }

        public List<tblEpisode> Episode { get; set; }
    }
}