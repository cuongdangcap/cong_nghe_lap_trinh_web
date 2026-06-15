using System.ComponentModel.DataAnnotations;

namespace bai_tap_buoi_8.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string Name { get; set; }

        [Range(1, 1000000, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }
    }
}