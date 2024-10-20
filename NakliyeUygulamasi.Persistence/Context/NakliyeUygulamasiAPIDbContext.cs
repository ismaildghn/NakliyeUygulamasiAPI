using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Domain.Entities;
using NakliyeUygulamasi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Context
{
    public class NakliyeUygulamasiAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public NakliyeUygulamasiAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighbourhood> Neighbourhoods { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            builder.Entity<Customer>()
                .HasOne(c => c.AppUser)
                .WithOne(au => au.Customer)
                .HasForeignKey<Customer>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Transporter>()
                .HasOne(t => t.AppUser)
                .WithOne(au => au.Transporter)
                .HasForeignKey<Transporter>(t => t.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Transporter>()
                .HasMany(t => t.Offers)
                .WithOne(o => o.Transporter)
                .HasForeignKey(o => o.TransporterId);

            builder.Entity<District>()
                .HasMany(d => d.Neighbourhoods)
                .WithOne(n => n.District)
                .HasForeignKey(n => n.DistrictId);

            builder.Entity<Province>()
                .HasMany(p => p.Districts)
                .WithOne(d => d.Province)
                .HasForeignKey(d => d.ProvinceId);

            builder.Entity<Address>()
                .HasOne(a => a.Province)
                .WithMany()
                .HasForeignKey(a => a.ProvinceId);

            builder.Entity<Address>()
                .HasOne(a => a.District)
                .WithMany()
                .HasForeignKey(a => a.DistrictId);

            builder.Entity<Address>()
                .HasOne(a => a.Neighbourhood)
                .WithMany()
                .HasForeignKey(a => a.NeighbourhoodId);

            builder.Entity<Order>()
                .HasMany(or => or.Offers)
                .WithOne(of => of.Order)
                .HasForeignKey(of => of.OrderId);

            builder.Entity<Order>()
                .HasOne(o => o.DeliveryAddress)
                .WithMany()
                .HasForeignKey(o => o.DeliveryAddressId);

            builder.Entity<Order>()
                .HasOne(o => o.PickupAddress)
                .WithMany()
                .HasForeignKey(o => o.PickupAddressId);

            base.OnModelCreating(builder);
              
        }
    }
}
