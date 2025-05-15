using Mamba2.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mamba2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContexts _db;
        public PortfolioController(AppDbContexts db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var PortfolioListt = _db.Portfolios.Include(o => o.Category).ToList();
            return View(PortfolioListt);
        }
    }
}
