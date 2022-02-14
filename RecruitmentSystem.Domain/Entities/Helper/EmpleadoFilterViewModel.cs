using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities.Helper
{
    public class EmpleadoFilterViewModel
    {
        [Display(Name = "Fecha Desde")]
        public DateTime? FechaDesde { get; set; }
        [Display(Name = "Fecha Hasta")]
        public DateTime? FechaHasta { get; set; }
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
    }
}
