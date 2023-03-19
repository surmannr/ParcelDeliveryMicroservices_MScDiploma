using Customers.API.Data;
using Customers.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace Customers.API
{
    public class SeedData
    {
        public static void EnsureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<CustomersDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                var alice = userMgr.FindByNameAsync("trevor").Result;
                if (alice == null)
                {
                    alice = new Customer
                    {
                        UserName = "trevor",
                        Email = "TrevorVincenzo@email.com",
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Trevor Vincenzo"),
                            new Claim(JwtClaimTypes.GivenName, "Trevor"),
                            new Claim(JwtClaimTypes.FamilyName, "Vincenzo"),
                            new Claim(JwtClaimTypes.WebSite, "http://trevor.com"),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("trevor created");
                }
                else
                {
                    Log.Debug("trevor already exists");
                }

                var bob = userMgr.FindByNameAsync("megan").Result;
                if (bob == null)
                {
                    bob = new Customer
                    {
                        UserName = "megan",
                        Email = "MeganVincenzo@email.com",
                        EmailConfirmed = true
                    };
                    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Megan Vincenzo"),
                            new Claim(JwtClaimTypes.GivenName, "Megan"),
                            new Claim(JwtClaimTypes.FamilyName, "Vincenzo"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("megan created");
                }
                else
                {
                    Log.Debug("megan already exists");
                }
            }
        }
    }
}