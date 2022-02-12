using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class agregaIdPuestoModeloCandidato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Puestos_PuestoAspiraId",
                table: "Candidatos");

            migrationBuilder.AlterColumn<int>(
                name: "PuestoAspiraId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Puestos_PuestoAspiraId",
                table: "Candidatos",
                column: "PuestoAspiraId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Puestos_PuestoAspiraId",
                table: "Candidatos");

            migrationBuilder.AlterColumn<int>(
                name: "PuestoAspiraId",
                table: "Candidatos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Puestos_PuestoAspiraId",
                table: "Candidatos",
                column: "PuestoAspiraId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
