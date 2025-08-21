using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appraisal.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationMachineDetailInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Appraisal",
                table: "Appraisals",
                newName: "ApprId");

            migrationBuilder.CreateTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "Appraisal",
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
                    table.ForeignKey(
                        name: "FK_MachineAppraisalAdditionalInfos_Appraisals_ApprId",
                        column: x => x.ApprId,
                        principalSchema: "Appraisal",
                        principalTable: "Appraisals",
                        principalColumn: "ApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineAppraisalDetails",
                schema: "Appraisal",
                columns: table => new
                {
                    MachineApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprId = table.Column<long>(type: "bigint", nullable: false),
                    CanUse = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                        name: "FK_MachineAppraisalDetails_Appraisals_ApprId",
                        column: x => x.ApprId,
                        principalSchema: "Appraisal",
                        principalTable: "Appraisals",
                        principalColumn: "ApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineAppraisalAdditionalInfos_ApprId",
                schema: "Appraisal",
                table: "MachineAppraisalAdditionalInfos",
                column: "ApprId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineAppraisalDetails_ApprId",
                schema: "Appraisal",
                table: "MachineAppraisalDetails",
                column: "ApprId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineAppraisalAdditionalInfos",
                schema: "Appraisal");

            migrationBuilder.DropTable(
                name: "MachineAppraisalDetails",
                schema: "Appraisal");

            migrationBuilder.RenameColumn(
                name: "ApprId",
                schema: "Appraisal",
                table: "Appraisals",
                newName: "Id");
        }
    }
}
