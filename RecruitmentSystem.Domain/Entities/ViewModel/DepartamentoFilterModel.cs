using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.ViewModel
{
    public class DepartamentoFilterModel
    {
        public string Descripcion { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
