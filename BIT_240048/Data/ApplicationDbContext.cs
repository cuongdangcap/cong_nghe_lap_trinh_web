using Microsoft.EntityFrameworkCore;
using BIT_240048.Models;

namespace BIT_240048.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DishCategory_BIT240048> DishCategories_BIT240048 { get; set; }

        public DbSet<Dish_BIT240048> Dishes_BIT240048 { get; set; }

        public DbSet<DishImage_BIT240048> DishImages_BIT240048 { get; set; }
    }
}