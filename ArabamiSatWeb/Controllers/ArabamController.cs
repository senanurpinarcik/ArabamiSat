using System.Dynamic;
using ArabamiSatWeb.Helper_Codes;
using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Parametre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ArabamiSatWeb.Controllers
{
    public class ArabamController : Controller
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public ArabamController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion 

        public string GetMarkaModelList(IFormCollection collection)
        {
            int markaId = Convert.ToInt32(collection["markaId"]);
            List<MarkaModel> markaModelList = _context.MarkaModel.Where(i => i.MarkaId == markaId && !i.SilindiMi).ToList();
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

        public IActionResult Arabalarim()
        {
            return View(_context.Araba.Include(i => i.Marka).Include(i => i.MarkaModel).Where(i => !i.SilindiMi).ToList());
        }
        public IActionResult ArabaAl()
        {
            return View(_context.Araba.Include(i => i.Marka).Include(i => i.MarkaModel).Where(i => !i.SilindiMi).ToList());
        }

        public IActionResult Detay()
        {
            return View();
        }

        
        public IActionResult Ekle()
        {
            List<Marka> markaList = _context.Marka.ToList().Where(i => !i.SilindiMi).ToList();
            ViewBag.MarkaList = markaList;
            return View();
        }

        
        [HttpPost]
        public IActionResult Ekle(IFormCollection collection)
        {
            List<Marka> markaList = _context.Marka.ToList();
            ViewBag.MarkaList = markaList;

            int markaId = collection.MarkaId();
            int markaModelId = collection.MarkaModelId();
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
                EkleyenKullaniciId = -1,
                EklenmeTarihi = DateTime.Now
            };
           
            _context.Araba.Add(araba);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
            return View(araba);
        }

        public IActionResult Guncelle(int id)
        {
            Araba model = _context.Araba.Find(id)!;
            List<Marka> markaList = _context.Marka.ToList().Where(i => !i.SilindiMi).ToList();
            ViewBag.MarkaList = markaList;
            return View(model);
        } 
        [HttpPost]
        public IActionResult Guncelle(IFormCollection collection)
        {
           

            int id = Convert.ToInt32(collection["Id"]);
            int markaId = Convert.ToInt32(collection["MarkaId"]);
            int markaModelId = Convert.ToInt32(collection["MarkaModelId"]);
            int yil = Convert.ToInt32(collection["Yil"]);
            decimal fiyat = Convert.ToDecimal(collection["Fiyat"]);
            int durumId = Convert.ToInt32(collection["DurumId"]);
            string aciklama = collection["Aciklama"];
            IFormFile fotograf = collection.Files.First(i => i.Name == "Fotograf");
            string fotografPath = UploadImage(fotograf).Result;

            Araba model = _context.Araba.Find(id)!;
            model.MarkaId = markaId;
            model.MarkaModelId = markaModelId;
            model.Yil = yil;
            model.Fiyat = fiyat;
            model.DurumId = durumId;
            model.Aciklama = aciklama;
            model.Fotograf = fotografPath;
        

            _context.Araba.Update(model);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";

            List<Marka> markaList = _context.Marka.ToList().Where(i => !i.SilindiMi).ToList();
            ViewBag.MarkaList = markaList;
            return View(model);
        }
        public IActionResult Sil(int id)
        {
            Araba model = _context.Araba.Find(id)!;
            model.SilindiMi = true;

            _context.Araba.Update(model);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";

            return View(model);
            
        }
    }
}
