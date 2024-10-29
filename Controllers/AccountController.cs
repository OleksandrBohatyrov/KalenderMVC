using Microsoft.AspNetCore.Mvc;
using KalenderMVC.Data;
using KalenderMVC.Models;
using BCrypt.Net;
using System.Linq;

namespace KalenderMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Kasutajad model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Kasutajad.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser == null)
                {
                    model.Salasona = BCrypt.Net.BCrypt.HashPassword(model.Salasona);
                    _context.Kasutajad.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Email уже существует.");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Kasutajad.FirstOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Salasona))
            {
                // Создать сессию
                return RedirectToAction("Index", "Events");
            }
            ModelState.AddModelError("", "Неверный логин или пароль.");
            return View();
        }

        public IActionResult Logout()
        {
            // Уничтожить сессию
            return RedirectToAction("Login");
        }
    }
}
