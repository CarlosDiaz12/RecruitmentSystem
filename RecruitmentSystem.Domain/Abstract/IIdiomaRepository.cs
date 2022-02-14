using RecruitmentSystem.Domain.Abstract.Base;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Abstract
{
    public interface IIdiomaRepository: IRepository<Idioma>
    {
        public IQueryable<CandidatoIdioma> GetCandidatoIdiomasAll();
    }
}
