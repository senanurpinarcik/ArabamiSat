using ArabamiSatWeb.Controllers.Base; 
using ArabamiSatWeb.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace ArabamiSatWeb.Controllers
{
    public class DashboardController : BaseController
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