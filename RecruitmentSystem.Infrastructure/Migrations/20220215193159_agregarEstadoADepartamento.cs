using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class agregarEstadoADepartamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Departamentos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Departamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Descripcion",
                table: "Departamentos",
                column: "Descripcion",
                unique: true,
                filter: "[Descripcion] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Descripcion",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Departamentos");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Departamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
