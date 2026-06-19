namespace midterm_de3_BIT_240048.Models
{
    public class DishImage_BIT_240048
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public bool IsThumbnail { get; set; }

        public int DishId { get; set; }

        public Dish_BIT_240048? Dish { get; set; }
    }
}