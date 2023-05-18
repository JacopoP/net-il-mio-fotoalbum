using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoApiController : ControllerBase { 
        private PhotoContext _database;
        public PhotoApiController(PhotoContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index(string? filter)
        {
            List<Photo> photos = _database.photos.Where(p => User.IsInRole("SUPERADMIN") || p.Visibile).ToList<Photo>();
            if (filter != null && filter != String.Empty)
            {
                photos = photos.FindAll(x => x.Title.ToLower().Contains(filter.ToLower()));
            }

            return Ok(photos);
        }
    }
}
