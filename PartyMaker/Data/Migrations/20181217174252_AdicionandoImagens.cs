using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyMaker.Data.Migrations
{
    public partial class AdicionandoImagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemLocal",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemNome",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemLocal",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ImagemNome",
                table: "Eventos");
        }
    }
}
