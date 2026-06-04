using Microsoft.AspNetCore.Mvc;
using bai_tap_buoi_5.Models;

namespace bai_tap_buoi_5.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            return RedirectToAction("Index");
        }
    }
}