using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.ViewModel
{
    public class CandidatoFilterViewModel
    {
        public string[] Competencias { get; set; }
        public string[] Puestos { get; set; }
        public string[] Capacitaciones { get; set; }
        public List<Candidato> Candidatos { get; set; } = new List<Candidato>();
        public string Nombre { get; set; }
    }
}
