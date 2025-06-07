using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OAuth2OpenId.Identity.Models;
using OpenIddict.Abstractions;
using Shared.Data.Seed;

namespace OAuth2OpenId.Data.Seed;

public class AuthDataSeed(UserManager<ApplicationUser> userManager, IOpenIddictApplicationManager manager) : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if (await userManager.FindByNameAsync("admin") is null)
        {
            var admin = new ApplicationUser { UserName = "admin" };
            await userManager.CreateAsync(admin, "P@ssw0rd!");
        }

        if (await manager.FindByClientIdAsync("spa") is null)
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "spa",
                //ClientSecret = "P@ssw0rd",
                DisplayName = "SPA",
                ClientType = OpenIddictConstants.ClientTypes.Public,
                PostLogoutRedirectUris = { new Uri("https://localhost:7111/") },
                RedirectUris =
                {
                    new Uri("https://localhost:7111/callback"),
                    new Uri("https://www.google.com/"),
                    new Uri("https://localhost:3000/callback")
                },
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Authorization,
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.Password,
                    OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                    OpenIddictConstants.Permissions.ResponseTypes.Code,
                    OpenIddictConstants.Permissions.Scopes.Email,
                    OpenIddictConstants.Permissions.Scopes.Profile,
                    OpenIddictConstants.Permissions.Scopes.Roles
                },
                Requirements =
                {
                    OpenIddictConstants.Requirements.Features.ProofKeyForCodeExchange // ✅ PKCE required
                }
            });
    }
}