using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrderSystem.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string LocationName { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public string StateProvince { get; set; }
        public long PostalCode { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
