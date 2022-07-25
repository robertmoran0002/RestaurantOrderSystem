using System.ComponentModel.DataAnnotations;

namespace RestaurantOrderSystem.Models
{
    public class MenuCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = null!;
        public string CategoryDescription { get; set; } = null!;
    }
}
