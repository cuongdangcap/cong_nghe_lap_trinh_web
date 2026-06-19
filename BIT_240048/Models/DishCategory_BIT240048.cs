using System.ComponentModel.DataAnnotations;

namespace BIT_240048.Models
{
    public class DishCategory_BIT240048
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại món ăn không được để trống")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}