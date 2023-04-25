using Employees.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Employees.API
{
    public class MyClaimsPrincipalFactory : UserClaimsPrincipalFactory<Employee, IdentityRole>
    {
        private readonly UserManager<Employee> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IOptions<IdentityOptions> options;

        public MyClaimsPrincipalFactory(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.options = options;
        }

        public override async Task<ClaimsPrincipal> CreateAsync(Employee user)
        {
            var identity = await base.CreateAsync(user);
            var claimsIdentity = (ClaimsIdentity)identity.Identity;
            if (userManager.SupportsUserRole)
            {
                var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
                foreach (var roleName in roles)
                {
                    claimsIdentity.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, roleName));
                    if (roleManager.SupportsRoleClaims)
                    {
                        var role = await roleManager.FindByNameAsync(roleName).ConfigureAwait(false);
                        if (role != null)
                        {
                            claimsIdentity.AddClaims(await roleManager.GetClaimsAsync(role).ConfigureAwait(false));
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(user.NamePrefix))
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.NamePrefix} {user.LastName} {user.FirstName}"));
            }
            else
            {
                claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.LastName} {user.FirstName}"));
            }

            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Email, user.Email));
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));

            return identity;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Employee user)
        {
            var id = await base.GenerateClaimsAsync(user).ConfigureAwait(false);
            if (userManager.SupportsUserRole)
            {
                var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
                foreach (var roleName in roles)
                {
                    id.AddClaim(new Claim(Options.ClaimsIdentity.RoleClaimType, roleName));
                    if (roleManager.SupportsRoleClaims)
                    {
                        var role = await roleManager.FindByNameAsync(roleName).ConfigureAwait(false);
                        if (role != null)
                        {
                            id.AddClaims(await roleManager.GetClaimsAsync(role).ConfigureAwait(false));
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(user.NamePrefix))
            {
                id.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.NamePrefix} {user.LastName} {user.FirstName}"));
            }
            else
            {
                id.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.LastName} {user.FirstName}"));
            }

            id.AddClaim(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            id.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            id.AddClaim(new Claim(JwtClaimTypes.Email, user.Email));
            id.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));

            return id;
        }
    }
}
