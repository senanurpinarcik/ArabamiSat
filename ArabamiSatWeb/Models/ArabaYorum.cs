using ArabamiSatWeb.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models
{
    public class ArabaYorum : BaseModel
    {
        [ForeignKey("Araba")]
        public int ArabaId { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }

        [Column(TypeName = "Nvarchar(500)")]
        public string Yorum { get; set; }
         public virtual Araba Araba { get; set; }
         public virtual Kullanici Kullanici { get; set; }
    }
}
