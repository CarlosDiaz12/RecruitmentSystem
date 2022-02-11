﻿using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Capacitacion: BaseEntity
    {
        public string Descripcion { get; set; }

        public int NivelId { get; set; }
        public NivelAcademico Nivel { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaDesde { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaHasta { get; set; }
        public string Institucion { get; set; }
        public ICollection<CandidatoCapacitacion> Candidatos { get; set; }
    }
}
