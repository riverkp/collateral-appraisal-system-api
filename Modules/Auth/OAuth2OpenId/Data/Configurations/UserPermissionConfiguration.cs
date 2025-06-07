using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OAuth2OpenId.Identity.Models;

namespace OAuth2OpenId.Data.Configurations;

public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.HasOne(p => p.User)
            .WithMany(p => p.Permissions)
            .HasForeignKey(p => p.UserId);
    }
}