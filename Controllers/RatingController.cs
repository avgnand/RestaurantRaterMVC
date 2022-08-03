using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services.Rating;

namespace RestaurantRaterMVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IRatingService _service;

        public RatingController(IRatingService service) {
            _service = service;
        }

        public async Task<IActionResult> Index() {
            var ratings = await _service.GetAllRatings();
            return View(ratings);
        }
    }
}