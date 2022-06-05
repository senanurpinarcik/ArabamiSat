using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Parametre;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models.Araba
{
    public class Araba : BaseModel
    {
        public enum DurumEnum
        {
            [Description("Sıfır")]
            Sifir = 0,
            [Description("İkinci El")]
            IkinciEl = 2
        }

        [DisplayName("Marka")]
        [ForeignKey("Marka")]
        public int MarkaId { get; set; }

        [DisplayName("Model")]
        [ForeignKey("MarkaModel")]
        public int MarkaModelId { get; set; }

        [DisplayName("Yıl")]
        public int Yil { get; set; }

        [DisplayName("Fiyat")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fiyat { get; set; }

        [DisplayName("Durum")]
        public int DurumId { get; set; }

        [DisplayName("Açıklama")]
        [Column(TypeName = "Nvarchar(500)")]
        public string Aciklama { get; set; }

        [DisplayName("Fotoğraf")]
        [Column(TypeName = "Nvarchar(MAX)")]
        public string Fotograf { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual MarkaModel MarkaModel { get; set; }

    }
}
