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

        public async Task<RestaurantDetail> GetRestaurantById(int id)
        {
            RestaurantEntity? restaurant = await _context.Restaurants
                .Include(r => r.Ratings)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (restaurant is null) {
                return null;
            }
            RestaurantDetail restaurantDetail = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
                AverageFoodScore = restaurant.AverageFoodScore,
                AverageCleanlinessScore = restaurant.AverageCleanlinessScore,
                AverageAtmosphereScore = restaurant.AverageAtmosphereScore
            };
            return restaurantDetail;
        }

        public async Task<bool> UpdateRestaurant(RestaurantEdit model)
        {
            RestaurantEntity restaurant = await _context.Restaurants.FindAsync(model.Id);
            if (restaurant is null) {
                return false;
            }
            restaurant.Location = model.Location;
            restaurant.Name = model.Name;
            return await _context.SaveChangesAsync() == 1;
        }

        public Task<bool> DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }
    }
}