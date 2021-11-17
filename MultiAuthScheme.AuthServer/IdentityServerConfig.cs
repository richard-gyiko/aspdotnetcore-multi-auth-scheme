using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiAuthScheme.AuthServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("resouce-server", "Resource server full access")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "postman",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = { "resouce-server" }
                }
            };
    }
}
