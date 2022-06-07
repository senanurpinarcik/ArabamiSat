using ArabamiSatWeb.Helper_Codes;
using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Base;
using ArabamiSatWeb.Models.Kullanici;
using ArabamiSatWeb.Models.Parametre;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabamiSatWeb.Controllers
{
    public class ArabaIlanController : Controller
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public ArabaIlanController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion

        
    }
}
