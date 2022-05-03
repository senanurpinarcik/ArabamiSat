using ArabamiSatWeb.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArabamiSatWeb.Models
{
    public class MarkaModel : BaseModel
    {
        [ForeignKey("Marka")]
        public int MarkaId { get; set; }

        public virtual Marka Marka { get; set; }

        [Column(TypeName = "Nvarchar(50)")]
        public string Ad { get; set; }
    }
}
