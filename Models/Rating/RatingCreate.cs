using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantRaterMVC.Models.Rating
{
    public class RatingCreate
    {
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        [Range(0,5)]
        public float FoodScore { get; set; }

        [Required]
        [Range(0,5)]
        public float CleanlinessScore { get; set; }

        [Required]
        [Range(0,5)]
        public float AtmosphereScore { get; set; }

        public IEnumerable<SelectListItem> RestaurantOptions {get; set;} = new List<SelectListItem>();
    }
}