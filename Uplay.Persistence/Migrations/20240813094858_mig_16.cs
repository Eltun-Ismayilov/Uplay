using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                schema: "Landing",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                schema: "Landing",
                table: "FeedbackTypes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                schema: "Landing",
                table: "FeedbackTypes");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                schema: "Landing",
                table: "Feedbacks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
