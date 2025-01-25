using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mih_25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YoutubeToken",
                schema: "User",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 8, 41, 54, 905, DateTimeKind.Utc).AddTicks(6506));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 8, 41, 54, 905, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 8, 41, 54, 905, DateTimeKind.Utc).AddTicks(6562));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 8, 41, 54, 905, DateTimeKind.Utc).AddTicks(6599));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 25, 8, 41, 54, 905, DateTimeKind.Utc).AddTicks(6607));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YoutubeToken",
                schema: "User",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 20, 29, 48, 550, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 20, 29, 48, 550, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 20, 29, 48, 550, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 20, 29, 48, 550, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 20, 29, 48, 550, DateTimeKind.Utc).AddTicks(6289));
        }
    }
}
