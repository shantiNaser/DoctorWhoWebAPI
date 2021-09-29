using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DoctorWho.Db
{
    public class tblEnemy
    {
        public tblEnemy()
        {
            EpisodeEnemy = new List<tblEpisodeEnemy>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tblEnemyId { get; set; }

        [MaxLength(20)]
        public string EnemyName { get; set; }
        public string Description { get; set; }

        public List<tblEpisodeEnemy> EpisodeEnemy { get; set; }
    }
}