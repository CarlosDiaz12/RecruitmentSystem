using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class agregarIndiceCedulaEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Cedula",
                table: "Empleados",
                column: "Cedula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empleados_Cedula",
                table: "Empleados");

            migrationBuilder.AlterColumn<string>(
                name: "Cedula",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
