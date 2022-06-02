using System.ComponentModel.DataAnnotations;

namespace ArabamiSatWeb.Models.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public bool SilindiMi { get; set; }

        public int? EkleyenKullaniciId { get; set; }
        public int? GuncelleyenKullaniciId { get; set; }
        public int? SilenKullaniciId { get; set; }
        public DateTime? EklenmeTarihi { get; set; }
        public DateTime? GuncellenmeTarihi { get; set; }
        public DateTime? SilinmeTarihi { get; set; }
    }
}
