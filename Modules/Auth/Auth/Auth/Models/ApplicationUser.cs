using Microsoft.AspNetCore.Identity;

namespace Auth.Auth.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public List<UserPermission> Permissions { get; set; } = default!;
}