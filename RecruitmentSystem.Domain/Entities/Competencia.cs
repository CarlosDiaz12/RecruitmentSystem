using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Competencia: BaseEntity
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
        public virtual Candidato Candidato { get; set; }
    }
}
