using Microsoft.AspNetCore.Mvc;

namespace ArabamiSatWeb.Controllers.Base
{
    public class BaseController : Controller
    {
        internal void ContextMessageHandler(int returnValue)
        {
            if (returnValue > 0)
                 ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
        }

        internal async Task<string> UploadImage(IFormFile? file)
        {
            string pathAbsolute = "";
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                pathAbsolute = $"/upload/{imageName}";
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + pathAbsolute);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }

            return pathAbsolute;
        }
    }
}
