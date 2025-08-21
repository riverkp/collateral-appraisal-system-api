using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appraisal.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigrationVehicaleVessel_fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAppraisalDetail_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_VesselAppraisalDetail_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VesselAppraisalDetail",
                schema: "Appraisal",
                table: "VesselAppraisalDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleAppraisalDetail",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail");

            migrationBuilder.RenameTable(
                name: "VesselAppraisalDetail",
                schema: "Appraisal",
                newName: "VesselAppraisalDetails",
                newSchema: "Appraisal");

            migrationBuilder.RenameTable(
                name: "VehicleAppraisalDetail",
                schema: "Appraisal",
                newName: "VehicleAppraisalDetails",
                newSchema: "Appraisal");

            migrationBuilder.RenameIndex(
                name: "IX_VesselAppraisalDetail_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetails",
                newName: "IX_VesselAppraisalDetails_ApprId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleAppraisalDetail_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetails",
                newName: "IX_VehicleAppraisalDetails_ApprId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VesselAppraisalDetails",
                schema: "Appraisal",
                table: "VesselAppraisalDetails",
                column: "VesselApprID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleAppraisalDetails",
                schema: "Appraisal",
                table: "VehicleAppraisalDetails",
                column: "VehicleApprID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAppraisalDetails_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetails",
                column: "ApprId",
                principalSchema: "Appraisal",
                principalTable: "Appraisals",
                principalColumn: "ApprId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselAppraisalDetails_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetails",
                column: "ApprId",
                principalSchema: "Appraisal",
                principalTable: "Appraisals",
                principalColumn: "ApprId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleAppraisalDetails_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VesselAppraisalDetails_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VesselAppraisalDetails",
                schema: "Appraisal",
                table: "VesselAppraisalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleAppraisalDetails",
                schema: "Appraisal",
                table: "VehicleAppraisalDetails");

            migrationBuilder.RenameTable(
                name: "VesselAppraisalDetails",
                schema: "Appraisal",
                newName: "VesselAppraisalDetail",
                newSchema: "Appraisal");

            migrationBuilder.RenameTable(
                name: "VehicleAppraisalDetails",
                schema: "Appraisal",
                newName: "VehicleAppraisalDetail",
                newSchema: "Appraisal");

            migrationBuilder.RenameIndex(
                name: "IX_VesselAppraisalDetails_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetail",
                newName: "IX_VesselAppraisalDetail_ApprId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleAppraisalDetails_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail",
                newName: "IX_VehicleAppraisalDetail_ApprId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VesselAppraisalDetail",
                schema: "Appraisal",
                table: "VesselAppraisalDetail",
                column: "VesselApprID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleAppraisalDetail",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail",
                column: "VehicleApprID");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleAppraisalDetail_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VehicleAppraisalDetail",
                column: "ApprId",
                principalSchema: "Appraisal",
                principalTable: "Appraisals",
                principalColumn: "ApprId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselAppraisalDetail_Appraisals_ApprId",
                schema: "Appraisal",
                table: "VesselAppraisalDetail",
                column: "ApprId",
                principalSchema: "Appraisal",
                principalTable: "Appraisals",
                principalColumn: "ApprId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
