using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        [ValidateNever]
        public MenuCategory Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"id: {ItemId}\t\tName: {Name}\t\t Description: {Descrption}\t\tNotes: {Notes}\t\tCategoryId: {CategoryId}\t\tPrice: {Price}";
        }
    }
}
