﻿using RecruitmentSystem.Domain.Entities.Base;
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
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }
        public double SalarioMensual { get; set; }
        public bool Estado { get; set; }
    }
}
