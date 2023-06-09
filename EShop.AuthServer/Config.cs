﻿using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

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
                    },
                    ApiSecrets = new []{new Secret("secretapi1".Sha256())}
                },
                new ApiResource("resource_api2")
                {
                    Scopes = {
                        "api2.read",
                        "api2.write",
                        "api2.update",
                    },
                    ApiSecrets = new []{new Secret("secretapi2".Sha256())}

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
                    AllowedScopes = {"api1.read","api1.update","api2.write","api2.update"}
                },
                new Client()
                {
                    ClientId = "Client1-MVC",
                    RequirePkce = false,
                    ClientName = "Client1 MVC Web App",
                    ClientSecrets = new [] {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>{"https://localhost:7062/signin-oidc"},
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, "api1.read"}
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId = "1",
                    Username = "uyarbtrlp",
                    Password = "password",
                    Claims = new List<Claim>()
                    {
                        new Claim("given_name","Baturalp"),
                        new Claim("family_name","Uyar"),
                    }
                },
                                new TestUser()
                {
                    SubjectId = "2",
                    Username = "testuser",
                    Password = "password2",
                    Claims = new List<Claim>()
                    {
                        new Claim("given_name","Test"),
                        new Claim("family_name","User"),
                    }
                }
            };
        }


    }
}
