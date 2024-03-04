using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Nickname", "UserId" },
                values: new object[] { 1, "petrova", "90402621-705a-4592-9195-70a26d1188cc" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AdminId", "CreatorId", "DeadTime", "Description", "Name", "NeededAmount", "TeacherId" },
                values: new object[] { 1, null, "90402621-705a-4592-9195-70a26d1188cc", new DateTime(2024, 3, 4, 17, 51, 10, 491, DateTimeKind.Utc).AddTicks(8616), "This year the present of the teacher will be two boxes of flowers", "Christmas gifts for the teachers", 80m, null });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AdminId", "CreatedOn", "CreatorId", "Description", "TeacherId", "Title" },
                values: new object[] { 1, null, new DateTime(2024, 3, 4, 17, 51, 10, 491, DateTimeKind.Utc).AddTicks(8683), "8b6afc3a-0922-497a-b97d-faf99cb5b2ff", "All parents , who want their child to be vaccinated , please contact with me . The vaccination is organized by the Ministry of health and is for free!", null, "Vaccine against Flu" });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Amount", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, 180m, "Ani", "Ivanova", "d2a09f19-256f-47ce-b661-04fe9fb105d6" },
                    { 2, 180m, "Petia", "Dubarova", "de119094-95c7-4b8f-a4be-e46203394b69" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "Snezhana", "Ilieva", "8b6afc3a-0922-497a-b97d-faf99cb5b2ff" });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "AdminId", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "Title" },
                values: new object[] { 1, null, new DateTime(2024, 3, 4, 17, 51, 10, 491, DateTimeKind.Utc).AddTicks(8786), "d2a09f19-256f-47ce-b661-04fe9fb105d6", null, null, "Problem with Toni" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdminId", "Content", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "ThemeId" },
                values: new object[] { 1, null, "Hello i want to write Toni has problem with food . Do you have this problem ?", new DateTime(2024, 3, 4, 17, 51, 10, 491, DateTimeKind.Utc).AddTicks(8874), "d2a09f19-256f-47ce-b661-04fe9fb105d6", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AdminId", "Content", "CreatedOn", "CreatorId", "ParentId", "TeacherId", "ThemeId" },
                values: new object[] { 2, null, "I have the same problem", new DateTime(2024, 3, 4, 17, 51, 10, 491, DateTimeKind.Utc).AddTicks(8874), "de119094-95c7-4b8f-a4be-e46203394b69", null, null, 1 });
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
