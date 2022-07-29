using System;
using System.Collections.Generic;

namespace RestaurantReact.RestaurantReact.Models
{
    public partial class Menu
    {
        public Menu()
        {
            OrderMains = new HashSet<OrderMain>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string Descrption { get; set; } = null!;
        public string? Notes { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual MenuCategory Category { get; set; } = null!;
        public virtual ICollection<OrderMain> OrderMains { get; set; }
    }
}
