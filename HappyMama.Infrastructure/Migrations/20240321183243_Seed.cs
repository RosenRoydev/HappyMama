using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Nickname", "UserId" },
                values: new object[] { 1, "petrova", "579cfd9f-0dfd-4775-b05d-e2ca79d70b92" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AdminId", "AmountForPay", "CreatorId", "DeadTime", "Description", "Name", "NeededAmount", "TeacherId" },
                values: new object[] { 1, null, 5m, "579cfd9f-0dfd-4775-b05d-e2ca79d70b92", new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4521), "This year the present of the teacher will be two boxes of flowers", "Christmas gifts for the teachers", 80m, null });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AdminId", "CreatedOn", "CreatorId", "Description", "TeacherId", "Title" },
                values: new object[] { 1, null, new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4621), "a05289cd-5411-45bb-b863-ba2394c21342", "All parents , who want their child to be vaccinated , please contact with me . The vaccination is organized by the Ministry of health and is for free!", null, "Vaccine against Flu" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Amount", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, 180m, "Ani", "Ivanova", "228dfc0a-78a8-4163-aff3-94a5c1014fbb" },
                    { 2, 180m, "Petia", "Dubarova", "03d74db7-55ee-4ee0-ae1d-7c16a4578141" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Snezhana", "Ilieva", "a05289cd-5411-45bb-b863-ba2394c21342" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "AdminId", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "Title" },
                values: new object[] { 1, null, new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4682), "228dfc0a-78a8-4163-aff3-94a5c1014fbb", null, null, "Problem with Toni" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdminId", "Content", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "ThemeId" },
                values: new object[] { 1, null, "Hello i want to write Toni has problem with food . Do you have this problem ?", new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4842), "228dfc0a-78a8-4163-aff3-94a5c1014fbb", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdminId", "Content", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "ThemeId" },
                values: new object[] { 2, null, "I have the same problem", new DateTime(2024, 3, 21, 18, 32, 42, 852, DateTimeKind.Utc).AddTicks(4843), "03d74db7-55ee-4ee0-ae1d-7c16a4578141", null, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Themes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
