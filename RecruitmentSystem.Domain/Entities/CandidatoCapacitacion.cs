using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class CandidatoCapacitacion
    {
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }
}
