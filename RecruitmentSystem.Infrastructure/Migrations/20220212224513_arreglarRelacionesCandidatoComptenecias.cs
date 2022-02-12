using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class arreglarRelacionesCandidatoComptenecias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoCompetencia");

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "Competencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_CandidatoId",
                table: "Competencias",
                column: "CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competencias_Candidatos_CandidatoId",
                table: "Competencias",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencias_Candidatos_CandidatoId",
                table: "Competencias");

            migrationBuilder.DropIndex(
                name: "IX_Competencias_CandidatoId",
                table: "Competencias");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "Competencias");

            migrationBuilder.CreateTable(
                name: "CandidatoCompetencia",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    CompetenciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoCompetencia", x => new { x.CandidatoId, x.CompetenciaId });
                    table.ForeignKey(
                        name: "FK_CandidatoCompetencia_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoCompetencia_Competencias_CompetenciaId",
                        column: x => x.CompetenciaId,
                        principalTable: "Competencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoCompetencia_CompetenciaId",
                table: "CandidatoCompetencia",
                column: "CompetenciaId");
        }
    }
}
