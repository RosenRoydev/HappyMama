using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadTime",
                value: new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(2913));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3008));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadTime",
                value: new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4521));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4682));
        }
    }
}
