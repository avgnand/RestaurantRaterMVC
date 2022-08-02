using RestaurantRaterMVC.Data;

namespace RestaurantRaterMVC.Services.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        private AppDbContext _context;
        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }
    }
}