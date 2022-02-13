using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class repararRelacioncapacitacionCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoCapacitacion");

            migrationBuilder.AlterColumn<int>(
                name: "CandidatoId",
                table: "Competencias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CandidatoId",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_CandidatoId",
                table: "Capacitaciones",
                column: "CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Candidatos_CandidatoId",
                table: "Capacitaciones",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Candidatos_CandidatoId",
                table: "Capacitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Capacitaciones_CandidatoId",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "CandidatoId",
                table: "Capacitaciones");

            migrationBuilder.AlterColumn<int>(
                name: "CandidatoId",
                table: "Competencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CandidatoCapacitacion",
                columns: table => new
                {
                    CandidatoId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoCapacitacion", x => new { x.CandidatoId, x.CapacitacionId });
                    table.ForeignKey(
                        name: "FK_CandidatoCapacitacion_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoCapacitacion_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoCapacitacion_CapacitacionId",
                table: "CandidatoCapacitacion",
                column: "CapacitacionId");
        }
    }
}
