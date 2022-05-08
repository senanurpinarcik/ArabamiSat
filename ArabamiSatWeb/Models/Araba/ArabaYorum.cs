using System.ComponentModel.DataAnnotations.Schema;
using ArabamiSatWeb.Models.Base;

namespace ArabamiSatWeb.Models.Araba
{
    public class ArabaYorum : BaseModel
    {
        [ForeignKey("Araba")]
        public int ArabaId { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }

        [Column(TypeName = "Nvarchar(500)")]
        public string Yorum { get; set; }
         public virtual Models.Araba.Araba Araba { get; set; }
         public virtual Kullanici.Kullanici Kullanici { get; set; }
    }
}
