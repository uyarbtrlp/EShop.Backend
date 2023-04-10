using IdentityServer4.Models;

namespace EShop.AuthServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("resource_api1")
                {
                    Scopes = {
                        "api1.read",
                        "api1.write",
                        "api1.update",
                    }
                },
                new ApiResource("resource_api2")
                {
                    Scopes = {
                        "api2.read",
                        "api2.write",
                        "api2.update",
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","read permission for api1"),
                new ApiScope("api1.write","write permission for api1"),
                new ApiScope("api1.update","update permission for api1"),
                new ApiScope("api2.read","read permission for api2"),
                new ApiScope("api2.write","write permission for api2"),
                new ApiScope("api2.update","update permission for api2"),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "Client1",
                    ClientName = "Client 1 Web App",
                    ClientSecrets = new [] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api1.read"}
                },
                new Client()
                {
                    ClientId = "Client2",
                    ClientName = "Client 2 Web App",
                    ClientSecrets = new [] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"api1.read","api2.write","api2.update"}
                }
            };
        }


    }
}
