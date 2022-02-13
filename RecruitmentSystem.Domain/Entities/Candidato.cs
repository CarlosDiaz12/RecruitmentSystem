using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Candidato: BaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Puesto Aspira")]
        public int PuestoAspiraId { get; set; }
        public virtual Puesto PuestoAspira { get; set; }
        public string Departamento { get; set; }
        [Display(Name = "Salario Aspira")]
        public double SalarioAspira { get; set; }
        public virtual ICollection<Competencia> PrincipalesCompetencias { get; set; }
        public virtual ICollection<CandidatoCapacitacion> PrincipalesCapacitaciones { get; set; }
        public virtual ICollection<CandidatoIdioma> Idiomas { get; set; } = new List<CandidatoIdioma>();
        public virtual ICollection<ExperienciaLaboral> ExperienciasLaborales { get; set; } = new List<ExperienciaLaboral>();
        [Display(Name = "Recomendado Por")]
        public string RecomendadoPor { get; set; }
    }
}
