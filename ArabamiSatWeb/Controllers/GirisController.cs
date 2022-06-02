using System.Security.Claims;
using ArabamiSatWeb.Models.Admin;
using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Route("Home/Index")]
        public IActionResult GirisYap()
        {
            return View();
        }
        public async Task<IActionResult> GirisYap(IFormCollection collection)
        {
            string eposta = collection["eposta"];
            string sifre = collection["sifre"];
            Kullanici kullanici = _context.Kullanici.FirstOrDefault(x => x.Eposta == eposta && x.Sifre == sifre);
            if (kullanici != null)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, kullanici.Eposta),
                    new Claim(ClaimTypes.Sid,  kullanici.Id.ToString()),
                    new Claim(ClaimTypes.Actor,  kullanici.YoneticiMi.ToString())
                };
                ClaimsIdentity useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Kullanici", "Kullanici");
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> CikisYap()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap","Giris");
        }

    }
}
