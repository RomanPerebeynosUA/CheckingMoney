using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
         new List<IdentityResource>
         {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
         };
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource("AuditingMoneyAPI"),
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {

                    // Потрібна інформація для індетнифікації клієнта 
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256())}, 

                    // Отримання токену 
                    AllowedGrantTypes = GrantTypes.ClientCredentials, 

                    // access to some API
                    AllowedScopes = { "AuditingMoneyAPI" }

                },
                      new Client
                {
                    // Потрібна інформація для індетнифікації клієнта 
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256())}, 

                    // Отримання токену 
                    AllowedGrantTypes = GrantTypes.Code,
                 
                    //потрібно змінити відповідно до localhost 
                            RedirectUris = { "https://localhost:44328/signin-oidc" },
                            PostLogoutRedirectUris = { "https://localhost:44328/Home/Index" },

                    AllowedScopes = {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        "AuditingMoneyAPI",
                     },
                    RequireConsent = false,
                   
                     // puts all the claims in the id token     
                  //  AlwaysIncludeUserClaimsInIdToken = true,
                }
            };
        //public static List<TestUser> GetTestUsers()
        //{
        //    return new[] {
        //    new TestUser
        //    {
        //        Username = "admin",
        //        Password = "secret",
        //        Claims = new[]
        //        {
        //            new Claim(ClaimTypes.Name, "Administrator"),
        //            new Claim(ClaimTypes.Role, "Administrator"),
        //            new Claim(ClaimTypes.Email, "admin@test.com"),
        //        },
        //    }
        //}.ToList();
        
    }
}
