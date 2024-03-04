using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    public partial class FirstAndLastNameAddedToParents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Parents",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "First name of the parent");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Parents",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Last name of the parent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Parents");
        }
    }
}
