using System.ComponentModel;
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

        public async Task<IActionResult> Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            await _service.CreateRestaurant(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id) {
            RestaurantDetail restaurant = await _service.GetRestaurantById(id);
            if (restaurant is null) {
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        public async Task<IActionResult> Edit(int id) {
            var restaurant = await _service.GetRestaurantById(id);
            if (restaurant is null) {
                return RedirectToAction(nameof(Index));
            }
            RestaurantEdit restaurantEdit = new RestaurantEdit()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location
            };
            return View(restaurantEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RestaurantEdit model) {
            if (!ModelState.IsValid) return View(ModelState);
            bool hasUpdated = await _service.UpdateRestaurant(model);
            if (!hasUpdated) return View(model);
            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        public async Task<IActionResult> Delete(int id) {
            RestaurantDetail restaurant = await _service.GetRestaurantById(id);
            if (restaurant is null) return RedirectToAction(nameof(Index));
            return View(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, RestaurantDetail model) {
            bool wasDeleted = await _service.DeleteRestaurant(model.Id);
            await _service.DeleteRestaurant(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}