namespace Request.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Requests.Models.Request>
{
    public void Configure(EntityTypeBuilder<Requests.Models.Request> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("RequestId").UseIdentityColumn();

        builder.Property(p => p.AppraisalNo).HasMaxLength(10);
        builder.Property(p => p.Status).UseCodeConfig();

        builder.OwnsOne(p => p.Detail, detail =>
        {
            detail.ToTable("RequestDetails");
            detail.WithOwner().HasForeignKey("RequestId");
            detail.HasKey("RequestId"); // PK = RequestId

            detail.Property(p => p.Purpose).UseCodeConfig().HasColumnName("Purpose");
            detail.Property(p => p.HasAppraisalBook).HasColumnName("HasAppraisalBook");
            detail.Property(p => p.Priority).UseCodeConfig().HasColumnName("Priority");
            detail.Property(p => p.Channel).UseCodeConfig().HasColumnName("Channel");
            detail.Property(p => p.LoanApplicationNo).HasMaxLength(20).HasColumnName("LoanApplicationNo");
            detail.Property(p => p.LimitAmt).UseMoneyConfig().HasColumnName("LimitAmt");
            detail.Property(p => p.OccurConstInspec).HasColumnName("OccurConstInspec");
            detail.Property(p => p.TotalSellingPrice).UseMoneyConfig().HasColumnName("TotalSellingPrice");

            detail.OwnsOne(p => p.Reference, prevAppraisal =>
            {
                prevAppraisal.Property(p => p.PrevAppraisalNo).HasMaxLength(10).HasColumnName("PrevAppraisalNo");
                prevAppraisal.Property(p => p.PrevAppraisalValue).UseMoneyConfig()
                    .HasColumnName("PrevAppraisalValue");
                prevAppraisal.Property(p => p.PrevAppraisalDate).HasColumnName("PrevAppraisalDate");
            });

            detail.OwnsOne(p => p.Address, address =>
            {
                address.Property(p => p.HouseNo).HasColumnName("HouseNo");
                address.Property(p => p.RoomNo).HasColumnName("RoomNo");
                address.Property(p => p.FloorNo).HasColumnName("FloorNo");
                address.Property(p => p.LocationIdentifier).HasColumnName("LocationIdentifier");
                address.Property(p => p.Moo).HasColumnName("Moo");
                address.Property(p => p.Soi).HasColumnName("Soi");
                address.Property(p => p.Road).HasColumnName("Road");
                address.Property(p => p.SubDistrict).UseCodeConfig().HasColumnName("SubDistrict");
                address.Property(p => p.District).UseCodeConfig().HasColumnName("District");
                address.Property(p => p.Province).UseCodeConfig().HasColumnName("Province");
                address.Property(p => p.Postcode).UseCodeConfig().HasColumnName("Postcode");
            });

            detail.OwnsOne(p => p.Requestor, requestor =>
            {
                requestor.Property(p => p.RequestorEmpId).UseCodeConfig().HasColumnName("RequestorEmpId");
                requestor.Property(p => p.RequestorName).HasColumnName("RequestorName");
                requestor.Property(p => p.RequestorEmail).HasColumnName("RequestorEmail");
                requestor.Property(p => p.RequestorContactNo).HasColumnName("RequestorContactNo");
                requestor.Property(p => p.RequestorAo).UseCodeConfig().HasColumnName("RequestorAo");
                requestor.Property(p => p.RequestorBranch).UseCodeConfig().HasColumnName("RequestorBranch");
                requestor.Property(p => p.RequestorBusinessUnit).UseCodeConfig().HasColumnName("RequestorBusinessUnit");
                requestor.Property(p => p.RequestorDepartment).UseCodeConfig().HasColumnName("RequestorDepartment");
                requestor.Property(p => p.RequestorSection).UseCodeConfig().HasColumnName("RequestorSection");
                requestor.Property(p => p.RequestorCostCenter).UseCodeConfig().HasColumnName("RequestorCostCenter");
            });

            detail.OwnsOne(p => p.Fee, feeInfo =>
            {
                feeInfo.Property(p => p.FeeType).UseCodeConfig().HasColumnName("FeeType");
                feeInfo.Property(p => p.FeeRemark).UseRemarkConfig().HasColumnName("FeeRemark");
            });
        });

        builder.HasMany(p => p.Customers).WithOne().HasForeignKey(p => p.RequestId).OnDelete(DeleteBehavior.Cascade);
    }
}