using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }
    }
}
