using System;
using System.Collections.Generic;

namespace RestaurantOderSystemWeb.RestaurantOrderSystemWeb.Models
{
    public partial class Location
    {
        public Location()
        {
            Payments = new HashSet<Payment>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int City { get; set; }
        public string StateProvince { get; set; } = null!;
        public long PostalCode { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
