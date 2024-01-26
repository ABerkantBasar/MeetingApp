using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;
namespace MeetingApp.Controllers

{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Apply()
        {
            var meetinginfo = new MeetingInfo()
            {
                ID = 1,
                Location = "İstanbul",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = 100,


            };
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                Repository.CreateUser(model);
                ViewBag.UserCount = Repository.Users.Where(i => i.WillAttend == true).Count();
                return View("Thanks", model);
            }
            else
            {
                return View(model);
            }

        }

        public IActionResult List()
        {
            return View(Repository.Users);
        }

        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}