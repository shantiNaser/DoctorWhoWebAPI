using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EF_DoctorWho.Db
{
    public class tblEpisodeCompanion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tblEpisodeCompanionID { get; set; }

        // FK For tblcompanion
        public tblCompanion Companion;
        public int tblCompanionID { get; set; }
        public tblEpisode Episode;

        // FK For tblEpsiode
        public int tblEpisodeID { get; set; }


    }
}