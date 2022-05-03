using ArabamiSatWeb.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models
{
    public class Marka : BaseModel
    {
        [Column(TypeName = "Nvarchar(50)")]
        public string Ad { get; set; }
    }
}
