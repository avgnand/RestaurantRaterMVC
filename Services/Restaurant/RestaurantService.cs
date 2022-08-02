using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models.Restaurant;

namespace RestaurantRaterMVC.Services.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        private AppDbContext _context;
        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RestaurantListItem>> GetAllRestaurants()
        {
            List<RestaurantListItem> restaurants = await _context.Restaurants
                .Include(r => r.Ratings)
                .Select(r => 
                new RestaurantListItem(){
                    Id = r.Id,
                    Name = r.Name,
                    Score = r.Score
                })
                .ToListAsync();
                return restaurants;
        }
    }
}