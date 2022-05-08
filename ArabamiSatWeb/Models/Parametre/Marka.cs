using System.ComponentModel.DataAnnotations.Schema;
using ArabamiSatWeb.Models.Base;

namespace ArabamiSatWeb.Models.Parametre
{
    public class Marka : BaseModel
    {
        [Column(TypeName = "Nvarchar(50)")]
        public string Ad { get; set; }
    }
}
