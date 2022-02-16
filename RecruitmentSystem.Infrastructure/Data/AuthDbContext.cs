using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Domain.Entities;

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
    }
}
