using System.ComponentModel.DataAnnotations;

namespace BIT_240048.Models
{
    public class Dish_BIT240048
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên món ăn không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue,
            ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Thời gian chế biến phải lớn hơn 0")]
        public int PreparationTime { get; set; }

        public bool IsAvailable { get; set; }

        public string? Description { get; set; }

        public int DishCategoryId { get; set; }

        public DishCategory_BIT240048? DishCategory { get; set; }

        public ICollection<DishImage_BIT240048>? Images { get; set; }
    }
}