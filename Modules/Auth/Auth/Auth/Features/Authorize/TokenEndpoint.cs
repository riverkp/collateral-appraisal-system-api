using System.Security.Claims;
using Auth.Auth.Models;
using Carter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace Auth.Auth.Features.Authorize;

public class TokenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/connect/token", async (HttpContext context) =>
        {
            var request = context.GetOpenIddictServerRequest();
            if (request is null || request.GrantType != GrantTypes.Password)
                return Results.BadRequest("Invalid request");

            var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByNameAsync(request.Username);
            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                return Results.BadRequest("Invalid credentials");

            var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType);
            identity.AddClaim(Claims.Subject, user.Id.ToString());
            identity.AddClaim(Claims.Name, user.UserName);

            foreach (var claim in identity.Claims)
                claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);

            var claimsPrincipal = new ClaimsPrincipal(identity);
            claimsPrincipal.SetScopes(request.GetScopes());
            return Results.SignIn(claimsPrincipal, null, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        });

        app.MapGet("connect/test", async () => { return Results.Ok(); });
    }
}