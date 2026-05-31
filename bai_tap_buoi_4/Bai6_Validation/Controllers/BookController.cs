using Microsoft.AspNetCore.Mvc;
using Bai6_Validation.Models;

namespace Bai6_Validation.Controllers
{
    public class BookController : Controller
    {
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

            ViewBag.Message = "Thêm sách thành công";
            return View();
        }
    }
}