using System.ComponentModel.DataAnnotations;

namespace RestaurantsApi.Models
{
    public class UpdateRestaurantDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Descrption { get; set; }
        public bool HasDelivery { get; set; }
    }
}
