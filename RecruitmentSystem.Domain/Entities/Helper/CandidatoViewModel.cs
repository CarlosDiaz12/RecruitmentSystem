using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.Helper
{
    public class CandidatoViewModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "Puesto Aspira")]
        public int PuestoAspiraId { get; set; }
        public string Departamento { get; set; }
        [Display(Name = "Salario Aspira")]
        public double SalarioAspira { get; set; }
        [ScaffoldColumn(false)]
        public virtual List<Capacitacion> Capacitaciones { get; set; } = new List<Capacitacion>();
        [ScaffoldColumn(false)]
        public virtual string[] Idiomas { get; set; }
        [ScaffoldColumn(false)]
        public virtual List<ExperienciaLaboral> ExperienciasLaborales { get; set; } = new List<ExperienciaLaboral>();
        [ScaffoldColumn(false)]
        public virtual List<Competencia> Competencias { get; set; }
        [Display(Name = "Recomendado Por")]
        public string RecomendadoPor { get; set; }
    }
}
