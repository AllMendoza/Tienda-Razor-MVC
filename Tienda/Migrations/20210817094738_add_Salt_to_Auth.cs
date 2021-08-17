using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Migrations
{
    public partial class add_Salt_to_Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "auth_users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "auth_users");
        }
    }
}
