namespace Request.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Requests.Models.Request>
{
    public void Configure(EntityTypeBuilder<Requests.Models.Request> builder)
    {
        builder.HasKey(p => p.Id);

        //builder.HasIndex(p => p.Id).IsUnique();

        builder.Property(p => p.Purpose).HasMaxLength(10);
        builder.Property(p => p.Channel).HasMaxLength(10);

        //builder.HasMany(p => p.Customers).WithOne().HasForeignKey(p => p.RequestId)

    }
}
