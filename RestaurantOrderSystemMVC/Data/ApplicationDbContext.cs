using Microsoft.EntityFrameworkCore;
using RestaurantOrderSystem.Models;

namespace RestaurantOrderSystemMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; } //Property
        public DbSet<Location> Locations { get; set; } //Property
        public DbSet<Menu> Menus { get; set; } //Property
        public DbSet<MenuCategory> MenuCategories { get; set; } //Property
        public DbSet<OrderMain> OrderMains { get; set; } //Property
        public DbSet<Payment> Payments { get; set; } //Property
        public DbSet<Region> Regions { get; set; } //Property

    }
}
