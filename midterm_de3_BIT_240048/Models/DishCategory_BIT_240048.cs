using System.ComponentModel.DataAnnotations;

namespace midterm_de3_BIT_240048.Models
{
    public class DishCategory_BIT_240048
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại món ăn không được để trống")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Dish_BIT_240048>? Dishes { get; set; }
    }
}