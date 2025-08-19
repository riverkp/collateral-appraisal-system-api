using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collateral.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCollateralMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollateralType",
                schema: "collateral",
                table: "CollateralMasters");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "collateral",
                table: "CollateralMasters",
                newName: "CollatType");

            migrationBuilder.AddColumn<long>(
                name: "HostCollatID",
                schema: "collateral",
                table: "CollateralMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "collateralMachines",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfManufacture = table.Column<int>(type: "int", nullable: false),
                    CountryOfManufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnergyUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collateralMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalAdditionalInfo",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprCollatPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprCollatType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industrial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyNo = table.Column<int>(type: "int", nullable: false),
                    ApprNo = table.Column<int>(type: "int", nullable: false),
                    Installed = table.Column<int>(type: "int", nullable: false),
                    ApprScrap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfAppraise = table.Column<int>(type: "int", nullable: false),
                    NotInstalled = table.Column<int>(type: "int", nullable: false),
                    Maintenance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketDemand = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MarketDemandRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proprietor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obligation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollateralMachineId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAppraisalAdditionalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAppraisalAdditionalInfo_collateralMachines_CollateralMachineId",
                        column: x => x.CollateralMachineId,
                        principalSchema: "collateral",
                        principalTable: "collateralMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalDetail",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsePurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachinePart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppraiserOpinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollateralMachineId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAppraisalDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAppraisalDetail_collateralMachines_CollateralMachineId",
                        column: x => x.CollateralMachineId,
                        principalSchema: "collateral",
                        principalTable: "collateralMachines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineAppraisalAdditionalInfo_CollateralMachineId",
                schema: "collateral",
                table: "MachineAppraisalAdditionalInfo",
                column: "CollateralMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAppraisalDetail_CollateralMachineId",
                schema: "collateral",
                table: "MachineAppraisalDetail",
                column: "CollateralMachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineAppraisalAdditionalInfo",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "MachineAppraisalDetail",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "collateralMachines",
                schema: "collateral");

            migrationBuilder.DropColumn(
                name: "HostCollatID",
                schema: "collateral",
                table: "CollateralMasters");

            migrationBuilder.RenameColumn(
                name: "CollatType",
                schema: "collateral",
                table: "CollateralMasters",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "CollateralType",
                schema: "collateral",
                table: "CollateralMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
