using Microsoft.AspNetCore.Mvc;
using BorrowingSystem.Data;
using BorrowingSystem.Models.UserAccount;
using System.Linq;

namespace BorrowingSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null && user.Active)
                {
                    // TODO: Save to session/cookie
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Error = "Invalid username or password.";
            }

            return View(model);
        }
    }
}
