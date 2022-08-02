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

        public async Task<bool> CreateRestaurant(RestaurantCreate model)
        {
            RestaurantEntity restaurant = new RestaurantEntity()
            {
                Name = model.Name,
                Location = model.Location
            };
            _context.Restaurants.Add(restaurant);
            return await _context.SaveChangesAsync() == 1;
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

        public Task<RestaurantDetail> GetRestaurantById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }
    }
}