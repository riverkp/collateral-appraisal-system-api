using System.Security.Claims;
using Carter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace Auth.Auth.Features.Authorize;

public class AuthorizeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/connect/authorize", async (HttpContext context) =>
        {
            var request = context.GetOpenIddictServerRequest();

            if (context.User.Identity?.IsAuthenticated != true)
                // Not logged in → redirect to login UI with returnUrl
                return Results.Redirect(
                    $"/account/login?returnUrl={context.Request.Path + context.Request.QueryString}");

            // Auto-approve for demo (or show consent screen)
            var identity = new ClaimsIdentity(TokenValidationParameters.DefaultAuthenticationType);
            identity.AddClaim(OpenIddictConstants.Claims.Subject,
                context.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            identity.AddClaim(OpenIddictConstants.Claims.Name, context.User.Identity.Name);

            // Add destinations for claims
            foreach (var claim in identity.Claims)
                claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken,
                    OpenIddictConstants.Destinations.IdentityToken);

            var principal = new ClaimsPrincipal(identity);
            principal.SetScopes(request.GetScopes());
            return Results.SignIn(principal, null, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        });
    }
}