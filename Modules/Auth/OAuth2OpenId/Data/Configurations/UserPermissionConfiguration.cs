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