using BorrowingSystem.Data;
using BorrowingSystem.Models.UserAccount;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BorrowingSystem.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("admin/login")]
        public IActionResult Login()
        {
            return View(new User()); // show empty login form
        }

        [HttpPost("admin/login")]
        public IActionResult Login(User model)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null && user.Active)
            {
                // ✅ Redirect to Admin Dashboard after successful login
                return RedirectToAction("Dashboard", "Admin");
            }

            // ❌ Show error message if login failed
            ViewBag.Error = "Invalid username or password";
            return View(model);
        }

        [HttpGet("admin/dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
