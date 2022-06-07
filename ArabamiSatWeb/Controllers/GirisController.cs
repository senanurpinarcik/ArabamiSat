using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using ArabamiSatWeb.Helper_Codes;
using Microsoft.AspNetCore.Identity;


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
            string sifreMd5 = Md5Helper.CreateMd5(sifre);

            Kullanici kullanici = _context.Kullanici
                .Where(x => x.Eposta == ePosta && x.Sifre == sifreMd5).FirstOrDefault();
            if (kullanici != null)
            {
                SessionHelper.SetKullaniciId(kullanici.Id);
                SessionHelper.SetAdSoyad(kullanici.Ad + " " + kullanici.Soyad);  
                SessionHelper.SetYoneticiMi(kullanici.YoneticiMi);   
                return RedirectToAction("ArabaAl", "Arabam");
            }
            else
            {
                ViewData["ErrorMessage"] = "Geçersiz Eposta ya da Şifre!";
            }
            return View();
        }

        public IActionResult Cikis()
        {
            SessionHelper.ClearSession();
            return RedirectToAction("Giris");
        }

        public IActionResult YeniKayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YeniKayit(IFormCollection collection)
        {
            string ad = collection["Ad"];
            string soyad = collection["Soyad"];
            string ePosta = collection["Eposta"];
            string sifre = collection["Sifre"];
            string sifreMd5 = Md5Helper.CreateMd5(sifre);

            Kullanici kullanici = new Kullanici
            {
                Ad = ad,
                Soyad = soyad,
                Eposta = ePosta,
                Sifre = sifreMd5,
                EklenmeTarihi = DateTime.Now
            };

            _context.Kullanici.Add(kullanici);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
            return View(kullanici);
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(IFormCollection collection)
        {
            string ePosta = collection["Eposta"];

            Kullanici? kullanici = _context.Kullanici
                .FirstOrDefault(x => x.Eposta == ePosta);
            
            if (kullanici != null)
            {
                Guid rastgele = Guid.NewGuid();
                string sifre = rastgele.ToString().Substring(0, 8);
                string sifreMd5 = Md5Helper.CreateMd5(sifre);

                kullanici.Sifre = sifreMd5;  
                int returnValue = _context.SaveChanges();

                if (returnValue > 0)
                    ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
                else
                {
                    ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
                    return View();
                }
                    
                string mailIcerik = "Merhaba " + kullanici.Ad + "" + kullanici.Soyad + "<br/> Şifreniz: " +
                                    sifre;
                MailHelper.SendMail("Şifre Değişikliği", mailIcerik, kullanici.Eposta); 
            }
            return RedirectToAction("Giris");
        }

    }

}
