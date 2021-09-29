using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DoctorWho.Db
{
    public class tblAuthor
    {
        public tblAuthor()
        {
            Episode = new List<tblEpisode>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tblAutorID { get; set; }


        [MaxLength(20)]
        public string AuthorName { get; set; }

        public List<tblEpisode> Episode { get; set; }


    }
}