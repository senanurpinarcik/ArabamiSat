using ArabamiSatWeb.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models.Kullanici
{
    public class Kullanici : BaseModel
    {
        [DisplayName("Ad")]
        [Column(TypeName = "Nvarchar(50)")]
        [Required]
        public string Ad { get; set; }

        [DisplayName("Soyad")]
        [Column(TypeName = "Nvarchar(50)")]
        [Required]
        public string Soyad { get; set; }

        [DisplayName("E-Posta")]
        [Column(TypeName = "Nvarchar(50)")]
        [Required]
        public string Eposta { get; set; }

        [DisplayName("Şifre")]
        [Column(TypeName = "Nvarchar(50)")]
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }

        public bool DogrulandiMi { get; set; }

        public bool YoneticiMi { get; set; }

        [DisplayName("İki Faktörlü Doğrulama")]
        public bool IkiFaktorluDogrulama { get; set; }
        
        [DisplayName("Doğrulama Kodu")]
        [NotMapped]
        public string? DogrulamaKodu { get; set; }
    }
}
