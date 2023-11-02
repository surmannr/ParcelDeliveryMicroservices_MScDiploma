using Common.Constants;
using Employees.API.Data;
using Employees.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace Employees.API
{
    public class SeedData
    {
        public static void EnsureSeedRoles(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var courierRole = roleMgr.Roles.FirstOrDefault(x => x.Name.Equals(Roles.Courier));
                if (courierRole == null)
                {
                    courierRole = new IdentityRole(Roles.Courier);
                    var result = roleMgr.CreateAsync(courierRole).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
                var officeAssistantRole = roleMgr.Roles.FirstOrDefault(x => x.Name.Equals(Roles.OfficeAssistant));
                if (officeAssistantRole == null)
                {
                    officeAssistantRole = new IdentityRole(Roles.OfficeAssistant);
                    var result = roleMgr.CreateAsync(officeAssistantRole).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }
            }
        }
        public static void EnsureSeedData(WebApplication app)
        {
            EnsureSeedRoles(app);
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<EmployeesDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<Employee>>();

                var alice = userMgr.FindByNameAsync("alice").Result;
                if (alice == null)
                {
                    alice = new Employee
                    {
                        UserName = "alice",
                        Email = "AliceSmith@email.com",
                        EmailConfirmed = true,
                        FirstName = "Alice",
                        LastName = "Smith",
                        NamePrefix = "Dr",
                        BirthDate = DateTime.Now.AddYears(-27),
                    };
                    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    userMgr.AddToRoleAsync(alice, Roles.OfficeAssistant);
                    result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Role, Roles.OfficeAssistant),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("alice created");
                }
                else
                {
                    Log.Debug("alice already exists");
                }

                var bob = userMgr.FindByNameAsync("bob").Result;
                if (bob == null)
                {
                    bob = new Employee
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true,
                        FirstName = "Bob",
                        LastName = "Smith",
                        NamePrefix = "Jr",
                        BirthDate = DateTime.Now.AddYears(-24),
                    };
                    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    userMgr.AddToRoleAsync(alice, Roles.Courier);
                    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Role, Roles.Courier),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("bob created");
                }
                else
                {
                    Log.Debug("bob already exists");
                }
            }
        }
    }
}