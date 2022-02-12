using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class NivelAcademico: BaseEntity
    {
        [Display(Name = "Nivel")]
        public string Descripcion { get; set; }
    }
}
