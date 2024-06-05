using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "User",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                schema: "User",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Company",
                table: "Companies",
                newName: "BrandName");

            migrationBuilder.AddColumn<Guid>(
                name: "Salt",
                schema: "User",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "User",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "User",
                table: "Users",
                newName: "PasswordSalt");

            migrationBuilder.RenameColumn(
                name: "BrandName",
                schema: "Company",
                table: "Companies",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "User",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
