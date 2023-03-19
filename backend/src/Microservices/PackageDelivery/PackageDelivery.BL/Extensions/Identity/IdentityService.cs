using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Extensions.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpContext httpContext;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        public string GetCurrentUserId()
        {
            return httpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)?.Value ?? throw new UnauthorizedAccessException("A művelethez be kell jelentkezni.");
        }
    }
}
