using Common.Entity;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.DAL
{
    public class PackageSendingDbContext : DbContext
    {
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<ShippingOption> ShippingOptions { get; set; }
        public DbSet<ShippingRequest> ShippingRequests { get; set; }

        public PackageSendingDbContext(DbContextOptions<PackageSendingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingRequest>(e =>
            {
                e.OwnsOne(x => x.AddressFrom);
                e.OwnsOne(x => x.AddressTo);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
