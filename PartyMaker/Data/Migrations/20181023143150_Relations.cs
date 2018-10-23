using Microsoft.EntityFrameworkCore.Migrations;

namespace PartyMaker.Data.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Eventos_IdEvento",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Eventos_IdEvento",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_IdEvento",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_IdEvento",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "IdEvento",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "EventoIdEvento",
                table: "Recursos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteIdParticipante",
                table: "Recursos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventoIdEvento",
                table: "Participantes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_EventoIdEvento",
                table: "Recursos",
                column: "EventoIdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_ParticipanteIdParticipante",
                table: "Recursos",
                column: "ParticipanteIdParticipante");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EventoIdEvento",
                table: "Participantes",
                column: "EventoIdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Eventos_EventoIdEvento",
                table: "Participantes",
                column: "EventoIdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Eventos_EventoIdEvento",
                table: "Recursos",
                column: "EventoIdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Participantes_ParticipanteIdParticipante",
                table: "Recursos",
                column: "ParticipanteIdParticipante",
                principalTable: "Participantes",
                principalColumn: "IdParticipante",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Eventos_EventoIdEvento",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Eventos_EventoIdEvento",
                table: "Recursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recursos_Participantes_ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_EventoIdEvento",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Recursos_ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_EventoIdEvento",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "EventoIdEvento",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "ParticipanteIdParticipante",
                table: "Recursos");

            migrationBuilder.DropColumn(
                name: "EventoIdEvento",
                table: "Participantes");

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "Recursos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEvento",
                table: "Participantes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_IdEvento",
                table: "Recursos",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_IdEvento",
                table: "Participantes",
                column: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Eventos_IdEvento",
                table: "Participantes",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recursos_Eventos_IdEvento",
                table: "Recursos",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
