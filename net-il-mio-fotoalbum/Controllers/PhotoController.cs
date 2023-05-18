using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Helper;
using net_il_mio_fotoalbum.Models;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoContext _database;
        private readonly UserManager<IdentityUser> _userManager;

        public PhotoController(PhotoContext database, UserManager<IdentityUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List<Photo>? photos = _database.photos.ToList();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult AdminIndex()
        {
            List<Photo> photos = _database.photos.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(photos);
        }

        [HttpGet]
        [Authorize(Roles = "SUPERADMIN")]
        public IActionResult SuperadminIndex()
        {
            List<Photo> photos = _database.photos.ToList();
            return View(photos);
        }

        [HttpGet]
        public IActionResult ShowPhoto(int id) 
        {
            Photo p = _database.photos.Include(p =>p.categories).FirstOrDefault(p => p.Id == id);
            if(p == null)
                return NotFound();
            return View(p);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult CreateForm()
        {
            PhotoFormModel model = new PhotoFormModel();
            model.AllCategories = _database.categories.ToList();
            return View("PhotoForm", model);
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
                return View("PhotoForm", model);
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
            p.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _database.photos.Add(p);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, SUPERADMIN")]
        public IActionResult DeletePhoto(int id)
        {
            Photo p = _database.photos.FirstOrDefault(x => x.Id == id);
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != p.UserId && !User.IsInRole("SUPERADMIN"))
                return BadRequest();
            ImgHelper.DeletePhoto(p.Img);
            _database.Remove(p);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "SUPERADMIN")]
        public IActionResult ChangeVisibiltyPhoto(int id)
        {
            Photo p = _database.photos.FirstOrDefault(x => x.Id == id);
            p.Visibile = !p.Visibile;
            _database.SaveChanges();
            return RedirectToAction("SuperadminIndex");
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult EditPhoto(int id)
        {
            Photo p = _database.photos.Include(x => x.categories).FirstOrDefault(x => x.Id == id);
            if(p == null)
                return NotFound();
            PhotoFormModel model = new PhotoFormModel();
            model.Id = p.Id;
            model.Title = p.Title;
            model.Description = p.Description;
            if(p.categories != null)
                foreach(Category c in p.categories)
                {
                    model.SelectedCategories.Add(c.Id);
                }
            model.AllCategories = _database.categories.ToList();
            return View("PhotoForm", model);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePhoto(int id, PhotoFormModel data)
        {
            ModelState.Remove("Img");
            if (!ModelState.IsValid)
            {
                PhotoFormModel model = data;
                model.Id = id;
                model.AllCategories = _database.categories.ToList();
                return View("PhotoForm", model);
            }
            Photo p = _database.photos.Include(x => x.categories).FirstOrDefault(x => x.Id == id);
            if(p == null)
                return NotFound();
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != p.UserId)
                return BadRequest();
            p.Title = data.Title;
            p.Description = data.Description;
            p.Visibile = data.Visibile;
            if(data.Img != null)
            {
                int index = data.Img.FileName.LastIndexOf('.');
                string ext = data.Img.FileName.Substring(index + 1);
                if (ext == "jpg" || ext == "png" || ext == "svg" || ext == "webp" || ext == "jpeg")
                    {
                        if (p.Img != null)
                            ImgHelper.DeletePhoto(p.Img);
                        p.Img = ImgHelper.SavePhoto(data.Img);
                }
            }
            if(p.categories == null)
                p.categories = new List<Category>();
            else
                p.categories.Clear();
            foreach (var i in data.SelectedCategories)
            {
                p.categories.Add(_database.categories.FirstOrDefault(x => x.Id == i));
            }
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
