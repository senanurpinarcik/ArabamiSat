using ArabamiSatWeb.Controllers.Base;
using ArabamiSatWeb.Helper_Codes;
using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Base; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Controllers
{
    public class ArabaIlanController : BaseController
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public ArabaIlanController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion

        public IActionResult ArabaAl()
        {
            List<Araba> arabaList = _context.Araba
                .Include(i => i.Marka)
                .Include(i => i.MarkaModel)
                .Where(i => !i.SilindiMi).ToList();
            return View(arabaList);
        }

        public IActionResult ArabaDetay(int id)
        { 
            Araba model = _context.Araba
                .Include(i => i.Marka)
                .Include(i => i.MarkaModel)
                .Single(i => i.Id == id);

            List<ArabaYorum> arabaYorumList = _context.ArabaYorum.Include(i => i.Kullanici).Where(i => !i.SilindiMi && i.ArabaId == id).ToList();
            ViewBag.ArabaYorumList = arabaYorumList;

            return View(model);
        }

        public IActionResult ArabaYorumEkle(int arabaId)
        {
            ViewBag.ArabaId = arabaId;
            return View();
        }

        [HttpPost]
        public IActionResult ArabaYorumEkle(IFormCollection collection)
        {
            int arabaId = collection["ArabaId"].ToInt32();
            ViewBag.ArabaId = arabaId;
            string yorum = collection["Yorum"];

            ArabaYorum arabaYorum = new ArabaYorum
            {
                Yorum = yorum,
                ArabaId = arabaId,
                KullaniciId = SessionHelper.GetKullaniciId(),
                EkleyenKullaniciId = SessionHelper.GetKullaniciId(),
                EklenmeTarihi = DateTime.Now
            };

            _context.ArabaYorum.Add(arabaYorum);
            int returnValue = _context.SaveChanges();
            ContextMessageHandler(returnValue);

            return View(arabaYorum);
        }
    }
}
