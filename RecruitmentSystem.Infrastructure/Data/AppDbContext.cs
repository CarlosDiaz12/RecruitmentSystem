using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration Configuration;
        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SETUP CONNECTION STRING
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RHSystemDB"));
        }
    }
}
