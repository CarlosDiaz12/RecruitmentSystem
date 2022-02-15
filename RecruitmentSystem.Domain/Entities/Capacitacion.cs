using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Capacitacion: BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Nivel")]
        public int NivelId { get; set; }
        public virtual NivelAcademico Nivel { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaHasta { get; set; }
        [Required]
        public string Institucion { get; set; }
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
