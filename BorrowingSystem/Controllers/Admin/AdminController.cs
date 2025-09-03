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
            return View(new User()); // Pass empty User model
        }

        [HttpPost("admin/login")]
        public IActionResult Login(User model)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            if (user != null && user.Active)
            {
                ViewBag.Success = "Login successful!";
                return View(model); // stay on same page with alert
                                    // Or RedirectToAction("Dashboard") if you want to go to dashboard
            }

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
