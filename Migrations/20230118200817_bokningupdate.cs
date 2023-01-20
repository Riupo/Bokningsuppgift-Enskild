using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokning_G.Migrations
{
    public partial class bokningupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bokningarna_Tid",
                table: "Bokningarna");

            migrationBuilder.RenameColumn(
                name: "Platser",
                table: "Bokningarna",
                newName: "SummaPerMånad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SummaPerMånad",
                table: "Bokningarna",
                newName: "Platser");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningarna_Tid",
                table: "Bokningarna",
                column: "Tid",
                unique: true);
        }
    }
}
