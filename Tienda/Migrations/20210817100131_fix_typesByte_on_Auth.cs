using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tienda.Migrations
{
    public partial class fix_typesByte_on_Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "auth_users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "saltt",
                table: "auth_users",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "auth_users");

            migrationBuilder.DropColumn(
                name: "saltt",
                table: "auth_users");
        }
    }
}
