﻿using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Competencia: BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
        [Display(Name = "Candidato")]
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
    }
}
