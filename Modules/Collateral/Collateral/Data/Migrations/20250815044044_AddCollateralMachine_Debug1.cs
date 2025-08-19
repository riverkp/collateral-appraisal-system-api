using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collateral.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCollateralMachine_Debug1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineAppraisalAdditionalInfo",
                schema: "collateral");

            migrationBuilder.DropTable(
                name: "MachineAppraisalDetail",
                schema: "collateral");

            migrationBuilder.DropPrimaryKey(
                name: "PK_collateralMachines",
                schema: "collateral",
                table: "collateralMachines");

            migrationBuilder.RenameTable(
                name: "collateralMachines",
                schema: "collateral",
                newName: "CollateralMachines",
                newSchema: "collateral");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "collateral",
                table: "CollateralMachines",
                newName: "MachineID");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfManufacture",
                schema: "collateral",
                table: "CollateralMachines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                schema: "collateral",
                table: "CollateralMachines",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                schema: "collateral",
                table: "CollateralMachines",
                type: "decimal(19,4)",
                precision: 19,
                scale: 4,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "collateral",
                table: "CollateralMachines",
                type: "datetime2",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineName",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                schema: "collateral",
                table: "CollateralMachines",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                schema: "collateral",
                table: "CollateralMachines",
                type: "decimal(7,2)",
                precision: 7,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "EngineNo",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EnergyUse",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfManufacture",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                schema: "collateral",
                table: "CollateralMachines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "CollatId",
                schema: "collateral",
                table: "CollateralMachines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollateralMachines",
                schema: "collateral",
                table: "CollateralMachines",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_CollateralMachines_CollatId",
                schema: "collateral",
                table: "CollateralMachines",
                column: "CollatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CollateralMachines_CollateralMasters_CollatId",
                schema: "collateral",
                table: "CollateralMachines",
                column: "CollatId",
                principalSchema: "collateral",
                principalTable: "CollateralMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollateralMachines_CollateralMasters_CollatId",
                schema: "collateral",
                table: "CollateralMachines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollateralMachines",
                schema: "collateral",
                table: "CollateralMachines");

            migrationBuilder.DropIndex(
                name: "IX_CollateralMachines_CollatId",
                schema: "collateral",
                table: "CollateralMachines");

            migrationBuilder.DropColumn(
                name: "CollatId",
                schema: "collateral",
                table: "CollateralMachines");

            migrationBuilder.RenameTable(
                name: "CollateralMachines",
                schema: "collateral",
                newName: "collateralMachines",
                newSchema: "collateral");

            migrationBuilder.RenameColumn(
                name: "MachineID",
                schema: "collateral",
                table: "collateralMachines",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "YearOfManufacture",
                schema: "collateral",
                table: "collateralMachines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                schema: "collateral",
                table: "collateralMachines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNo",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                schema: "collateral",
                table: "collateralMachines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(19,4)",
                oldPrecision: 19,
                oldScale: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchaseDate",
                schema: "collateral",
                table: "collateralMachines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MachineName",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                schema: "collateral",
                table: "collateralMachines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                schema: "collateral",
                table: "collateralMachines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldPrecision: 7,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EngineNo",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnergyUse",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryOfManufacture",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                schema: "collateral",
                table: "collateralMachines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_collateralMachines",
                schema: "collateral",
                table: "collateralMachines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MachineAppraisalAdditionalInfo",
                schema: "collateral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprCollatPurpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprCollatType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprNo = table.Column<int>(type: "int", nullable: false),
                    ApprScrap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollateralMachineId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industrial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Installed = table.Column<int>(type: "int", nullable: false),
                    MachineLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maintenance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketDemand = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MarketDemandRemark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfAppraise = table.Column<int>(type: "int", nullable: false),
                    NotInstalled = table.Column<int>(type: "int", nullable: false),
                    Obligation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Performance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proprietor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurveyNo = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    AppraiserOpinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanUse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollateralMachineId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachinePart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsePurpose = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
