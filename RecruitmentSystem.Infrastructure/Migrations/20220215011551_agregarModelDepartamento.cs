using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class agregarModelDepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Candidatos");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoPerteneceId",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_DepartamentoPerteneceId",
                table: "Candidatos",
                column: "DepartamentoPerteneceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidatos_Departamentos_DepartamentoPerteneceId",
                table: "Candidatos",
                column: "DepartamentoPerteneceId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatos_Departamentos_DepartamentoPerteneceId",
                table: "Candidatos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Candidatos_DepartamentoPerteneceId",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "DepartamentoPerteneceId",
                table: "Candidatos");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Candidatos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
