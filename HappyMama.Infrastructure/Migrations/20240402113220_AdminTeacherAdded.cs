using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class AdminTeacherAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 3, "Petia", "Petrova", "579cfd9f-0dfd-4775-b05d-e2ca79d70b92" });

            migrationBuilder.UpdateData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 11, 32, 20, 567, DateTimeKind.Utc).AddTicks(2016));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
