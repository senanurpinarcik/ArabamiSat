using Microsoft.AspNetCore.Mvc;
using ArabamiSatWeb.Models;
using ArabamiSatWeb.Models.Base;
using System.Dynamic;
using ArabamiSatWeb.Models.Araba;
using ArabamiSatWeb.Models.Parametre;
using Newtonsoft.Json;

namespace ArabamiSatWeb.Controllers
{
    public class DashboardController : Controller
    {
        #region Initialize
        private readonly BaseDbContext _context;
        public DashboardController(BaseDbContext context)
        {
            _context = context;
        }
        #endregion  
        
        public IActionResult Index()
        {
            return View();
        } 
    }
}