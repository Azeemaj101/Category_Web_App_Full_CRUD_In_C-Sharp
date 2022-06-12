using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyWebApp.Models;

namespace MyApp.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            { 
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category Create Done";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            var catagery = _context.Categories.Find(id);
            if(catagery == null)
            {
                return NotFound();
            }
            return View(catagery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category Update Done";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categery = _context.Categories.Find(id);
            if (categery == null)
            {
                return NotFound();
            }
            return View(categery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var categery = _context.Categories.Find(id);
            if (categery == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categery);
            _context.SaveChanges();
            TempData["success"] = "Category Delete Done";
            return RedirectToAction("Index");
        }
    }
}
