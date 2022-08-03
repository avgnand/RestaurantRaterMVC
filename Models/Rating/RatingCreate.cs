using System.ComponentModel.DataAnnotations;

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
    }
}