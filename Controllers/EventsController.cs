using Microsoft.AspNetCore.Mvc;
using KalenderMVC.Data;
using KalenderMVC.Models;
using System.Linq;

namespace KalenderMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Sondmused.ToList();
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sondmus model)
        {
            if (ModelState.IsValid)
            {
                _context.Sondmused.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var event = _context.Sondmused.Find(id);
            return View(event);
        }

        [HttpPost]
        public IActionResult Edit(Sondmus model)
        {
            if (ModelState.IsValid)
            {
                _context.Sondmused.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var event = _context.Sondmused.Find(id);
            _context.Sondmused.Remove(event);
        _context.SaveChanges();
            return RedirectToAction("Index");
    }
}
}
