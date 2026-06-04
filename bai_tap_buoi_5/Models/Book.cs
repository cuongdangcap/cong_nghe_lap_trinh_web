using System.ComponentModel.DataAnnotations;

namespace bai_tap_buoi_5.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ten sach khong duoc de trong")]
        public string Title { get; set; }

        [Range(0.01, double.MaxValue,
            ErrorMessage = "Gia phai lon hon 0")]
        public decimal Price { get; set; }
    }
}