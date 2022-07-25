using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantOderSystemWeb.RestaurantOrderSystemWeb.Models
{
    public partial class RestaurantDBContext : DbContext
    {
        public RestaurantDBContext()
        {
        }

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public virtual DbSet<OrderMain> OrderMains { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=RestaurantDB;Trusted_Connection=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.RegionId, "IX_Countries_RegionId");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionId);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Locations_CountryId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.HasIndex(e => e.CategoryId, "IX_Menus_CategoryId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
            });

            modelBuilder.Entity<OrderMain>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.ItemId, "IX_OrderMains_ItemId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderMains)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.LocationId, "IX_Payments_LocationId");

                entity.HasIndex(e => e.OrderMainOrderId, "IX_Payments_OrderMainOrderId");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.LocationId);

                entity.HasOne(d => d.OrderMainOrder)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderMainOrderId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
