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

            // capacitacion / nivel

            modelBuilder
                .Entity<Capacitacion>()
                .HasOne(m => m.Nivel);
           
            modelBuilder
                .Entity<Empleado>()
                .HasOne(m => m.Puesto)
                .WithOne();
            // competencias

            modelBuilder
                .Entity<Candidato>()
                .HasMany(x => x.PrincipalesCompetencias)
                .WithOne(x => x.Candidato)
                .OnDelete(DeleteBehavior.Cascade);

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
                .Entity<Candidato>()
                .HasMany(c => c.PrincipalesCapacitaciones)
                .WithOne(c => c.Candidato)
                .OnDelete(DeleteBehavior.Cascade);

            // experiencias laborales

            modelBuilder
                .Entity<Candidato>()
                .HasMany(x => x.ExperienciasLaborales)
                .WithOne(x => x.Candidato)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Candidato>()
                .HasIndex(x => x.Cedula)
                .IsUnique();

            modelBuilder
                .Entity<Departamento>()
                .HasIndex(x => x.Descripcion)
                .IsUnique();

            // puesto / candidato
            modelBuilder
                .Entity<Candidato>()
                .HasOne(m => m.PuestoAspira);

            // departamento / candidato
            modelBuilder.Entity<Candidato>()
                .HasOne(x => x.DepartamentoPertenece);

            // departamento / empleado
            modelBuilder.Entity<Empleado>()
                .HasOne(x => x.Departamento);

            // empleado / cedula
            modelBuilder
                .Entity<Empleado>()
                .HasIndex(x => x.Cedula)
                .IsUnique();
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
        public DbSet<CandidatoIdioma> CandidatoIdioma { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
