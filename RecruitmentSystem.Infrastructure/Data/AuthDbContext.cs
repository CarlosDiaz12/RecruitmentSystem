using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace RecruitmentSystem.Infrastructure.Data
{
    public class AuthDbContext: IdentityDbContext<UsuarioIdentity>
    {
        public AuthDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SETUP CONNECTION STRING
            optionsBuilder
                .UseSqlServer("Server=(local);Database=RHSystemDB;trusted_connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<UsuarioModulo>()
                .HasKey(cc => new { cc.UsuarioId, cc.ModuloId });

            modelBuilder
                .Entity<UsuarioModulo>()
                .HasOne(m => m.Usuario)
                .WithMany(m => m.Modulos)
                .HasForeignKey(cc => cc.UsuarioId);

            modelBuilder
                .Entity<UsuarioModulo>()
                .HasOne(m => m.Modulo)
                .WithMany(m => m.Usuarios)
                .HasForeignKey(cc => cc.ModuloId);
        }

        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<UsuarioModulo> UsuariosModulos { get; set; }
    }
}
