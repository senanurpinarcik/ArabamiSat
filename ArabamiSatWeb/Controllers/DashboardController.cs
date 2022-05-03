using Microsoft.AspNetCore.Mvc;
using ArabamiSatWeb.Models;
using ArabamiSatWeb.Models.Base;

namespace ArabamiSatWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BaseDbContext _context;  

        public async Task<string> UploadImage(IFormFile file)
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
            IFormFile fotograf = collection.Files.First(i => i.Name == "Fotograf");
            string fotografPath = UploadImage(fotograf).Result;


            Araba araba = new Araba
            { 
                Aciklama = aciklama,
                Fotograf = fotografPath,
                Fiyat = 200000,
                Yil = 2010,
                DurumId = 0,
                MarkaId = 0,
                MarkaModelId = 1,
                SilindiMi = false
                
            };

            _context.Araba.Add(araba);
            _context.SaveChanges();
            return View(araba);
        }
    }
}