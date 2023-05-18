using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class MessageController : Controller
    {
        private PhotoContext _database;

        public MessageController(PhotoContext database)
        {
            _database = database;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Message> messages = _database.messages.ToList();
            return View("Messages", messages);
        }
        [HttpGet]
        public IActionResult CreateMessage(int i)
        {
            ViewData["i"] = i;
            return View("MessageForm");
        }
        [HttpPost]
        public ActionResult AddMessage(int i, Message m)
        {
            if(!ModelState.IsValid)
            {
                return View("MessageForm", m);
            }
            m.UserID = _database.photos.FirstOrDefault(x => x.Id == i).UserId;
            _database.messages.Add(m);
            _database.SaveChanges();
            return Redirect(Url.Action("Index", "Photo"));
        }
    }
}
