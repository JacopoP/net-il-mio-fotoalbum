using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Helper;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoContext _database;

        public PhotoController(PhotoContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Landing()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<Photo>? photos = _database.photos.ToList();
            return View(photos);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult CreateForm()
        {
            PhotoFormModel model = new PhotoFormModel();
            model.AllCategories = _database.categories.ToList();
            return View("PizzaForm", model);
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPhoto(PhotoFormModel data) 
        {
            if(!ModelState.IsValid)
            {
                PhotoFormModel model = data;
                model.AllCategories = _database.categories.ToList();
                return View("PizzaForm", model);
            }
            Photo p = new Photo();
            p.Title = data.Title;
            p.Description = data.Description;
            p.Visibile = data.Visibile;
            p.Img = ImgHelper.SavePhoto(data.Img);
            if(data.SelectedCategories != null)
            {
                p.categories = new List<Category>();
                foreach(var i in data.SelectedCategories)
                {
                    p.categories.Add(_database.categories.FirstOrDefault(x => x.Id == i));
                }
            }
            _database.photos.Add(p);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
