using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Models.Rating;
using RestaurantRaterMVC.Services.Restaurant;
using RestaurantRaterMVC.Services.Rating;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> Create() {
            // RatingCreate ratingCreate = new RatingCreate()
            // {
            //     RestaurantId = id
            // };
            // return View(ratingCreate);
            var restaurants = await _restaurantService.GetAllRestaurants();
            var restaurantOptions = new List<SelectListItem>();
            foreach (var r in restaurants)
            {
                restaurantOptions.Add(
                    new SelectListItem()
                    {
                        Text = r.Name,
                        Value = r.Id.ToString()
                    }
                );
            }
            var model = new RatingCreate();
            model.RestaurantOptions = restaurantOptions;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreate model) {
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