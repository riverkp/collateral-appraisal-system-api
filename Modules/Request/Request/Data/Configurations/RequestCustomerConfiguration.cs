namespace Request.Data.Configurations;

public class RequestCustomerConfiguration : IEntityTypeConfiguration<RequestCustomer>
{
    public void Configure(EntityTypeBuilder<RequestCustomer> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn();

        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.ContactNumber).HasMaxLength(20);
    }
}