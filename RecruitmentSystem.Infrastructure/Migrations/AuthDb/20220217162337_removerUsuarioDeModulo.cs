using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations.AuthDb
{
    public partial class removerUsuarioDeModulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_AspNetUsers_UsuarioId",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_UsuarioId",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Modulos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Modulos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_UsuarioId",
                table: "Modulos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_AspNetUsers_UsuarioId",
                table: "Modulos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
