using System;
using System.Collections.Generic;

namespace RestaurantOderSystemWeb.RestaurantOrderSystemWeb.Models
{
    public partial class MenuCategory
    {
        public MenuCategory()
        {
            Menus = new HashSet<Menu>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string CategoryDescription { get; set; } = null!;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
