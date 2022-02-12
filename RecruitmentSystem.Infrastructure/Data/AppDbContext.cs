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
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=(local);Database=RHSystemDB;trusted_connection=true");
            
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
            // competencias

            modelBuilder
                .Entity<CandidatoCompetencia>()
                .HasKey(cc => new { cc.CandidatoId, cc.CompetenciaId });

            modelBuilder
                .Entity<CandidatoCompetencia>()
                .HasOne(m => m.Candidato)
                .WithMany(m => m.PrincipalesCompetencias)
                .HasForeignKey(cc => cc.CandidatoId);

            modelBuilder
                .Entity<CandidatoCompetencia>()
                .HasOne(m => m.Competencia)
                .WithMany(m => m.Candidatos)
                .HasForeignKey(cc => cc.CompetenciaId);

            // idiomas

            modelBuilder
                .Entity<CandidatoIdioma>()
                .HasKey(cc => new { cc.CandidatoId, cc.IdiomaId });

            modelBuilder
                .Entity<CandidatoIdioma>()
                .HasOne(m => m.Candidato)
                .WithMany(m => m.Idiomas)
                .HasForeignKey(cc => cc.CandidatoId);

            modelBuilder
                .Entity<CandidatoIdioma>()
                .HasOne(m => m.Idioma)
                .WithMany(m => m.Candidatos)
                .HasForeignKey(cc => cc.IdiomaId);

            // capacitaciones

            modelBuilder
                .Entity<CandidatoCapacitacion>()
                .HasKey(cc => new { cc.CandidatoId, cc.CapacitacionId });

            modelBuilder
                .Entity<CandidatoCapacitacion>()
                .HasOne(m => m.Candidato)
                .WithMany(m => m.PrincipalesCapacitaciones)
                .HasForeignKey(cc => cc.CandidatoId);

            modelBuilder
                .Entity<CandidatoCapacitacion>()
                .HasOne(m => m.Capacitacion)
                .WithMany(m => m.Candidatos)
                .HasForeignKey(cc => cc.CapacitacionId);

            // experiencias laborales

            modelBuilder
                .Entity<CandidatoExperienciaLaboral>()
                .HasKey(cc => new { cc.CandidatoId, cc.ExperienciaLaboralId });

            modelBuilder
                 .Entity<CandidatoExperienciaLaboral>()
                 .HasOne(m => m.Candidato)
                 .WithMany(m => m.ExperienciasLaborales)
                 .HasForeignKey(cc => cc.CandidatoId);

            modelBuilder
             .Entity<CandidatoExperienciaLaboral>()
             .HasOne(m => m.ExperienciaLaboral)
             .WithMany(m => m.Candidatos)
             .HasForeignKey(cc => cc.ExperienciaLaboralId);

            // query filters
            //modelBuilder
            //    .Entity<Capacitacion>()
            //    .Navigation(x => x.Nivel);
        }

        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<ExperienciaLaboral> ExperiencasLaborales { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<NivelAcademico> NivelesAcademicos { get; set; }
        public DbSet<CandidatoCompetencia> CandidatoCompetencia { get; set; }
        public DbSet<CandidatoCapacitacion> CandidatoCapacitacion { get; set; }
        public DbSet<CandidatoIdioma> CandidatoIdioma { get; set; }
        public DbSet<CandidatoExperienciaLaboral> CandidatoExperienciaLaboral { get; set; }
    }
}
