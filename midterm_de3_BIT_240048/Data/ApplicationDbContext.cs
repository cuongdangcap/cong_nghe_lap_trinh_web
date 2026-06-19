using Microsoft.EntityFrameworkCore;
using midterm_de3_BIT_240048.Models;

namespace midterm_de3_BIT_240048.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish_BIT_240048> Dishes_BIT_240048 { get; set; }

        public DbSet<DishCategory_BIT_240048> DishCategories_BIT_240048 { get; set; }

        public DbSet<DishImage_BIT_240048> DishImages_BIT_240048 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish_BIT_240048>()
                .HasIndex(x => new
                {
                    x.Name,
                    x.DishCategoryId
                })
                .IsUnique();
        }
    }
}