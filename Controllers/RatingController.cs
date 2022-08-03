using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Rating;
using RestaurantRaterMVC.Services.Restaurant;
using RestaurantRaterMVC.Services.Rating;

namespace RestaurantRaterMVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _service;
        private readonly IRestaurantService _restaurantService;

        public RatingController(IRatingService service, IRestaurantService restaurantService) {
            _service = service;
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index() {
            var ratings = await _service.GetAllRatings();
            return View(ratings);
        }

        public async Task<IActionResult> Restaurant(int id) {
            var ratings = await _service.GetRatingsForRestaurant(id);
            return View(ratings);
        }

        public async Task<IActionResult> RateRestaurant(int id) {
            RatingCreate ratingCreate = new RatingCreate()
            {
                RestaurantId = id
            };
            return View(ratingCreate);
        }

        [HttpPost]
        public async Task<IActionResult> RateRestaurant(RatingCreate model) {
            if (!ModelState.IsValid) return View(ModelState);
            bool isRated = await _service.RateRestaurant(model);
            if (!isRated) {
                return View(model);
            } else {
                return RedirectToAction(nameof(Restaurant), new { id = model.RestaurantId });
            }
        }
    }
}