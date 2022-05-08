using Microsoft.AspNetCore.Mvc;
using ArabamiSatWeb.Models;
using ArabamiSatWeb.Models.Base;
using System.Dynamic;
using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Parametre;
using Newtonsoft.Json;

namespace ArabamiSatWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BaseDbContext _context; 
         
        public string GetMarkaModelList(IFormCollection collection)
        {
            int markaId = Convert.ToInt32(collection["markaId"]);
            List<MarkaModel> markaModelList = _context.MarkaModel.Where(i => i.MarkaId == markaId).ToList();
            List<dynamic> dynamicList = new List<dynamic>();
            foreach (MarkaModel markaModel in markaModelList)
            {
                dynamic foo = new ExpandoObject();
                foo.Id = markaModel.Id; 
                foo.Name = markaModel.Ad;
                dynamicList.Add(foo);
            }
             
            string json = JsonConvert.SerializeObject(dynamicList);
            return json;
        }

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

            int markaId = Convert.ToInt32(collection["MarkaId"]);
            int markaModelId = Convert.ToInt32(collection["MarkaModelId"]);
            int yil = Convert.ToInt32(collection["Yil"]);
            decimal fiyat = Convert.ToDecimal(collection["Fiyat"]);
            int durumId = Convert.ToInt32(collection["DurumId"]);
            string aciklama = collection["Aciklama"];
            IFormFile fotograf = collection.Files.First(i => i.Name == "Fotograf");
            string fotografPath = UploadImage(fotograf).Result;


            Araba araba = new Araba
            {
                MarkaId = markaId,
                MarkaModelId = markaModelId,
                Yil = yil,
                Fiyat = fiyat,
                DurumId = durumId,
                Aciklama = aciklama,
                Fotograf = fotografPath, 
                SilindiMi = false                 
            };

            _context.Araba.Add(araba);
            _context.SaveChanges();
            return View(araba);
        }
    }
}