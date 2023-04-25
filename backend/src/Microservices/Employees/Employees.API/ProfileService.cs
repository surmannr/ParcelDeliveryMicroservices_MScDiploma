using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Employees.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Employees.API
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<Employee> userManager;

        public ProfileService(UserManager<Employee> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subject = context.Subject ?? throw new ArgumentNullException(nameof(context.Subject));

            var subjectId = subject.Claims.Where(x => x.Type == "sub").FirstOrDefault()?.Value;

            var user = await userManager.FindByIdAsync(subjectId);
            if (user == null)
                throw new ArgumentException("Invalid subject identifier");

            var claims = await GetClaimsFromUser(user);
            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            
        }

        private async Task<IEnumerable<Claim>> GetClaimsFromUser(Employee user)
        {
            var claims = new List<Claim>();

            if (userManager.SupportsUserRole)
            {
                var roles = await userManager.GetRolesAsync(user).ConfigureAwait(false);
                foreach (var roleName in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, roleName));
                }
            }
            if (!string.IsNullOrEmpty(user.NamePrefix))
            {
                claims.Add(new Claim(JwtClaimTypes.Name, $"{user.NamePrefix} {user.LastName} {user.FirstName}"));
            }
            else
            {
                claims.Add(new Claim(JwtClaimTypes.Name, $"{user.LastName} {user.FirstName}"));
            }

            claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            claims.Add(new Claim(JwtClaimTypes.Email, user.Email));
            claims.Add(new Claim(JwtClaimTypes.PreferredUserName, user.UserName));

            return claims;
        }
    }
}
