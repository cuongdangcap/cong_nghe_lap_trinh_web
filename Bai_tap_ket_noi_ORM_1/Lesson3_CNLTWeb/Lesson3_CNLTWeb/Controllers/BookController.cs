using Lesson3_CNLTWeb.Data;
using Lesson3_CNLTWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson3_CNLTWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository;

        // Tiêm BookRepository vào Controller
        public BookController(BookRepository repository)
        {
            _repository = repository;
        }

        // 1. Hiển thị danh sách sách (Read)
        public IActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }

        // 2. Hiển thị form Thêm mới sách (Create - GET)
        public IActionResult Create()
        {
            return View();
        }

        // 3. Xử lý lưu sách mới vào CSDL (Create - POST)
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(book);
                return RedirectToAction("Index"); // Thêm xong quay về trang danh sách
            }
            return View(book);
        }

        // 4. Hiển thị form Sửa sách (Update - GET)
        public IActionResult Edit(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // 5. Xử lý lưu thông tin sách đã sửa (Update - POST)
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // 6. Xóa sách (Delete - POST)
        // Lưu ý: Thường làm nút Xóa ở View gửi request POST hoặc form
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}