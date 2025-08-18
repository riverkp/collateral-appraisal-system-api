using Collateral.CollateralProperties.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collateral.Data.Configurations;

public class LandAppraisalDetailConfiguration : IEntityTypeConfiguration<LandAppraisalDetail>
{
    public void Configure(EntityTypeBuilder<LandAppraisalDetail> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).UseIdentityColumn().HasColumnName("LandApprID");

        builder.Property(p => p.CollatId).HasColumnName("CollatID");

        builder.OwnsOne(
            p => p.ObligationDetail,
            detail =>
            {
                detail.Property(p => p.IsObligation).UseCodeConfig().HasColumnName("IsObligation");

                detail
                    .Property(p => p.Obligation)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("Obligation");
            }
        );

        builder.OwnsOne(
            p => p.LandLocationDetail,
            location =>
            {
                location
                    .Property(p => p.LandLocation)
                    .UseCodeConfig()
                    .HasColumnName("LandLocation");

                location.Property(p => p.LandCheck).UseCodeConfig().HasColumnName("LandCheck");

                location
                    .Property(p => p.LandCheckOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("LandCheckOther");

                location.Property(p => p.Street).UseMediumStringConfig().HasColumnName("Street");

                location.Property(p => p.Soi).UseMediumStringConfig().HasColumnName("Soi");

                location.Property(p => p.Distance).UseMeasurementConfig().HasColumnName("Distance");

                location.Property(p => p.Village).UseLongStringConfig().HasColumnName("Village");

                location.Property(p => p.Location).UseMultiSelectConfig().HasColumnName("Location");
            }
        );

        builder.OwnsOne(
            p => p.LandFillDetail,
            fill =>
            {
                fill.Property(p => p.LandFill).UseMultiSelectConfig().HasColumnName("LandFill");

                fill.Property(p => p.LandFillPct)
                    .UseMeasurementConfig()
                    .HasColumnName("LandFillPct");

                fill.Property(p => p.SoilLevel).UseMeasurementConfig().HasColumnName("SoilLevel");
            }
        );

        builder.OwnsOne(
            p => p.LandAccessibilityDetail,
            detail =>
            {
                detail.OwnsOne(
                    p => p.FrontageRoad,
                    road =>
                    {
                        road.Property(p => p.RoadWidth)
                            .UseMeasurementConfig()
                            .HasColumnName("RoadWidth");

                        road.Property(p => p.RightOfWay)
                            .UseMeasurementConfig()
                            .HasColumnName("RightOfWay");

                        road.Property(p => p.LandAccessibility)
                            .UseCodeConfig()
                            .HasColumnName("LandAccessibility");

                        road.Property(p => p.LandAccessibilityDesc)
                            .UseMaxLengthNVarcharConfig()
                            .HasColumnName("LandAccessibilityDesc");
                    }
                );

                detail.Property(p => p.RoadSurface).UseCodeConfig().HasColumnName("RoadSurface");

                detail
                    .Property(p => p.RoadSurfaceOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("RoadSurfaceOther");

                detail
                    .Property(p => p.PublicUtility)
                    .UseMultiSelectConfig()
                    .HasColumnName("PublicUtility");

                detail
                    .Property(p => p.PublicUtilityOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("PublicUtilityOther");

                detail.Property(p => p.LandUse).UseMultiSelectConfig().HasColumnName("LandUse");

                detail
                    .Property(p => p.LandUseOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("LandUseOther");

                detail
                    .Property(p => p.LandEntranceExit)
                    .UseMultiSelectConfig()
                    .HasColumnName("LandEntranceExit");

                detail
                    .Property(p => p.LandEntranceExitOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("LandEntranceExitOther");

                detail
                    .Property(p => p.Transportation)
                    .UseMultiSelectConfig()
                    .HasColumnName("Transportation");

                detail
                    .Property(p => p.TransportationOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("TransportationOther");
            }
        );

        builder.Property(p => p.AnticipationOfProp).UseMultiSelectConfig();

        builder.OwnsOne(
            p => p.LandLimitation,
            limitation =>
            {
                limitation.OwnsOne(
                    p => p.Expropriation,
                    expropriation =>
                    {
                        expropriation.Property(p => p.IsExpropriate).HasColumnName("IsExpropriate");

                        expropriation
                            .Property(p => p.IsExpropriateRemark)
                            .UseMaxLengthNVarcharConfig()
                            .HasColumnName("IsExpropriateRemark");

                        expropriation
                            .Property(p => p.InLineExpropriate)
                            .HasColumnName("InLineExpropriate");

                        expropriation
                            .Property(p => p.InLineExpropriatemark)
                            .UseMaxLengthNVarcharConfig()
                            .HasColumnName("InLineExpropriatemark");

                        expropriation
                            .Property(p => p.RoyalDecree)
                            .UseVeryShortStringConfig()
                            .HasColumnName("RoyalDecree");
                    }
                );

                limitation.OwnsOne(
                    p => p.Encroachment,
                    encroachment =>
                    {
                        encroachment.Property(p => p.IsEncroached).HasColumnName("IsEncroached");

                        encroachment
                            .Property(p => p.IsEncroachedRemark)
                            .UseMaxLengthNVarcharConfig()
                            .HasColumnName("IsEncroachedRemark");

                        encroachment
                            .Property(p => p.EncroachArea)
                            .UseMeasurementConfig()
                            .HasColumnName("EncroachArea");
                    }
                );

                limitation
                    .Property(p => p.Electricity)
                    .UseCodeConfig()
                    .HasColumnName("Electricity");

                limitation
                    .Property(p => p.ElectricityDistance)
                    .UseMeasurementConfig()
                    .HasColumnName("ElectricityDistance");

                limitation.Property(p => p.IsLandlocked).HasColumnName("IsLandlocked");

                limitation
                    .Property(p => p.IsLandlockedRemark)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("IsLandlockedRemark");

                limitation.OwnsOne(
                    p => p.ForestBoundary,
                    boundary =>
                    {
                        boundary
                            .Property(p => p.IsForestBoundary)
                            .HasColumnName("IsForestBoundary");

                        boundary
                            .Property(p => p.IsForestBoundaryRemark)
                            .UseMaxLengthNVarcharConfig()
                            .HasColumnName("IsForestBoundaryRemark");
                    }
                );

                limitation
                    .Property(p => p.LimitationOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("LimitationOther");
            }
        );

        builder.Property(p => p.Eviction).UseMultiSelectConfig();

        builder.Property(p => p.Allocation).UseCodeConfig();

        builder.OwnsOne(
            p => p.ConsecutiveArea,
            area =>
            {
                area.Property(p => p.NConsecutiveArea)
                    .UseLongerStringConfig()
                    .HasColumnName("N_ConsecutiveArea");

                area.Property(p => p.NEstimateLength)
                    .UseMeasurementConfig()
                    .HasColumnName("N_EstimateLength");

                area.Property(p => p.SConsecutiveArea)
                    .UseLongerStringConfig()
                    .HasColumnName("S_ConsecutiveArea");

                area.Property(p => p.SEstimateLength)
                    .UseMeasurementConfig()
                    .HasColumnName("S_EstimateLength");

                area.Property(p => p.EConsecutiveArea)
                    .UseLongerStringConfig()
                    .HasColumnName("E_ConsecutiveArea");

                area.Property(p => p.EEstimateLength)
                    .UseMeasurementConfig()
                    .HasColumnName("E_EstimateLength");

                area.Property(p => p.WConsecutiveArea)
                    .UseLongerStringConfig()
                    .HasColumnName("W_ConsecutiveArea");

                area.Property(p => p.WEstimateLength)
                    .UseMeasurementConfig()
                    .HasColumnName("W_EstimateLength");
            }
        );

        builder.OwnsOne(
            p => p.LandMiscellaneousDetail,
            detail =>
            {
                detail.Property(p => p.PondArea).UseMeasurementConfig().HasColumnName("PondArea");

                detail.Property(p => p.DepthPit).UseMeasurementConfig().HasColumnName("DepthPit");

                detail.Property(p => p.HasBuilding).UseCodeConfig().HasColumnName("HasBuilding");

                detail
                    .Property(p => p.HasBuildingOther)
                    .UseMaxLengthNVarcharConfig()
                    .HasColumnName("HasBuildingOther");
            }
        );
    }
}
