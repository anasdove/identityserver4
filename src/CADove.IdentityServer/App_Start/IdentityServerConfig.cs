using CADove.Shared;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CADove.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(Constant.ApiResource.NAME, Constant.ApiResource.DISPLAY)
            };
        }

        public static IEnumerable<Client> GetClient()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = Constant.Client.CLIENT_ID, // Unique ID of the Client
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(Constant.Client.SECRET.Sha256()) // Create SHA256 Hash for the secret
                    },
                    AllowedScopes = { Constant.ApiResource.NAME } // Specifies the API Scopes that the client is allowed to request. If empty the client can't access any scope.
                }
            };
        }
    }
}
