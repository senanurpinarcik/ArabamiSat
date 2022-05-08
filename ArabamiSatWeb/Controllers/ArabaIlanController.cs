using ArabamiSatWeb.Models.Base;
using Microsoft.AspNetCore.Mvc;

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
