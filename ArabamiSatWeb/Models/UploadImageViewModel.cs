using ArabamiSatWeb.Models.Base;

namespace ArabamiSatWeb.Models
{
    public class UploadImageViewModel : BaseModel
    {
        
            public string FullName { get; set; }
            public string FileName { get; set; }
            public long Size { get; set; }
       
    }
}
