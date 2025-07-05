
namespace Request.Data.Configurations;

public class RequestCommentConfiguration : IEntityTypeConfiguration<RequestComment>
{
    public void Configure(EntityTypeBuilder<RequestComment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("CommentId").UseIdentityColumn();

        builder.Property(p => p.Comment).HasMaxLength(250);
    }
}