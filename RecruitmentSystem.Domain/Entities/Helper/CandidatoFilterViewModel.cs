using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.Helper
{
    public class CandidatoFilterViewModel
    {
        public string[] Competencias { get; set; }
        public List<Candidato> Candidatos { get; set; }
    }
}
