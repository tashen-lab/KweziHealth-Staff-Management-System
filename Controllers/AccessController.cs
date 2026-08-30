using Microsoft.AspNetCore.Mvc;
using StaffManagementApp.Models;

namespace StaffManagementApp.Controllers
{
    public class AccessController : Controller
    {
        //Hardcoded admin credentials for demo purposes only
        private static readonly SystemAdmin _admin = new()
        {
            Username = "admin",
            Password = "Admin123!"
        };

        [HttpGet]
        public IActionResult Login()
        {
            //Already logged in? Skip straight to the staff list
            if (HttpContext.Session.GetString("IsAuthenticated") == "true")
            {
                return RedirectToAction("Index", "Staff");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(SystemAdmin login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            if (login.Username == _admin.Username && login.Password == _admin.Password)
            {
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("Username", login.Username);
                return RedirectToAction("Index", "Staff");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(login);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
