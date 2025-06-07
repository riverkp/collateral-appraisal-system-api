using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAuth2OpenId.Identity.Models;

namespace OAuth2OpenId.Data.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasOne(p => p.Role)
            .WithMany(p => p.Permissions)
            .HasForeignKey(p => p.RoleId);
    }
}