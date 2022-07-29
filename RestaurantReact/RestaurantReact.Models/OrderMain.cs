using System;
using System.Collections.Generic;

namespace RestaurantReact.RestaurantReact.Models
{
    public partial class OrderMain
    {
        public OrderMain()
        {
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateTimePlaced { get; set; }
        public DateTime? DateTimeComplete { get; set; }
        public int OrderNumber { get; set; }
        public string OrderStatus { get; set; } = null!;

        public virtual Menu Item { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
