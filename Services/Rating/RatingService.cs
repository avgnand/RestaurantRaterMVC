
using Microsoft.EntityFrameworkCore;
using RestaurantRaterMVC.Data;
using RestaurantRaterMVC.Models;

namespace RestaurantRaterMVC.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _context;

        public RatingService(AppDbContext context) {
            _context = context;
        }

        public Task<bool> DeleteRating(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RatingListItem>> GetAllRatings()
        {
            var ratings = _context.Ratings
                .Select(r => new RatingListItem()
                {
                    Id = r.Id,
                    RestaurantName = r.Restaurant.Name,
                    FoodScore = r.FoodScore,
                    AtmosphereScore = r.AtmosphereScore,
                    CleanlinessScore = r.CleanlinessScore
                });
            return await ratings.ToListAsync();
        }

        public Task<List<RatingListItem>> GetRatingsForRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RateRestaurant(RatingCreate model)
        {
            throw new NotImplementedException();
        }
    }
}