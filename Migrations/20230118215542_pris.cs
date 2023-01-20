using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokning_G.Migrations
{
    public partial class pris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SummaPerMånad",
                table: "Bokningarna",
                newName: "Pris");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pris",
                table: "Bokningarna",
                newName: "SummaPerMånad");
        }
    }
}
