using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Request.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialByMe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestProperties",
                schema: "request");

            migrationBuilder.CreateTable(
                name: "RequestPropertys",
                schema: "request",
                columns: table => new
                {
                    PropertyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    BuildingType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    RequestId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPropertys", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_RequestPropertys_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "request",
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestPropertys_RequestId",
                schema: "request",
                table: "RequestPropertys",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPropertys",
                schema: "request");

            migrationBuilder.CreateTable(
                name: "RequestProperties",
                schema: "request",
                columns: table => new
                {
                    PropertyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    PropertyType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    RequestId = table.Column<long>(type: "bigint", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(19,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestProperties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_RequestProperties_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "request",
                        principalTable: "Requests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestProperties_RequestId",
                schema: "request",
                table: "RequestProperties",
                column: "RequestId");
        }
    }
}
