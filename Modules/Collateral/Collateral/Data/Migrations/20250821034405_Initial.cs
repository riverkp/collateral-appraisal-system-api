using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collateral.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "collateral");

            migrationBuilder.CreateTable(
                name: "BuildingAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    BuildingApprId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    NoHouseNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LandArea = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    BuildingCondition = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BuildingStatus = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    LicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAppraise = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsObligation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Obligation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    BuildingTypeOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decoration = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    DecorationOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEncroached = table.Column<bool>(type: "bit", nullable: true),
                    IsEncroachedRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncroachArea = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    OriginalBuildingPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    UnderConstPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    BuildingMaterial = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BuildingStyle = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    IsResidential = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BuildingYear = table.Column<short>(type: "smallint", nullable: true),
                    DueTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstStyle = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ConstStyleRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralStructure = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GeneralStructureOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoofFrame = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoofFrameOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roof = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoofOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ceiling = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CeilingOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InteriorWall = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InteriorWallOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExteriorWall = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExteriorWallOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fence = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FenceOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConstType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ConstTypeOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Utilization = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    UseForOtherPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAppraisalDetails", x => x.BuildingApprId);
                });

            migrationBuilder.CreateTable(
                name: "CollateralMasters",
                schema: "collateral",
                columns: table => new
                {
                    CollatId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    HostCollatId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralMasters", x => x.CollatId);
                });

            migrationBuilder.CreateTable(
                name: "CondoAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    CondoApprId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    IsObligation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Obligation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocValidate = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    CondoLocation = table.Column<bool>(type: "bit", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Soi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RoadWidth = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RightOfWay = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RoadSurface = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    PublicUtility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublicUtilityOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Decoration = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BuildingYear = table.Column<int>(type: "int", nullable: true),
                    CondoHeight = table.Column<int>(type: "int", nullable: false),
                    BuildingForm = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ConstMaterial = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    RoomLayout = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    RoomLayoutOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroundFloorMaterial = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    GroundFloorMaterialOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpperFloorMaterial = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    UpperFloorMaterialOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BathroomFloorMaterial = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BathroomFloorMaterialOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Roof = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    RoofOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAreaInSqM = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    IsExpropriate = table.Column<bool>(type: "bit", nullable: true),
                    IsExpropriateRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InLineExpropriate = table.Column<bool>(type: "bit", nullable: true),
                    InLineExpropriateRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoyalDecree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CondoFacility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CondoFacilityOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingInsurancePrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    ForceSellingPrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    IsForestBoundary = table.Column<bool>(type: "bit", nullable: true),
                    IsForestBoundaryRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondoAppraisalDetails", x => x.CondoApprId);
                });

            migrationBuilder.CreateTable(
                name: "LandAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    LandApprId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CheckOwner = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsObligation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Obligation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandLocation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    LandCheck = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    LandCheckOther = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Distance = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Village = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandFill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandFillPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    SoilLevel = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RoadWidth = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RightOfWay = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    LandAccessibility = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    LandAccessibilityDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoadSurface = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    RoadSurfaceOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicUtility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PublicUtilityOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandUse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandUseOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandEntranceExit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LandEntranceExitOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transportation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TransportationOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnticipationOfProp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsExpropriate = table.Column<bool>(type: "bit", nullable: true),
                    IsExpropriateRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InLineExpropriate = table.Column<bool>(type: "bit", nullable: true),
                    InLineExpropriateRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoyalDecree = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsEncroached = table.Column<bool>(type: "bit", nullable: true),
                    IsEncroachedRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncroachArea = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Electricity = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ElectricityDistance = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    IsLandlocked = table.Column<bool>(type: "bit", nullable: true),
                    IsLandlockedRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForestBoundary = table.Column<bool>(type: "bit", nullable: true),
                    IsForestBoundaryRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LimitationOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eviction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Allocation = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    N_ConsecutiveArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    N_EstimateLength = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    S_ConsecutiveArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    S_EstimateLength = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    E_ConsecutiveArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    E_EstimateLength = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    W_ConsecutiveArea = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    W_EstimateLength = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    PondArea = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    DepthPit = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    HasBuilding = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    HasBuildingOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandAppraisalDetails", x => x.LandApprId);
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "collateral",
                columns: table => new
                {
                    MachDetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprCollatPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprCollatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industrial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SurveyNo = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    ApprNo = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Installed = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    ApprScrap = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    NoOfAppraise = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    NotInstalled = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Maintenance = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Exterior = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Performance = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MarketDemand = table.Column<bool>(type: "bit", nullable: true),
                    MarketDemandRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proprietor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MachineLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Obligation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Other = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAppraisalAdditionalInfos", x => x.MachDetId);
                });

            migrationBuilder.CreateTable(
                name: "BuildingAppraisalDepreciationDetails",
                schema: "collateral",
                columns: table => new
                {
                    BuildingDepreciationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(5,3)", precision: 5, scale: 3, nullable: false),
                    PricePerSqM = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PriceBeforeDegradation = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    DegradationYearPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TotalDegradationPct = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    PriceDegradation = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    AppraisalMethod = table.Column<bool>(type: "bit", nullable: true),
                    BuildingApprId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAppraisalDepreciationDetails", x => x.BuildingDepreciationId);
                    table.ForeignKey(
                        name: "FK_BuildingAppraisalDepreciationDetails_BuildingAppraisalDetails_BuildingApprId",
                        column: x => x.BuildingApprId,
                        principalSchema: "collateral",
                        principalTable: "BuildingAppraisalDetails",
                        principalColumn: "BuildingApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingAppraisalSurfaces",
                schema: "collateral",
                columns: table => new
                {
                    SurfaceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromFloorNo = table.Column<short>(type: "smallint", nullable: true),
                    ToFloorNo = table.Column<short>(type: "smallint", nullable: true),
                    FloorType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FloorStructure = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FloorStructureOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorSurface = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    FloorSurfaceOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingApprId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAppraisalSurfaces", x => x.SurfaceId);
                    table.ForeignKey(
                        name: "FK_BuildingAppraisalSurfaces_BuildingAppraisalDetails_BuildingApprId",
                        column: x => x.BuildingApprId,
                        principalSchema: "collateral",
                        principalTable: "BuildingAppraisalDetails",
                        principalColumn: "BuildingApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralBuildings",
                schema: "collateral",
                columns: table => new
                {
                    BuildingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BuiltOnTitleNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralBuildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_CollateralBuildings_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralCondos",
                schema: "collateral",
                columns: table => new
                {
                    CondoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    CondoName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BuildingNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BuiltOnTitleNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CondoRegisNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoomNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FloorNo = table.Column<int>(type: "int", nullable: false),
                    UsableArea = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    SubDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LandOffice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralCondos", x => x.CondoId);
                    table.ForeignKey(
                        name: "FK_CollateralCondos_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralLands",
                schema: "collateral",
                columns: table => new
                {
                    LandId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: false),
                    SubDistrict = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LandOffice = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LandDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralLands", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_CollateralLands_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralMachines",
                schema: "collateral",
                columns: table => new
                {
                    MachineId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnergyUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true),
                    CountryOfManufacture = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Length = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Height = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralMachines", x => x.MachineId);
                    table.ForeignKey(
                        name: "FK_CollateralMachines_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralVehicles",
                schema: "collateral",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnergyUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true),
                    CountryOfManufacture = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Length = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Height = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralVehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_CollateralVehicles_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralVessels",
                schema: "collateral",
                columns: table => new
                {
                    VesselId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    VesselName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnergyUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true),
                    CountryOfManufacture = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Width = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Length = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    Height = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralVessels", x => x.VesselId);
                    table.ForeignKey(
                        name: "FK_CollateralVessels_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LandTitles",
                schema: "collateral",
                columns: table => new
                {
                    LandTitleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    SeqNo = table.Column<int>(type: "int", nullable: false),
                    TitleNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BookNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PageNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LandNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SurveyNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SheetNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Rai = table.Column<decimal>(type: "decimal(3,0)", precision: 3, scale: 0, nullable: true),
                    Ngan = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    Wa = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    TotalAreaInSqWa = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    DocumentType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Rawang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AerialPhotoNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BoundaryMarker = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    BoundaryMarkerOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocValidate = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PricePerSquareWa = table.Column<decimal>(type: "decimal(10,4)", precision: 10, scale: 4, nullable: true),
                    GovernmentPrice = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandTitles", x => x.LandTitleId);
                    table.ForeignKey(
                        name: "FK_LandTitles_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    MachineApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    CanUse = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConditionUse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsePurpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MachinePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppraiserOpinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAppraisalDetails", x => x.MachineApprID);
                    table.ForeignKey(
                        name: "FK_MachineAppraisalDetails_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    VehicleApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    CanUse = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConditionUse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsePurpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VehiclePart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppraiserOpinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAppraisalDetails", x => x.VehicleApprID);
                    table.ForeignKey(
                        name: "FK_VehicleAppraisalDetails_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    VesselApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    CanUse = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConditionUse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UsePurpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    VesselPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppraiserOpinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselAppraisalDetails", x => x.VesselApprID);
                    table.ForeignKey(
                        name: "FK_VesselAppraisalDetails_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "CollatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CondoAppraisalAreaDetails",
                schema: "collateral",
                columns: table => new
                {
                    CondoAreaDetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaSize = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    CondoApprId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondoAppraisalAreaDetails", x => x.CondoAreaDetId);
                    table.ForeignKey(
                        name: "FK_CondoAppraisalAreaDetails_CondoAppraisalDetails_CondoApprId",
                        column: x => x.CondoApprId,
                        principalSchema: "collateral",
                        principalTable: "CondoAppraisalDetails",
                        principalColumn: "CondoApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingAppraisalDepreciationPeriods",
                schema: "collateral",
                columns: table => new
                {
                    BuildingDpcPeriodId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtYear = table.Column<int>(type: "int", nullable: false),
                    DepreciationPerYear = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: false),
                    BuildingDepreciationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAppraisalDepreciationPeriods", x => x.BuildingDpcPeriodId);
                    table.ForeignKey(
                        name: "FK_BuildingAppraisalDepreciationPeriods_BuildingAppraisalDepreciationDetails_BuildingDepreciationId",
                        column: x => x.BuildingDepreciationId,
                        principalSchema: "collateral",
                        principalTable: "BuildingAppraisalDepreciationDetails",
                        principalColumn: "BuildingDepreciationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAppraisalDepreciationDetails_BuildingApprId",
                schema: "collateral",
                table: "BuildingAppraisalDepreciationDetails",
                column: "BuildingApprId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAppraisalDepreciationPeriods_BuildingDepreciationId",
                schema: "collateral",
                table: "BuildingAppraisalDepreciationPeriods",
                column: "BuildingDepreciationId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingAppraisalSurfaces_BuildingApprId",
                schema: "collateral",
                table: "BuildingAppraisalSurfaces",
                column: "BuildingApprId");

            migrationBuilder.CreateIndex(
                name: "IX_CollateralBuildings_CollatId",
                schema: "collateral",
                table: "CollateralBuildings",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollateralCondos_CollatId",
                schema: "collateral",
                table: "CollateralCondos",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollateralLands_CollatId",
                schema: "collateral",
                table: "CollateralLands",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollateralMachines_CollatId",
                schema: "collateral",
                table: "CollateralMachines",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollateralVehicles_CollatId",
                schema: "collateral",
                table: "CollateralVehicles",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollateralVessels_CollatId",
                schema: "collateral",
                table: "CollateralVessels",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CondoAppraisalAreaDetails_CondoApprId",
                schema: "collateral",
                table: "CondoAppraisalAreaDetails",
                column: "CondoApprId");

            migrationBuilder.CreateIndex(
                name: "IX_LandTitles_CollatId",
                schema: "collateral",
                table: "LandTitles",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineAppraisalDetails_CollatId",
                schema: "collateral",
                table: "MachineAppraisalDetails",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAppraisalDetails_CollatId",
                schema: "collateral",
                table: "VehicleAppraisalDetails",
                column: "CollatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VesselAppraisalDetails_CollatId",
                schema: "collateral",
                table: "VesselAppraisalDetails",
                column: "CollatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingAppraisalDepreciationPeriods",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "BuildingAppraisalSurfaces",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralBuildings",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralCondos",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralLands",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralMachines",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralVehicles",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralVessels",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CondoAppraisalAreaDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "LandAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "LandTitles",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "MachineAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "VehicleAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "VesselAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "BuildingAppraisalDepreciationDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CondoAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralMasters",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "BuildingAppraisalDetails",
                schema: "collateral");
        }
    }
}
