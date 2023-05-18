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
        public IActionResult CreateMessage()
        {
            return View("MessageForm");
        }
        [HttpPost]
        public ActionResult AddMessage(Message m)
        {
            if(!ModelState.IsValid)
            {
                return View("MessageForm", m);
            }
            _database.messages.Add(m);
            _database.SaveChanges();
            return Redirect(Url.Action("Index", "Photo"));
        }
    }
}
