﻿using RecruitmentSystem.Domain.Abstract.Base;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Abstract
{
    public interface ICandidatoRepository: IRepository<Candidato>
    {
        public Candidato GetByIdNoTracking(int Id);
        public bool ExisteCandidatoCedula(string cedula);
        public IEnumerable<Candidato> Filter(string nombre, string[] competenciasIds, string[] puestos, string[] capacitacionesIds);
    }
}
