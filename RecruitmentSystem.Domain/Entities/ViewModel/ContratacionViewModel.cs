using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.ViewModel
{
    public class ContratacionViewModel: Empleado
    {
        public int IdCandidato { get; set; }
    }
}
