using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderSystem.Models
{
    public class Menu
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Descrption { get; set; } = null!;
        public string? Notes { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public MenuCategory Category { get; set; }
        public decimal Price { get; set; }
    }
}
