using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class IsApprovedIsAddedToTeachersAndParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "The admin must approve the user");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Parents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "The admin must approve the user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Parents");
        }
    }
}
