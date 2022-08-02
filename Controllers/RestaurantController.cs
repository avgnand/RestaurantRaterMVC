using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Restaurant;
using RestaurantRaterMVC.Services;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _service;
        public RestaurantController(IRestaurantService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();
            return View(restaurants);
        }
    }
}