using Microsoft.AspNetCore.Mvc;
using RestaurantRaterMVC.Services;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _service;
        public RestaurantController(IRestaurantService service) {
            _service = service;
        }
    }
}