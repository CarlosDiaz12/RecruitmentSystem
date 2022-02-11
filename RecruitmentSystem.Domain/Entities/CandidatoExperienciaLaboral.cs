using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class CandidatoExperienciaLaboral
    {
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
        public int ExperienciaLaboralId { get; set; }
        public ExperienciaLaboral ExperienciaLaboral { get; set; }
    }
}
