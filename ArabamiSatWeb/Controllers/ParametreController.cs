using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Parametre;
using Microsoft.AspNetCore.Mvc;

namespace ArabamiSatWeb.Controllers
{
    public class ParametreController : Controller
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public ParametreController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion

        public IActionResult MarkaListe()
        {
            List<Marka> markaListe = _context.Marka.ToList()
                .Where(i => !i.SilindiMi).ToList();
            return View(markaListe);
        }

        public IActionResult MarkaEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MarkaEkle(IFormCollection collection)
        {
            string ad = collection["Ad"];

            Marka marka = new Marka
            {
                Ad = ad
            };

            _context.Marka.Add(marka);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
                     
            return View(marka);
        }

        public IActionResult MarkaGuncelle(int id)
        {
            Marka marka = _context.Marka.Find(id)!;
            return View(marka);
        }

        [HttpPost]
        public IActionResult MarkaGuncelle(IFormCollection collection)
        {
            int id = Convert.ToInt32(collection["Id"]);
            string ad = collection["Ad"];

            Marka marka = _context.Marka.Find(id)!;
            marka.Ad = ad;

            _context.Marka.Update(marka);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";

            return View(marka);
        }

        public IActionResult MarkaSil(int id)
        {
            Marka marka = _context.Marka.Find(id)!;
            marka.SilindiMi = true;

            _context.Marka.Update(marka);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";

            return View(marka);
        }
    }
}
