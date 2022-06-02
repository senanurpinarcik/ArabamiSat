﻿using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Controllers
{
    public class KullaniciController : Controller
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public KullaniciController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion 
        [Authorize]
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

            _context.Kullanici.Update(model);
            int returnValue = _context.SaveChanges();

            if (returnValue > 0)
                ViewData["SuccessMessage"] = "İşleminiz başarılı bir şekilde gerçekleştirilmiştir.";
            else
                ViewData["ErrorMessage"] = "İşleminiz sırasında bir hata oluştu";

            return View(model);

        }
    }
}
