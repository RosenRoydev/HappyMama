using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class MigrationForForum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadTime",
                value: new DateTime(2024, 4, 3, 13, 52, 21, 842, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 52, 21, 842, DateTimeKind.Utc).AddTicks(3385));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 52, 21, 842, DateTimeKind.Utc).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 52, 21, 842, DateTimeKind.Utc).AddTicks(3556));

            migrationBuilder.UpdateData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 52, 21, 842, DateTimeKind.Utc).AddTicks(3457));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadTime",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(2016));
        }
    }
}
