using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appraisal.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationVehicaleVessel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleAppraisalDetail",
                schema: "Appraisal",
                columns: table => new
                {
                    VehicleApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_VehicleAppraisalDetail", x => x.VehicleApprID);
                    table.ForeignKey(
                        name: "FK_VehicleAppraisalDetail_Appraisals_ApprId",
                        column: x => x.ApprId,
                        principalSchema: "Appraisal",
                        principalTable: "Appraisals",
                        principalColumn: "ApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselAppraisalDetail",
                schema: "Appraisal",
                columns: table => new
                {
                    VesselApprID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_VesselAppraisalDetail", x => x.VesselApprID);
                    table.ForeignKey(
                        name: "FK_VesselAppraisalDetail_Appraisals_ApprId",
                        column: x => x.ApprId,
                        principalSchema: "Appraisal",
                        principalTable: "Appraisals",
                        principalColumn: "ApprId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAppraisalDetail_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail",
                column: "ApprId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VesselAppraisalDetail_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetail",
                column: "ApprId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleAppraisalDetail",
                schema: "Appraisal");

            migrationBuilder.DropTable(
                name: "VesselAppraisalDetail",
                schema: "Appraisal");
        }
    }
}
