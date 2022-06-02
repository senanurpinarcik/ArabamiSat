using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models.Admin
{
    public class Admin
    {
        [Key] 
        public int AdminId { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string Kullanici { get; set; }

        [Column(TypeName = "Varchar(10)")]
        public int Parola { get; set; }
    }
}
