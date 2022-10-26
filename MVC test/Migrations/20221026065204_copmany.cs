using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_test.Migrations
{
    public partial class copmany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Mice",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Mice");
        }
    }
}
