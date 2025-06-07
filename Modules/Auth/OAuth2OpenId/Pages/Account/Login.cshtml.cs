using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OAuth2OpenId.Identity.Models;

namespace OAuth2OpenId.Pages.Account;

public class Login : PageModel
{
    private readonly ILogger<Login> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public Login(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        ILogger<Login> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    [BindProperty] public string ReturnUrl { get; set; } = "/";

    [BindProperty] public string Error { get; set; } = string.Empty;

    [BindProperty] public string Username { get; set; } = string.Empty;

    [BindProperty] public string Password { get; set; } = string.Empty;

    public void OnGet(string returnUrl = null)
    {
        ReturnUrl = returnUrl ?? "/";
        _logger.LogInformation("Login page loaded with returnUrl: {ReturnUrl}", ReturnUrl);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("OnPostAsync called");
        _logger.LogInformation("Login attempt for user: {Username}", Username);
        _logger.LogInformation("Return URL from form: {ReturnUrl}", ReturnUrl);

        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            _logger.LogWarning("Username or password is empty");
            Error = "Username and password are required.";
            return Page();
        }

        // Validate credentials
        var result = await _signInManager.PasswordSignInAsync(Username, Password, true, false);
        _logger.LogInformation("SignInManager result: {ResultSucceeded}", result.Succeeded);

        if (result.Succeeded)
        {
            _logger.LogInformation("User {Username} logged in successfully", Username);

            // If returnUrl is empty or null, use default "/"
            var redirectUrl = string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl;

            // Make sure the URL is safe to redirect to
            if (!Url.IsLocalUrl(redirectUrl) && !redirectUrl.StartsWith("https://"))
            {
                _logger.LogWarning("Invalid return URL: {ReturnUrl}, redirecting to home", redirectUrl);
                redirectUrl = "/";
            }

            _logger.LogInformation("Redirecting to: {RedirectUrl}", redirectUrl);
            return Redirect(redirectUrl);
        }

        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out: {Username}", Username);
            Error = "Account locked out.";
            return Page();
        }

        Error = "Invalid login attempt.";
        return Page();
    }
}