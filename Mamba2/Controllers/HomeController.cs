using Mamba2.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mamba2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContexts _db;
        public HomeController(AppDbContexts db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var PortfolioListt=_db.Portfolios.Include(o=>o.Category).ToList();
            return View(PortfolioListt);
        }
    }
}
