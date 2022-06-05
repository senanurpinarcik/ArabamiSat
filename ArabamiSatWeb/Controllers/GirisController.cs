using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Controllers
{
    public class GirisController : Controller
    {
        #region Initialize

        private readonly BaseDbContext _context;

        public GirisController(BaseDbContext context)
        {
            _context = context;
        }

        #endregion

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(IFormCollection collection)
        {
            string ePosta = collection["Eposta"];
            string sifre = collection["Sifre"];

            Kullanici kullanici = _context.Kullanici
                .Where(x => x.Eposta == ePosta && x.Sifre == sifre).FirstOrDefault();
            if (kullanici != null)
            {
                HttpContext.Session.SetString("AdSoyad", kullanici.Ad + " " + kullanici.Soyad);
                HttpContext.Session.SetString("KullaniciId", kullanici.Id.ToString());
                HttpContext.Session.SetString("YoneticiMi", kullanici.YoneticiMi.ToString());
                return RedirectToAction("ArabaAl", "Arabam");
            }
            else
            {
                TempData["Mesaj"] = "Geçersiz Eposta ya da Şifre!";
            }
            return View();
        }
        public IActionResult YeniKayit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult YeniKayit(IFormCollection collection)
        {
            List<Kullanici> kullanıcıList = _context.Kullanici.ToList();
            ViewBag.MarkaList = kullanıcıList;

            string ad = collection["Ad"];
            string soyad = collection["Soyad"];
            string ePosta = collection["Eposta"];
            string sifre = collection["Sifre"];
            
            Kullanici kullanici = new Kullanici()
            {
                Ad = ad,
                Soyad = soyad,
                Eposta = ePosta,
                Sifre = sifre
            };

            _context.Kullanici.Add(kullanici);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
            return View(kullanici);
        }

    }
}
