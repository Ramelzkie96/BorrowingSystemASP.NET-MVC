using Microsoft.AspNetCore.Mvc;

namespace BorrowingSystem.Controllers.Admin
{
    public class AdminController : Controller
    {
        // GET: /admin/login
        [HttpGet("admin/login")]
        public IActionResult Login()
        {
            return View(); // This will look for Views/Admin/Login.cshtml
        }

        // POST: /admin/login
        [HttpPost("admin/login")]
        public IActionResult Login(string username, string password)
        {
            // TODO: Replace this with database validation
            if (username == "admin" && password == "123")
            {
                // Redirect to dashboard on success
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        // GET: /admin/dashboard
        [HttpGet("admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View(); // This will look for Views/Admin/Dashboard.cshtml
        }
    }
}
