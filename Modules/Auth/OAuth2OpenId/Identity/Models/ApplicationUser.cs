using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OAuth2OpenId.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public List<UserPermission> Permissions { get; set; } = default!;
}