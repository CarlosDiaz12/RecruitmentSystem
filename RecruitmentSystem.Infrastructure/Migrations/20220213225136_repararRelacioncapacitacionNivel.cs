using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class repararRelacioncapacitacionNivel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Capacitaciones_NivelId",
                table: "Capacitaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_NivelId",
                table: "Capacitaciones",
                column: "NivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Capacitaciones_NivelId",
                table: "Capacitaciones");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_NivelId",
                table: "Capacitaciones",
                column: "NivelId",
                unique: true);
        }
    }
}
