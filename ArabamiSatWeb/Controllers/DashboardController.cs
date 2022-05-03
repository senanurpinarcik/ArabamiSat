using Microsoft.AspNetCore.Mvc;
using ArabamiSatWeb.Models;
using ArabamiSatWeb.Models.Base;

namespace ArabamiSatWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BaseDbContext _context; 

        [HttpPost]
        public async Task<string> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/upload/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);

            }

            return RedirectToAction("UploadImage");
        }
        public DashboardController(BaseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Araba.ToList());
        }
       
        public IActionResult ArabaEkle()
        {
            List<Marka> markaList = _context.Marka.ToList();
            ViewBag.MarkaList = markaList;

            return View();
        }

        [HttpPost]
        public IActionResult ArabaEkle(IFormCollection collection)
        {
            List<Marka> markaList = _context.Marka.ToList();
            ViewBag.MarkaList = markaList;

            string aciklama = collection["Aciklama"];
            IFormFile foto = collection.Files["Fotograf"];

            IFormFile file = foto as IFormFile;
            IFormFile file2 = (IFormFile) foto;


            Araba araba = new Araba
            {

                Aciklama = aciklama,
                Fotograf = aciklama, //dü<elt
                Fiyat = 200000,
                Yil = 2010,
                DurumId = 0,
                Marka = 0,
                Model = 1,
                SilindiMi = false
                
            };

            _context.Araba.Add(araba);
            _context.SaveChanges();
            return View(araba);
        }
    }
}