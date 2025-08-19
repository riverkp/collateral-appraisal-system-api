using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collateral.Data.Migrations
{
    /// <inheritdoc />
    public partial class Debug1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollateralVehicles",
                schema: "collateral",
                columns: table => new
                {
                    VehicleName = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnergyUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true),
                    CountryOfManufacture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_CollateralVehicles", x => x.VehicleName);
                    table.ForeignKey(
                        name: "FK_CollateralVehicles_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralVessels",
                schema: "collateral",
                columns: table => new
                {
                    VesselName = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollatId = table.Column<long>(type: "bigint", nullable: false),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    MachineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnergyUse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EngineNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: true),
                    CountryOfManufacture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
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
                    table.PrimaryKey("PK_CollateralVessels", x => x.VesselName);
                    table.ForeignKey(
                        name: "FK_CollateralVessels_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_MachineAppraisalAdditionalInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_VehicleAppraisalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAppraisalDetails_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselAppraisalDetails",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    table.PrimaryKey("PK_VesselAppraisalDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VesselAppraisalDetails_CollateralMasters_CollatId",
                        column: x => x.CollatId,
                        principalSchema: "collateral",
                        principalTable: "CollateralMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "CollateralVehicles",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "CollateralVessels",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "VehicleAppraisalDetails",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "VesselAppraisalDetails",
                schema: "collateral");
        }
    }
}
