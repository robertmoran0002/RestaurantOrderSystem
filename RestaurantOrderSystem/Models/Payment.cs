using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int LocationId { get; set; }
        public string Method { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime? PaymentTimeStamp { get; set; }
        public int OrderNumber { get; set; }

    }
}
