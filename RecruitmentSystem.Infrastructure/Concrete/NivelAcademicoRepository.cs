using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Infrastructure.Concrete.Base;
using RecruitmentSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Concrete
{
    public class NivelAcademicoRepository : Repository<NivelAcademico>, INivelAcademicoRepository
    {
        public NivelAcademicoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
