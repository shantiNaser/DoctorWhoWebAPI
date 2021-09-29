using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DoctorWho.Db
{
    public class tblEpisodeEnemy
    {
        public tblEpisodeEnemy()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tblEpisodeEnemyID { get; set; }

        // FK For tblEpisode
        public int tblEpisodeID { get; set; }
        public tblEpisode Episode;


        // FK For tblEnemy
        public int tblEnemyID { get; set; }
        public tblEnemy Enemy;
    }
}