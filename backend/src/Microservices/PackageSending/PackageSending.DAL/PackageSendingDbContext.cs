using Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace PackageSending.DAL
{
    public class PackageSendingDbContext : DbContext
    {
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
        public virtual DbSet<ShippingOption> ShippingOptions { get; set; }
        public virtual DbSet<ShippingRequest> ShippingRequests { get; set; }

        public PackageSendingDbContext(DbContextOptions<PackageSendingDbContext> options)
            : base(options)
        {
        }

        public PackageSendingDbContext()
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
