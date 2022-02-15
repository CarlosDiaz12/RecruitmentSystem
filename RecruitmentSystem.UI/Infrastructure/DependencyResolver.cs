using Microsoft.Extensions.DependencyInjection;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentSystem.UI.Infrastructure
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // add dependencies
            services.AddScoped<ICompetenciaRepository, CompetenciaRepository>();
            services.AddScoped<IIdiomaRepository, IdiomaRepository>();
            services.AddScoped<ICapacitacionRepository, CapacitacionRepository>();
            services.AddScoped<IPuestoRepository, PuestoRepository>();
            services.AddScoped<ICandidatoRepository, CandidatoRepository>();
            services.AddScoped<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();
            services.AddScoped<INivelAcademicoRepository, NivelAcademicoRepository>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            return services;
        }
    }
}
