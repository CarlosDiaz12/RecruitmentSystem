using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class CandidatoIdioma
    {
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public int IdiomaId { get; set; }
        public virtual Idioma Idioma { get; set; }
    }
}
