using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "Pricing",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "AnnualDiscount",
                schema: "Pricing",
                table: "Pricings");

            migrationBuilder.RenameColumn(
                name: "ZeroToTenDiscount",
                schema: "Pricing",
                table: "Pricings",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "TenToTwentyDiscount",
                schema: "Pricing",
                table: "Pricings",
                newName: "FirstYearDiscount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "Pricing",
                table: "Pricings",
                newName: "ZeroToTenDiscount");

            migrationBuilder.RenameColumn(
                name: "FirstYearDiscount",
                schema: "Pricing",
                table: "Pricings",
                newName: "TenToTwentyDiscount");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                schema: "Pricing",
                table: "Pricings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AnnualDiscount",
                schema: "Pricing",
                table: "Pricings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
