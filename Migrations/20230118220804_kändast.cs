using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokning_G.Migrations
{
    public partial class kändast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KändastProdukt",
                table: "Bokningarna",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KändastProdukt",
                table: "Bokningarna");
        }
    }
}
