﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private PhotoContext _database;
        public ApiController(PhotoContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index(string? filter)
        {
            List<Photo> photos = _database.photos.Where(p => User.IsInRole("ADMIN") || p.Visibile).ToList<Photo>();
            if (filter != null && filter != String.Empty)
            {
                photos = photos.FindAll(x => x.Title.ToLower().Contains(filter.ToLower()));
            }

            return Ok( new { photos, isAdmin = User.IsInRole("ADMIN") });
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] Message data) 
        {
            _database.Add(data);
            _database.SaveChanges();
            return Ok();
        }
    }
}
