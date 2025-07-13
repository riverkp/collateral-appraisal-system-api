using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workflow.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addmorestate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckedAt",
                table: "AppraisalSagaState",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckedBy",
                table: "AppraisalSagaState",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommitteeUserId",
                table: "AppraisalSagaState",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DecidedAt",
                table: "AppraisalSagaState",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinalDecision",
                table: "AppraisalSagaState",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedAt",
                table: "AppraisalSagaState",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerifiedBy",
                table: "AppraisalSagaState",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckedAt",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "CheckedBy",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "CommitteeUserId",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "DecidedAt",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "FinalDecision",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "VerifiedAt",
                table: "AppraisalSagaState");

            migrationBuilder.DropColumn(
                name: "VerifiedBy",
                table: "AppraisalSagaState");
        }
    }
}
