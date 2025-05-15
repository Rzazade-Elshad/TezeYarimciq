using Mamba2.DAL;
using Mamba2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mamba2.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContexts _db;
        public CategoryController(AppDbContexts db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var CategoryListt = _db.Categories.Include(o=>o.PortfolioList).ToList();    
            return View(CategoryListt);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Emeliyat sehvdir , geri qayit");
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            var cate = _db.Categories.Find(id);
            if (cate == null)
            {
                return BadRequest("Emeliyat sehvdir , geri qayit");
            }
            return View(cate);
        }
        [HttpPost]
        public IActionResult Edit(int id ,Category category)
        {
            var cate=_db.Categories.AsNoTracking().FirstOrDefault(o=>o.Id==id);
            if (!ModelState.IsValid || cate==null)
            {
                return BadRequest("Emeliyat sehvdir , geri qayit");
            }
            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var cate = _db.Categories.Find(id);
            if (cate == null)
            {
                return BadRequest("Emeliyat sehvdir , geri qayit");
            }
            foreach (var P in _db.Portfolios.Include(o => o.Category).ToList())
            {
                if(P.CategoryId == id)
                {
                    P.CategoryId = null;
                    _db.SaveChanges();
                }
            }
            _db.Categories.Remove(cate);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
      /*  public IActionResult Asssign(int id)
        {

        }*/
    }
}
