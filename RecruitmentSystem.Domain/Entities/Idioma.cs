using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Idioma: BaseEntity
    {
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<CandidatoIdioma> Candidatos { get; set; }
    }
}
