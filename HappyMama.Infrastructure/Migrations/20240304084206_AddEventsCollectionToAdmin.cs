using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class AddEventsCollectionToAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_AdminId",
                table: "Events",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Admins_AdminId",
                table: "Events",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Admins_AdminId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AdminId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Events");
        }
    }
}
