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
        public ICollection<CandidatoCompetencia> PrincipalesCompetencias { get; set; }
        public ICollection<CandidatoCapacitacion> PrincipalesCapacitaciones { get; set; }
        public ICollection<CandidatoIdioma> Idiomas { get; set; }
        public ICollection<CandidatoExperienciaLaboral> ExperienciasLaborales { get; set; }
        public string RecomendadoPor { get; set; }
    }
}
