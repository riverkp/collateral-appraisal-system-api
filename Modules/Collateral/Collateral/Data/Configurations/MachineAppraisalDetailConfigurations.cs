namespace Collateral.Data.Configurations;

public class MachineAppraisalDetailConfigurations : IEntityTypeConfiguration<MachineAppraisalDetail>
{
    public void Configure(EntityTypeBuilder<MachineAppraisalDetail> builder)
    {
        builder.HasOne<CollateralMaster>().WithOne(p => p.MachineAppraisalDetail)
            .HasForeignKey<MachineAppraisalDetail>(p => p.CollatId)
            .IsRequired();

        builder.Property(p => p.Id).HasColumnName("MachineApprID");

        builder.OwnsOne(p => p.AppraisalDetail, machineAppraisalDetail =>
        {
            machineAppraisalDetail.Property(p => p.CanUse).HasColumnName("CanUse");
            machineAppraisalDetail.Property(p => p.Location).HasColumnName("Location")
                .HasMaxLength(200);
            machineAppraisalDetail.Property(p => p.ConditionUse).HasColumnName("ConditionUse")
                .UseNameConfig();
            machineAppraisalDetail.Property(p => p.UsePurpose).HasColumnName("UsePurpose")
                .UseNameConfig();
            machineAppraisalDetail.Property(p => p.Part).HasColumnName("MachinePart");
            machineAppraisalDetail.Property(p => p.Remark).UseRemarkConfig().HasColumnName("Remark");
            machineAppraisalDetail.Property(p => p.Other).HasColumnName("Other");
            machineAppraisalDetail.Property(p => p.AppraiserOpinion).HasColumnName("AppraiserOpinion");        
        });
    }
}