using Customers.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Customers.API.Data
{
    public class CustomersDbContext : IdentityDbContext<Customer>
    {
        public CustomersDbContext(DbContextOptions<CustomersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>().OwnsOne(p => p.Address);
        }
    }
}