using System;
using System.Collections.Generic;

namespace RestaurantReact.RestaurantReact.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Method { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime? PaymentTimeStamp { get; set; }
        public int OrderNumber { get; set; }
        public int LocationId { get; set; }
        public int OrderMainOrderId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual OrderMain OrderMainOrder { get; set; } = null!;
    }
}
