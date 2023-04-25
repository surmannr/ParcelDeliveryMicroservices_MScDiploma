using Employees.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Employees.API
{
    public class MyClaimTransformation : IClaimsTransformation
    {
        private readonly UserManager<Employee> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public MyClaimTransformation(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;

            var Id = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (Id == null)
            {
                return principal;
            }

            Employee user = new Employee();
            try
            {
                user = await userManager.GetUserAsync(clone);
            }
            catch (Exception)
            {

            }

            if (user == null)
            {
                return principal;
            }

            if (userManager.SupportsUserRole)
            {
                var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
                foreach (var roleName in roles)
                {
                    newIdentity.AddClaim(new Claim(JwtClaimTypes.Role, roleName));
                    if (roleManager.SupportsRoleClaims)
                    {
                        var role = await roleManager.FindByNameAsync(roleName).ConfigureAwait(false);
                        if (role != null)
                        {
                            newIdentity.AddClaims(await roleManager.GetClaimsAsync(role).ConfigureAwait(false));
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(user.NamePrefix))
            {
                newIdentity.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.NamePrefix} {user.LastName} {user.FirstName}"));
            }
            else
            {
                newIdentity.AddClaim(new Claim(JwtClaimTypes.Name, $"{user.LastName} {user.FirstName}"));
            }

            newIdentity.AddClaim(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            newIdentity.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            newIdentity.AddClaim(new Claim(JwtClaimTypes.Email, user.Email));
            newIdentity.AddClaim(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));

            return clone;
        }
    }
}
