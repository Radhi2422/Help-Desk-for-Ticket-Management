
using Help_Desk_for_Ticket_Management_System.Models;
using Help_Desk_for_Ticket_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Help_Desk_for_Ticket_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMongoCollection<UserModel> _users;

        public AccountController(IMongoDatabase database)
        {
            // "Users" is the collection name in MongoDB Atlas
            _users = database.GetCollection<UserModel>("Users");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Query MongoDB for matching user
            var user = _users.Find(u =>
                u.UserId == model.UserId &&
                u.Password == model.Password).FirstOrDefault();

            if (user == null)
            {
                ViewBag.Error = "Invalid UserId or Password";
                return View(model);
            }

            // Store session values
            HttpContext.Session.SetString("UserId", user.UserId);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Login");
        }
    }
}