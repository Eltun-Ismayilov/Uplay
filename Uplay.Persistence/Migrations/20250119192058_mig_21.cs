using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Uplay.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "User",
                table: "Claims",
                columns: new[] { "Id", "CreatedDate", "DeleteDate", "Deleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8517), null, false, "About_Post", null },
                    { 2, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8533), null, false, "About_Put", null },
                    { 3, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8544), null, false, "Branch_Delete", null },
                    { 4, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8552), null, false, "Branch_Disable", null },
                    { 5, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8559), null, false, "Category_Post", null },
                    { 6, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8568), null, false, "Branch_Statistics_Get", null },
                    { 7, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8576), null, false, "Branch_Qr_Retention_Get", null },
                    { 8, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8584), null, false, "Contact_Get", null },
                    { 9, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8592), null, false, "Contact_Details", null },
                    { 10, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8599), null, false, "Faq_Post", null },
                    { 11, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8606), null, false, "Faq_Put", null },
                    { 12, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8614), null, false, "Faq_Delete", null },
                    { 13, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8621), null, false, "FeedbackType_Post", null },
                    { 14, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8665), null, false, "FeedbackType_Delete", null },
                    { 15, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8674), null, false, "FeedbackType_Put", null },
                    { 16, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8681), null, false, "Partner_Post", null },
                    { 17, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8688), null, false, "Partner_Delete", null },
                    { 18, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8698), null, false, "Partner_Put", null },
                    { 19, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8706), null, false, "Playlist_Put", null },
                    { 20, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8713), null, false, "PublicReview_Post", null },
                    { 21, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8721), null, false, "PublicReview_Delete", null },
                    { 22, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8728), null, false, "PublicReview_Put", null },
                    { 23, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8735), null, false, "Service_Post", null },
                    { 24, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8742), null, false, "Service_Delete", null },
                    { 25, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8751), null, false, "Service_Put", null },
                    { 26, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8758), null, false, "SocialLink_Post", null },
                    { 27, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8766), null, false, "SocialLink_Put", null },
                    { 28, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8772), null, false, "Company_Delete", null },
                    { 29, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8779), null, false, "Add_User_Post", null },
                    { 30, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8785), null, false, "Get_All_Users", null },
                    { 31, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8792), null, false, "Category_Put", null },
                    { 32, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8798), null, false, "User_Put", null },
                    { 33, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8805), null, false, "Pricing_Put", null },
                    { 34, new DateTime(2025, 1, 19, 19, 20, 58, 849, DateTimeKind.Utc).AddTicks(8813), null, false, "Review_Put", null }
                });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(1538));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(1577));

            migrationBuilder.InsertData(
                schema: "User",
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimId", "CreatedDate", "DeleteDate", "Deleted", "RoleId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(2), null, false, 1, null },
                    { 2, 2, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(6), null, false, 1, null },
                    { 3, 3, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(8), null, false, 1, null },
                    { 4, 4, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(10), null, false, 1, null },
                    { 5, 5, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(12), null, false, 1, null },
                    { 6, 6, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(14), null, false, 1, null },
                    { 7, 7, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(16), null, false, 1, null },
                    { 8, 8, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(49), null, false, 1, null },
                    { 9, 9, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(51), null, false, 1, null },
                    { 10, 10, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(111), null, false, 1, null },
                    { 11, 11, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(112), null, false, 1, null },
                    { 12, 12, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(114), null, false, 1, null },
                    { 13, 13, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(116), null, false, 1, null },
                    { 14, 14, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(117), null, false, 1, null },
                    { 15, 15, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(119), null, false, 1, null },
                    { 16, 16, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(120), null, false, 1, null },
                    { 17, 17, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(122), null, false, 1, null },
                    { 18, 18, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(125), null, false, 1, null },
                    { 19, 19, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(127), null, false, 1, null },
                    { 20, 20, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(128), null, false, 1, null },
                    { 21, 21, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(130), null, false, 1, null },
                    { 22, 22, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(131), null, false, 1, null },
                    { 23, 23, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(133), null, false, 1, null },
                    { 24, 24, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(134), null, false, 1, null },
                    { 25, 25, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(136), null, false, 1, null },
                    { 26, 26, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(137), null, false, 1, null },
                    { 27, 27, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(139), null, false, 1, null },
                    { 28, 28, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(140), null, false, 1, null },
                    { 29, 1, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(142), null, false, 2, null },
                    { 30, 20, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(143), null, false, 2, null },
                    { 31, 5, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(145), null, false, 2, null },
                    { 32, 6, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(146), null, false, 2, null },
                    { 33, 23, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(148), null, false, 2, null },
                    { 34, 7, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(150), null, false, 2, null },
                    { 35, 8, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(152), null, false, 2, null },
                    { 36, 26, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(153), null, false, 2, null },
                    { 37, 9, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(155), null, false, 2, null },
                    { 38, 10, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(156), null, false, 2, null },
                    { 39, 13, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(158), null, false, 2, null },
                    { 40, 16, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(159), null, false, 2, null },
                    { 41, 6, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(161), null, false, 3, null },
                    { 42, 7, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(162), null, false, 3, null },
                    { 43, 8, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(164), null, false, 3, null },
                    { 44, 9, new DateTime(2025, 1, 19, 19, 20, 58, 850, DateTimeKind.Utc).AddTicks(165), null, false, 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "User",
                table: "Claims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 19, 32, 380, DateTimeKind.Utc).AddTicks(6250));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 19, 32, 380, DateTimeKind.Utc).AddTicks(6275));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 19, 32, 380, DateTimeKind.Utc).AddTicks(6294));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 19, 32, 380, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                schema: "User",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 19, 32, 380, DateTimeKind.Utc).AddTicks(6310));
        }
    }
}
