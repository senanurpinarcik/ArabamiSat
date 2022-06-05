using ArabamiSatWeb.Models.Base;
using Microsoft.AspNetCore.Mvc;

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