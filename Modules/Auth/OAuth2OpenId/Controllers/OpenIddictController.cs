using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using OpenIddict.Server.AspNetCore;

namespace OAuth2OpenId.Controllers;

public class OpenIddictController : Controller
{
    [HttpGet("~/connect/authorize")]
    public async Task<IActionResult> Authorize()
    {
        var request = HttpContext.GetOpenIddictServerRequest();

        if (HttpContext.User.Identity?.IsAuthenticated != true)
            // Not logged in → redirect to log in UI with returnUrl
            return Redirect(
                $"/Account/Login?ReturnUrl={Uri.EscapeDataString(HttpContext.Request.Path + HttpContext.Request.QueryString)}");

        // Auto-approve for demo (or show consent screen)
        var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        identity.AddClaim(OpenIddictConstants.Claims.Subject,
            HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        identity.AddClaim(OpenIddictConstants.Claims.Name, HttpContext.User.Identity.Name);

        // Add destinations for claims
        foreach (var claim in identity.Claims)
            claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken,
                OpenIddictConstants.Destinations.IdentityToken);

        var principal = new ClaimsPrincipal(identity);
        principal.SetScopes(request.GetScopes());

        // Use SignIn method from Controller base class
        return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    [HttpPost("~/connect/token")]
    public async Task<IActionResult> Token()
    {
        var request = HttpContext.GetOpenIddictServerRequest();

        if (request is null)
            return BadRequest(new { error = "Invalid request" });

        if (!request.IsAuthorizationCodeGrantType())
            return BadRequest(new { error = "Unsupported grant_type" });

        // Handle authorization code grant type
        var principal = (await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme))
            .Principal;

        if (principal == null) return BadRequest(new { error = "Invalid authorization code" });

        // Get user info from the principal
        var userId = principal.FindFirstValue(OpenIddictConstants.Claims.Subject);
        var username = principal.FindFirstValue(OpenIddictConstants.Claims.Name);

        var identity = new ClaimsIdentity(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        identity.AddClaim(OpenIddictConstants.Claims.Subject, userId);
        identity.AddClaim(OpenIddictConstants.Claims.Name, username);

        foreach (var claim in identity.Claims)
            claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken,
                OpenIddictConstants.Destinations.IdentityToken);

        var claimsPrincipal = new ClaimsPrincipal(identity);
        claimsPrincipal.SetScopes(request.GetScopes());
        return SignIn(claimsPrincipal, null, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}