using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
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
                ViewData["ErrorMessage"] = "Geçersiz Eposta ya da Şifre!";
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
        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(IFormCollection collection)
        {
            string ad = collection["Ad"];
            string soyad = collection["Soyad"];
            string ePosta = collection["Eposta"];
            string sifre = collection["Sifre"];

            Kullanici kullanici = _context.Kullanici
                .Where(x => x.Eposta == ePosta).FirstOrDefault();
            Guid rastgele = Guid.NewGuid();
                if (kullanici != null)
                {
                    kullanici.Sifre = rastgele.ToString().Substring(0, 8);
                    _context.SaveChanges();
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.UseDefaultCredentials = false;
                    client.Timeout = 10000;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("uu7215440@gmail.com", "Şifre sıfırlama");
                    mail.To.Add(kullanici.Eposta);
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mail.Subject = "Şifre Değiştirme İsteği:";
                    mail.Body += "Merhaba " + kullanici.Ad + "" + kullanici.Soyad + "<br/> Şifreniz: " +
                                 kullanici.Sifre;
                    NetworkCredential net = new NetworkCredential("senanurpinarcik@gmail.com", "e6b57e2d");
                    client.Credentials = net;
                    client.EnableSsl = true;
                    client.Send(mail);
                }
                return RedirectToAction("Giris");
            }
          
        }
        
    }
