using System.ComponentModel.DataAnnotations;

namespace RestaurantRaterMVC.Data
{
    public class RestaurantEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public virtual List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();

        public double AverageFoodScore => Ratings.Count > 0 ?
        Ratings.Select(r => r.FoodScore).Sum() / Ratings.Count : 0;

        public double AverageCleanlinessScore => Ratings.Count > 0 ?
        Ratings.Select(r => r.CleanlinessScore).Sum() / Ratings.Count : 0;

        public double AverageAtmosphereScore => Ratings.Count > 0 ?
        Ratings.Select(r => r.AtmosphereScore).Sum() / Ratings.Count : 0;

        public double Score => 
        (AverageFoodScore + AverageCleanlinessScore + AverageAtmosphereScore) / 3;
    }
}