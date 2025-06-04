using Microsoft.AspNetCore.Identity;

namespace Auth.Auth.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public List<RolePermission> Permissions { get; set; } = default!;
}