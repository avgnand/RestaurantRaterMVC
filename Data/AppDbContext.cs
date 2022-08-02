using Microsoft.EntityFrameworkCore;

namespace RestaurantRaterMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RestaurantEntity> Restaurants { get; set; }

        public DbSet<RatingEntity> Ratings { get; set; }
    }
}