
namespace Collateral.Data.Configurations;

public class CollateralMasterConfigurations : IEntityTypeConfiguration<CollateralMaster>
{
    public void Configure(EntityTypeBuilder<CollateralMaster> builder)
    {
        builder.Property(p => p.Id).HasColumnName("CollatId");
        builder.Property(p => p.CollatType).UseCodeConfig();
    }
}