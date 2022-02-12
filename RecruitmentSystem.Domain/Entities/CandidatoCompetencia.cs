using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class CandidatoCompetencia
    {
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public int CompetenciaId { get; set; }
        public virtual Competencia Competencia { get; set; }
    }
}
