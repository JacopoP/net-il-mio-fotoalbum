using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class CategoryController : Controller
    {
        private PhotoContext _database;
        public CategoryController(PhotoContext database)
        {
            _database = database;
        }
        [Authorize(Roles = "SUPERADMIN")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> model = _database.categories.ToList();
            return View("CategoryList", model);
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            Category category = _database.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound(id);
            }
            _database.categories.Remove(category);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("CategoryForm");
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category data)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm");
            }
            _database.categories.Add(data);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category data = _database.categories.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound(id);
            }
            return View("CategoryForm", data);
        }

        [Authorize(Roles = "SUPERADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(int id, Category data)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryForm");
            }
            Category c = _database.categories.FirstOrDefault(x => x.Id == id);
            if (c == null)
            {
                return NotFound(id);
            }
            c.Name = data.Name;
            c.Description = data.Description;
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
