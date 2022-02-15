using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Empleado: BaseEntity
    {
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
        [Required]
        [Display(Name = "Puesto")]
        public int PuestoId { get; set; }
        public virtual Puesto Puesto { get; set; }
        [Required]
        [Display(Name = "Salario Mensual")]
        public double SalarioMensual { get; set; }
        public bool Estado { get; set; }
    }
}
