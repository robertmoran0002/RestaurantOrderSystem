using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderSystem.Models
{
    public class OrderMain
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateTimePlaced { get; set; }
        public DateTime? DateTimeComplete { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; } = null!;
    }
}
