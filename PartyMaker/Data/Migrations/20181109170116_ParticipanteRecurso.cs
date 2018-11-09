using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyMaker.Data.Migrations
{
    public partial class ParticipanteRecurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Participantes_ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.AddColumn<int>(
                name: "RecursoIdRecurso",
                table: "Participantes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_RecursoIdRecurso",
                table: "Participantes",
                column: "RecursoIdRecurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Recursos_RecursoIdRecurso",
                table: "Participantes",
                column: "RecursoIdRecurso",
                principalTable: "Recursos",
                principalColumn: "IdRecurso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Recursos_RecursoIdRecurso",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_RecursoIdRecurso",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "RecursoIdRecurso",
                table: "Participantes");

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteIdParticipante",
                table: "Recursos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_ParticipanteIdParticipante",
                table: "Recursos",
                column: "ParticipanteIdParticipante");

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Participantes_ParticipanteIdParticipante",
                table: "Recursos",
                column: "ParticipanteIdParticipante",
                principalTable: "Participantes",
                principalColumn: "IdParticipante",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
