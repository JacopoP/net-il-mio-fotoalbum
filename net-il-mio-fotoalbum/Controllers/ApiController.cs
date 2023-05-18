using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private PhotoContext _database;
        public ApiController(PhotoContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index(string? filter = null)
        {
            List<Photo> photos = _database.photos.Include(p => p.categories).ToList<Photo>();
            if (filter != null && filter != String.Empty)
            {
                photos = photos.FindAll(x => x.Title.ToLower().Contains(filter.ToLower()));
            }
            return Ok(photos);
        }
    }
}
