using Lesson3_CNLTWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lesson3_CNLTWeb.Data
{
    /// <summary>
    /// Thực hiện các thao tác CRUD với bảng Book qua ORM (Entity Framework Core).
    /// </summary>
    public class BookRepository
    {
        private readonly AppDbContext _context;

        // Tiêm DbContext thay vì IConfiguration
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            // Lấy tất cả sách, sắp xếp theo Id
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public Book? GetById(int id)
        {
            // Tìm sách theo khóa chính
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            // Thêm đối tượng vào context và lưu thay đổi
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public bool Update(Book book)
        {
            // Tìm đối tượng cần sửa
            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null)
            {
                return false;
            }

            // Cập nhật thông tin
            existingBook.Name = book.Name;
            existingBook.Price = book.Price;

            // Lưu thay đổi xuống DB, trả về true nếu có dòng bị ảnh hưởng
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            // Tìm đối tượng cần xóa
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return false;
            }

            // Xóa khỏi context và lưu thay đổi
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }
    }
}