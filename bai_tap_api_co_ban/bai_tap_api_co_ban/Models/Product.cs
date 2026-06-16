using System.ComponentModel.DataAnnotations;

namespace bai_tap_api_co_ban.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [MinLength(3, ErrorMessage = "Tên phải có ít nhất 3 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá là bắt buộc")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }
    }
}