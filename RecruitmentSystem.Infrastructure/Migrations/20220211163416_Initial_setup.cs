using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecruitmentSystem.Infrastructure.Migrations
{
    public partial class Initial_setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperiencasLaborales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuestoOcupado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperiencasLaborales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelesAcademicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesAcademicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelRiesgo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NivelMinimoSalario = table.Column<double>(type: "float", nullable: false),
                    NivelMaximoSalario = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuestoAspiraId = table.Column<int>(type: "int", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalarioAspira = table.Column<double>(type: "float", nullable: false),
                    ExperienciaLaboral = table.Column<int>(type: "int", nullable: false),
                    RecomendadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidatos_Puestos_PuestoAspiraId",
                        column: x => x.PuestoAspiraId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    SalarioMensual = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Capacitaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelId = table.Column<int>(type: "int", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Capacitaciones_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Capacitaciones_NivelesAcademicos_NivelId",
                        column: x => x.NivelId,
                        principalTable: "NivelesAcademicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    CandidatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competencias_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_PuestoAspiraId",
                table: "Candidatos",
                column: "PuestoAspiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_CandidatoId",
                table: "Capacitaciones",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_NivelId",
                table: "Capacitaciones",
                column: "NivelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_CandidatoId",
                table: "Competencias",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitaciones");

            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "ExperiencasLaborales");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "NivelesAcademicos");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Puestos");
        }
    }
}
