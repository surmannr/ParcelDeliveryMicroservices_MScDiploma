using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;
using System.Collections.Generic;

namespace Employees.API
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes(IConfiguration configuration) =>
            new ApiScope[]
            {
                new ApiScope(
                    name: configuration["Identity:ApiScope:ApiScopeName"],
                    displayName: configuration["Identity:ApiScope:ApiScopeDisplayName"],
                    userClaims: new List<string>()
                        {
                                JwtClaimTypes.Name,
                                JwtClaimTypes.Email,
                                JwtClaimTypes.GivenName,
                                JwtClaimTypes.FamilyName,
                                JwtClaimTypes.PreferredUserName
                        }
                    )
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration) =>
            new List<Client>
            {
                new Client
                {
                    ClientId =  configuration["Identity:ClientIds:Swagger"],

                    // Élesbe nem így lenne
                    ClientSecrets = { new Secret("511536ef-f270-4058-80ca-1c89c192f69a".Sha256()) },//TODO ne itt legyen

                    AllowedGrantTypes = GrantTypes.Code,
            
                    // where to redirect to after login
                    RedirectUris = { configuration["Identity:RedirectUris:Swagger"] },

                    // where to redirect to after logout
                    //PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        configuration["ApiScope:ApiScopeName"],
                    },
                    AllowedCorsOrigins =
                    {
                        configuration["Identity:Cors:Swagger"],
                    },
                },
                new Client
                    {
                        ClientId = configuration["Identity:ClientIds:SPA"],
                        RequireClientSecret = false,

                        AllowedGrantTypes = GrantTypes.Code,
                    
                        // where to redirect to after login
                        RedirectUris = 
                        { 
                            configuration["Identity:RedirectUris:SPA:local"],
                            configuration["Identity:RedirectUris:SPA:employee"],
                            configuration["Identity:RedirectUris:SPA:frontend"],
                        },

                        // where to redirect to after logout
                        PostLogoutRedirectUris =
                        {
                            configuration["Identity:PostLogoutRedirectUris:SPA:local"],
                            configuration["Identity:PostLogoutRedirectUris:SPA:employee"],
                            configuration["Identity:PostLogoutRedirectUris:SPA:frontend"],
                        },

                        RequirePkce = true,

                        AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            configuration["ApiScope:ApiScopeName"],
                        },
                        AllowedCorsOrigins = 
                        {
                            configuration["Identity:Cors:SPA:local"],
                            configuration["Identity:Cors:SPA:employee"],
                            configuration["Identity:Cors:SPA:frontend"],
                        },
                    },
                new Client
                {
                    ClientId = configuration["Identity:ClientIds:Flutter"],
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowOfflineAccess = true,

                    RequirePkce = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    
                    // where to redirect to after login
                    RedirectUris = { configuration["Identity:RedirectUris:Flutter"] },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { configuration["Identity:PostLogoutRedirectUris:Flutter"]  },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        configuration["ApiScope:ApiScopeName"],
                    },
                }
            };
    }
}