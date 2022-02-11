using RecruitmentSystem.Domain.Entities.Base;
using RecruitmentSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Puesto: BaseEntity
    {
        public string Nombre { get; set; }
        public NivelRiesgo NivelRiesgo { get; set; }
        public double NivelMinimoSalario { get; set; }
        public double NivelMaximoSalario { get; set; }
        public bool Estado { get; set; }
    }
}
