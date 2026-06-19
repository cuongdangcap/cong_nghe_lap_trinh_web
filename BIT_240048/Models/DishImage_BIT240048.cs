namespace BIT_240048.Models
{
    public class DishImage_BIT240048
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsThumbnail { get; set; }

        public int DishId { get; set; }

        public Dish_BIT240048? Dish { get; set; }
    }
}