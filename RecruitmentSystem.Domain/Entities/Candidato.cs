using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Candidato: BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public Puesto PuestoAspira { get; set; }
        public string Departamento { get; set; }
        public double SalarioAspira { get; set; }
        public ICollection<Competencia> PrincipalesCompetencias { get; set; }
        public ICollection<Capacitacion> PrincipalesCapacitaciones { get; set; }
        public int ExperienciaLaboral { get; set; }
        public string RecomendadoPor { get; set; }
    }
}
