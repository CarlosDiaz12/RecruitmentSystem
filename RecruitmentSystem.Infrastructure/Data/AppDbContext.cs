using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecruitmentSystem.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SETUP CONNECTION STRING
            optionsBuilder.UseSqlServer("Server=(local);Database=RHSystemDB;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ENUM CONVERTER
            modelBuilder
                .Entity<Puesto>()
                .Property(p => p.NivelRiesgo)
                .HasConversion(
                v => v.ToString(),
                v => (NivelRiesgo)Enum.Parse(typeof(NivelRiesgo), v));

            modelBuilder
                .Entity<Capacitacion>()
                .HasOne(m => m.Nivel)
                .WithOne();

            modelBuilder
                .Entity<Empleado>()
                .HasOne(m => m.Puesto)
                .WithOne();

            modelBuilder
                .Entity<Candidato>()
                .HasMany(m => m.PrincipalesCapacitaciones)
                .WithOne(m => m.Candidato);

            modelBuilder
                .Entity<Candidato>()
                .HasMany(m => m.PrincipalesCapacitaciones)
                .WithOne(m => m.Candidato);
        }

        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<ExperienciaLaboral> ExperiencasLaborales { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }

    }
}
