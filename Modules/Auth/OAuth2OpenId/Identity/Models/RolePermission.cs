using System;

namespace OAuth2OpenId.Identity.Models;

public class RolePermission
{
    public Guid Id { get; set; }
    public Guid RoleId { get; set; }
    public ApplicationRole Role { get; set; }
    public string PermissionName { get; set; }
}