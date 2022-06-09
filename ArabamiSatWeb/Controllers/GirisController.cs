using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Mvc;
using ArabamiSatWeb.Controllers.Base;
using ArabamiSatWeb.Helper_Codes;


namespace ArabamiSatWeb.Controllers
{
    public class GirisController : BaseController
    {
        #region Initialize 
        private readonly BaseDbContext _context;

        public GirisController(BaseDbContext context)
        {
            _context = context;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string ePosta = collection["Eposta"];
            string sifre = collection["Sifre"];
            string sifreMd5 = Md5Helper.CreateMd5(sifre);

            Kullanici? kullanici = _context.Kullanici
                .FirstOrDefault(x => x.Eposta == ePosta && x.Sifre == sifreMd5 && !x.SilindiMi);
            if (kullanici != null)
            {
                if (kullanici.DogrulandiMi)
                {
                    if (kullanici.IkiFaktorluDogrulama)
                    {
                        KullaniciDogrulamaKoduGonder(kullanici, "Oturum Açma İşlemi", out string anahtarMd5);
                        return RedirectToAction("IkiFaktorluDogrulama", "Giris", new { id = kullanici.Id, anahtar = anahtarMd5 });
                    }
                    StartSession(kullanici);
                    return RedirectToAction("Arabalarim", "Arabam");
                }
                else
                {
                    KullaniciDogrulamaKoduGonder(kullanici, "Kullanıcı Doğrulama", out string anahtarMd5);
                    return RedirectToAction("KullaniciDogrulama", new { id = kullanici.Id,anahtar = anahtarMd5 });
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Geçersiz E-posta ya da Şifre!";
            }
            return View();
        }

        public IActionResult Cikis()
        {
            SessionHelper.EndSession();
            return RedirectToAction("Index");
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(IFormCollection collection)
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
                IkiFaktorluDogrulama = true,
                EklenmeTarihi = DateTime.Now
            };

            _context.Kullanici.Add(kullanici);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
            {
                KullaniciDogrulamaKoduGonder(kullanici, "Kullanıcı Doğrulama", out string anahtarMd5);
                return RedirectToAction("KullaniciDogrulama", new { id = kullanici.Id, anahtar = anahtarMd5 });
            }
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
            return View(kullanici);
        }

        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SifremiUnuttum(IFormCollection collection)
        {
            string ePosta = collection["Eposta"];

            Kullanici? kullanici = _context.Kullanici
                .FirstOrDefault(x => x.Eposta == ePosta && !x.SilindiMi);

            if (kullanici != null)
            {
                Guid guidVal = Guid.NewGuid();
                string sifre = guidVal.ToString().Substring(0, 8);
                string sifreMd5 = Md5Helper.CreateMd5(sifre);

                kullanici.Sifre = sifreMd5;
                int returnValue = _context.SaveChanges();

                if (returnValue > 0)
                    ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
                else
                {
                    ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
                    return View(kullanici);
                }

                string mailIcerik = "Merhaba " + kullanici.Ad + "" + kullanici.Soyad + "<br/> Şifreniz: " + sifre;
                MailHelper.SendMail("Şifre Değişikliği", mailIcerik, kullanici.Eposta);
            }
            else
            {
                ViewData["ErrorMessage"] = "Geçersiz E-posta";
            }

            return View();
        }

        public IActionResult KullaniciDogrulama(int id, string anahtar)
        {
            Kullanici kullanici = _context.Kullanici.Find(id)!;
            ViewData["InfoMessage"] = "E-postanıza gelen doğrulama kodunu aşağıya girin.";
            ViewBag.Anahtar = anahtar;
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult KullaniciDogrulama(IFormCollection collection)
        {
            int id = collection["Id"].ToInt32();
            Kullanici kullanici = _context.Kullanici.Find(id)!;
            string anahtar = collection["Anahtar"];
            string dogrulamaKodu = collection["DogrulamaKodu"];
            string dogrulamaKoduMd5 = Md5Helper.CreateMd5(dogrulamaKodu);
            ViewBag.Anahtar = anahtar;

            if (anahtar == dogrulamaKoduMd5)
            {
                kullanici.DogrulandiMi = true;
                _context.Kullanici.Update(kullanici);
                int returnValue = _context.SaveChanges();

                if (returnValue > 0)
                    return RedirectToAction("Index");
                else
                    ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";
            }
            else
            {
                ViewData["ErrorMessage"] = "Doğrulama kodu hatalı. Tekrar gönderilen doğrulama kodunu giriniz.";
            }

            return View();
        }

        public IActionResult IkiFaktorluDogrulama(int id, string anahtar)
        {
            Kullanici kullanici = _context.Kullanici.Find(id)!;
            ViewData["InfoMessage"] = "E-postanıza gelen doğrulama kodunu aşağıya girin.";
            ViewBag.Anahtar = anahtar;
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult IkiFaktorluDogrulama(IFormCollection collection)
        {
            int id = collection["Id"].ToInt32();
            Kullanici kullanici = _context.Kullanici.Find(id)!;
            string anahtar = collection["Anahtar"];
            string dogrulamaKodu = collection["DogrulamaKodu"];
            string dogrulamaKoduMd5 = Md5Helper.CreateMd5(dogrulamaKodu);
            ViewBag.Anahtar = anahtar;

            if (anahtar == dogrulamaKoduMd5)
            {
                StartSession(kullanici);
                return RedirectToAction("Arabalarim", "Arabam"); 
            }
            else
            {
                ViewData["ErrorMessage"] = "Doğrulama kodu hatalı. Tekrar gönderilen doğrulama kodunu giriniz.";
            }

            return View();
        }

        private void KullaniciDogrulamaKoduGonder(Kullanici kullanici, string baslik, out string anahtarMd5)
        {
            string anahtar = GuidHelper.CreateShortGuid();
            anahtarMd5 = Md5Helper.CreateMd5(anahtar);
            string mailIcerik = "Merhaba " + kullanici.Ad + " " + kullanici.Soyad + "<br/> Kullanıcı Doğrulama Kodu: " + anahtar;
            MailHelper.SendMail(baslik, mailIcerik, kullanici.Eposta);
        }

        private void StartSession(Kullanici kullanici)
        {
            SessionHelper.SetKullaniciId(kullanici.Id);
            SessionHelper.SetAdSoyad(kullanici.Ad + " " + kullanici.Soyad);
            SessionHelper.SetYoneticiMi(kullanici.YoneticiMi);
        }
    }
}
