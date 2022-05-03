using System.ComponentModel.DataAnnotations;

namespace ArabamiSatWeb.Models.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public bool SilindiMi { get; set; }
    }
}
