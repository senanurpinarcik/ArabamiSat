using ArabamiSatWeb.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models
{
    public class Araba : BaseModel
    {
        
        public enum DurumEnum
        {
            Sifir = 0,
            IkinciEl = 2
        }

        [ForeignKey("Marka")]
        public int MarkaId { get; set; }

        [ForeignKey("MarkaModel")]
        public int MarkaModelId { get; set; }
        public int Yil { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fiyat { get; set; }
        public int DurumId { get; set; }

        [Column(TypeName = "Nvarchar(500)")]
        public string Aciklama { get; set; }

        [Column(TypeName = "Nvarchar(MAX)")]
        public string Fotograf { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual MarkaModel MarkaModel { get; set; }

    }
}
