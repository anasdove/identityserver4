using CADove.Shared;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace CADove.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(Constant.ApiResource.SCOPE_NAME, Constant.ApiResource.DISPLAY)
            };
        }

        public static IEnumerable<Client> GetClient()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = Constant.Client.CLIENT_ID, // Unique ID of the Client
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret(Constant.Client.SECRET.Sha256()) // Create SHA256 Hash for the secret
                    },
                    AllowedScopes = { Constant.ApiResource.SCOPE_NAME } // Specifies the API Scopes that the client is allowed to request. If empty the client can't access any scope.
                }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = Constant.CAUser.SUBJECT,
                    Username = Constant.CAUser.USERNAME,
                    Password = Constant.CAUser.PASSWORD
                },
                new TestUser
                {
                    SubjectId = Constant.AadilahUser.SUBJECT,
                    Username = Constant.AadilahUser.USERNAME,
                    Password = Constant.AadilahUser.PASSWORD
                }
            };
        }
    }
}
