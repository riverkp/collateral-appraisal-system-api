using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appraisal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProperties2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "CondoHeight",
                schema: "Appraisal",
                table: "CondoAppraisalDetails",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "BuildingYear",
                schema: "Appraisal",
                table: "CondoAppraisalDetails",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CondoHeight",
                schema: "Appraisal",
                table: "CondoAppraisalDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingYear",
                schema: "Appraisal",
                table: "CondoAppraisalDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}
