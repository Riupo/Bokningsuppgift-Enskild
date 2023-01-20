using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokning_G.Migrations
{
    public partial class platser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Platser",
                table: "Bokningarna",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platser",
                table: "Bokningarna");
        }
    }
}
