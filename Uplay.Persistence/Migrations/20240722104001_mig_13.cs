using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RatingBranchs");

            migrationBuilder.RenameTable(
                name: "RatingBranchs",
                newName: "RatingBranchs",
                newSchema: "Landing");

            migrationBuilder.RenameTable(
                name: "FeedbackTypes",
                schema: "public",
                newName: "FeedbackTypes",
                newSchema: "Landing");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                schema: "Landing",
                table: "RatingBranchs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "Landing",
                table: "RatingBranchs");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "RatingBranchs",
                schema: "Landing",
                newName: "RatingBranchs");

            migrationBuilder.RenameTable(
                name: "FeedbackTypes",
                schema: "Landing",
                newName: "FeedbackTypes",
                newSchema: "public");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RatingBranchs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
