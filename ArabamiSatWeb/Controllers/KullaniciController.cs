using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici; 
using Microsoft.AspNetCore.Mvc; 
using ArabamiSatWeb.Controllers.Base;
using ArabamiSatWeb.Helper_Codes;

namespace ArabamiSatWeb.Controllers
{
    public class KullaniciController : BaseController
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public KullaniciController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion
        public IActionResult Kullanici()
        {
            List<Kullanici> kullaniciListe = _context.Kullanici.ToList()
                .Where(i => !i.SilindiMi).ToList();
            return View(kullaniciListe);
        }
        public IActionResult Sil(int id)
        {
            Kullanici model = _context.Kullanici.Find(id)!;
            model.SilindiMi = true;
            model.SilenKullaniciId = SessionHelper.GetKullaniciId();
            model.SilinmeTarihi = DateTime.Now;

            _context.Kullanici.Update(model);
            int returnValue = _context.SaveChanges();
            ContextMessageHandler(returnValue);

            return View(model);
        }

        public IActionResult KullaniciGuncelle()
        {
            int kullaniciId = SessionHelper.GetKullaniciId();
            Kullanici kullanici = _context.Kullanici.Find(kullaniciId)!;
            return View(kullanici);
        }

        [HttpPost]
        public IActionResult KullaniciGuncelle(IFormCollection collection)
        {
            int id = SessionHelper.GetKullaniciId();
            string ad = collection.Ad();
            string soyad = collection.Soyad();
            bool dogrulama = collection.IkiFaktorluDogrulama();

            Kullanici kullanici = _context.Kullanici.Find(id)!;
            kullanici.Ad = ad;
            kullanici.Soyad = soyad;
            kullanici.IkiFaktorluDogrulama = dogrulama;
            kullanici.GuncelleyenKullaniciId = id;
            kullanici.GuncellenmeTarihi = DateTime.Now;

            _context.Kullanici.Update(kullanici);
            int returnValue = _context.SaveChanges();
            ContextMessageHandler(returnValue);

            return View(kullanici); 
        }
    }
}
