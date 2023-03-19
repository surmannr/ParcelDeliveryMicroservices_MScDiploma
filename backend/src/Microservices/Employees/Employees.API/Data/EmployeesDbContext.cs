using Employees.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employees.API.Data
{
    public class EmployeesDbContext : IdentityDbContext<Employee>
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().OwnsOne(p => p.Address);
        }
    }
}