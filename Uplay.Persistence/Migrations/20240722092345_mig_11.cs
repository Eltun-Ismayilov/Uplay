using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FeedbackTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks",
                column: "FeedbackTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_FeedbackTypes_FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks",
                column: "FeedbackTypeId",
                principalTable: "FeedbackTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_FeedbackTypes_FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FeedbackTypes");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackTypeId",
                schema: "Landing",
                table: "Feedbacks");
        }
    }
}
