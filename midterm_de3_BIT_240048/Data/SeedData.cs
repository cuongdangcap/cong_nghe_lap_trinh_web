using midterm_de3_BIT_240048.Models;

namespace midterm_de3_BIT_240048.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.DishCategories_BIT_240048.Any())
                return;

            var categories = new List<DishCategory_BIT_240048>
            {
                new()
                {
                    Name = "Món Việt",
                    Description = "Ẩm thực Việt Nam"
                },
                new()
                {
                    Name = "Món Hàn",
                    Description = "Ẩm thực Hàn Quốc"
                },
                new()
                {
                    Name = "Đồ uống",
                    Description = "Nước giải khát"
                }
            };

            context.DishCategories_BIT_240048.AddRange(categories);
            context.SaveChanges();

            var dishes = new List<Dish_BIT_240048>
            {
                new()
                {
                    Name = "Phở bò",
                    Price = 50000,
                    PreparationTime = 20,
                    IsAvailable = true,
                    Description = "Phở bò truyền thống",
                    DishCategoryId = categories[0].Id
                },

                new()
                {
                    Name = "Bún chả",
                    Price = 45000,
                    PreparationTime = 15,
                    IsAvailable = true,
                    Description = "Bún chả Hà Nội",
                    DishCategoryId = categories[0].Id
                },

                new()
                {
                    Name = "Kimbap",
                    Price = 60000,
                    PreparationTime = 25,
                    IsAvailable = true,
                    Description = "Cơm cuộn Hàn Quốc",
                    DishCategoryId = categories[1].Id
                },

                new()
                {
                    Name = "Tokbokki",
                    Price = 70000,
                    PreparationTime = 30,
                    IsAvailable = false,
                    Description = "Bánh gạo cay",
                    DishCategoryId = categories[1].Id
                },

                new()
                {
                    Name = "Trà đào",
                    Price = 30000,
                    PreparationTime = 10,
                    IsAvailable = true,
                    Description = "Trà đào cam sả",
                    DishCategoryId = categories[2].Id
                }
            };

            context.Dishes_BIT_240048.AddRange(dishes);
            context.SaveChanges();

            var images = new List<DishImage_BIT_240048>
            {
                new()
                {
                    ImageUrl = "https://images.unsplash.com/photo-1582878826629-29b7ad1cdc43",
                    IsThumbnail = true,
                    DishId = dishes[0].Id
                },

                new()
                {
                    ImageUrl = "https://images.unsplash.com/photo-1515003197210-e0cd71810b5f",
                    IsThumbnail = false,
                    DishId = dishes[0].Id
                },

                new()
                {
                    ImageUrl = "https://images.unsplash.com/photo-1550547660-d9450f859349",
                    IsThumbnail = true,
                    DishId = dishes[1].Id
                },

                new()
                {
                    ImageUrl = "https://images.unsplash.com/photo-1604908554027-7dd8b4f9c1e2",
                    IsThumbnail = true,
                    DishId = dishes[2].Id
                }
            };

                        context.DishImages_BIT_240048.AddRange(images);
                        context.SaveChanges();
        }
    }
}