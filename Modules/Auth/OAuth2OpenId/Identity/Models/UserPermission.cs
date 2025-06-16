namespace OAuth2OpenId.Identity.Models;

public class UserPermission
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string PermissionName { get; set; }
}