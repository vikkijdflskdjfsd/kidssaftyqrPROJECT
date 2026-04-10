using Microsoft.AspNetCore.Mvc;

namespace KidsSafetyQR.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "teacher" && password == "123")
            {
                HttpContext.Session.SetString("user", username);
                return RedirectToAction("Dashboard", "Kids");
            }

            ViewBag.Error = "Invalid login";
            return View();
        }
    }
}