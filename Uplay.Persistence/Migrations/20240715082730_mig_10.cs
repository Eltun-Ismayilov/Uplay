using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstMonthDiscount",
                schema: "Pricing",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "FirstYearDiscount",
                schema: "Pricing",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "Yearly",
                schema: "Pricing",
                table: "Pricings",
                newName: "MonthDiscount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthDiscount",
                schema: "Pricing",
                table: "Pricings",
                newName: "Yearly");

            migrationBuilder.AddColumn<double>(
                name: "FirstMonthDiscount",
                schema: "Pricing",
                table: "Pricings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FirstYearDiscount",
                schema: "Pricing",
                table: "Pricings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
