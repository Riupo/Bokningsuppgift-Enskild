using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bokning_G.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skapade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Användernamn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Lösenord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ålder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefonnummer = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skapade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bokningarna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkapaKontoId = table.Column<int>(type: "int", nullable: false),
                    KundNamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokningarna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bokningarna_Skapade_SkapaKontoId",
                        column: x => x.SkapaKontoId,
                        principalTable: "Skapade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokningarna_SkapaKontoId",
                table: "Bokningarna",
                column: "SkapaKontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokningarna_Tid",
                table: "Bokningarna",
                column: "Tid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skapade_Användernamn",
                table: "Skapade",
                column: "Användernamn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skapade_Mail",
                table: "Skapade",
                column: "Mail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bokningarna");

            migrationBuilder.DropTable(
                name: "Skapade");
        }
    }
}
