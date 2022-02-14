using RecruitmentSystem.Domain.Entities.Base;
using RecruitmentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Puesto: BaseEntity
    {
        [Display(Name = "Puesto")]
        public string Nombre { get; set; }
        [Display(Name = "Nivel Riesgo")]
        public NivelRiesgo NivelRiesgo { get; set; }
        [Display(Name = "Salario Minimo")]
        public double NivelMinimoSalario { get; set; }
        [Display(Name = "Salario Maximo")]
        public double NivelMaximoSalario { get; set; }
        public bool Estado { get; set; }
    }
}
