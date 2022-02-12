using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class arreglarRelacionesModeloCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoExperienciaLaboral");

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "ExperiencasLaborales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Candidatos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperiencasLaborales_CandidatoId",
                table: "ExperiencasLaborales",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_Cedula",
                table: "Candidatos",
                column: "Cedula",
                unique: true,
                filter: "[Cedula] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperiencasLaborales_Candidatos_CandidatoId",
                table: "ExperiencasLaborales",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperiencasLaborales_Candidatos_CandidatoId",
                table: "ExperiencasLaborales");

            migrationBuilder.DropIndex(
                name: "IX_ExperiencasLaborales_CandidatoId",
                table: "ExperiencasLaborales");

            migrationBuilder.DropIndex(
                name: "IX_Candidatos_Cedula",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "ExperiencasLaborales");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CandidatoExperienciaLaboral",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    ExperienciaLaboralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoExperienciaLaboral", x => new { x.CandidatoId, x.ExperienciaLaboralId });
                    table.ForeignKey(
                        name: "FK_CandidatoExperienciaLaboral_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoExperienciaLaboral_ExperiencasLaborales_ExperienciaLaboralId",
                        column: x => x.ExperienciaLaboralId,
                        principalTable: "ExperiencasLaborales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoExperienciaLaboral_ExperienciaLaboralId",
                table: "CandidatoExperienciaLaboral",
                column: "ExperienciaLaboralId");
        }
    }
}
