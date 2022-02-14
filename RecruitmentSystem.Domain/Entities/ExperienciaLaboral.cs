using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class ExperienciaLaboral: BaseEntity
    {
        public string Empresa { get; set; }
        [Display(Name = "Puesto Ocupado")]
        public string PuestoOcupado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHasta { get; set; }
        public double Salario { get; set; }
        [Display(Name = "Candidato")]
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
