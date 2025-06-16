namespace OAuth2OpenId.Identity.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public List<RolePermission> Permissions { get; set; } = default!;
}