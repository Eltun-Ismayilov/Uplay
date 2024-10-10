using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YoutubeId",
                schema: "PlayList",
                table: "PlayLists",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "YoutubeId",
                schema: "PlayList",
                table: "PlayLists",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
