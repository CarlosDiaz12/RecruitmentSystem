using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.Helper
{
    public class CandidatoViewModel
    {
        public int[] CompetenciasIds { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public virtual Puesto PuestoAspira { get; set; }
        public string Departamento { get; set; }
        public double SalarioAspira { get; set; }
        public virtual List<Capacitacion> PrincipalesCapacitaciones { get; set; }
        public virtual List<Idioma> Idiomas { get; set; }
        public virtual List<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        public string RecomendadoPor { get; set; }
    }
}
