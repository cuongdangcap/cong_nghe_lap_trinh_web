using bai_tap_buoi_8.Models;
using Microsoft.AspNetCore.Mvc;

namespace bai_tap_buoi_8.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public BookController(IWebHostEnvironment env)
        {
            _env = env;
        }

        private static List<Book> books = new List<Book>();

        public IActionResult Index()
        {
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            if (imageFile != null)
            {
                string extension =
                    Path.GetExtension(imageFile.FileName).ToLower();

                if (extension != ".jpg" &&
                    extension != ".jpeg" &&
                    extension != ".png")
                {
                    ViewBag.Error = "Chỉ cho phép file jpg hoặc png";
                    return View(book);
                }

                string fileName =
                    Guid.NewGuid().ToString() + extension;

                string path =
                    Path.Combine(
                        _env.WebRootPath,
                        "images",
                        fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                book.ImagePath = fileName;
            }

            book.Id = books.Count + 1;

            books.Add(book);

            return RedirectToAction("Index");
        }
    }
}