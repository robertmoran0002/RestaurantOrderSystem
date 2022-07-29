using System;
using System.Collections.Generic;

namespace RestaurantReact.RestaurantReact.Models
{
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public int RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Location> Locations { get; set; }
    }
}
