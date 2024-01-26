using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            ViewBag.Selamlama = saat > 12 ? "iyi Günler" : "Günaydın";

            var meetinginfo = new MeetingInfo()
            {
                ID = 1,
                Location = "İstanbul",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = Repository.Users.Where(i => i.WillAttend == true).Count(),


            };
            return View(meetinginfo);
        }
    }
}