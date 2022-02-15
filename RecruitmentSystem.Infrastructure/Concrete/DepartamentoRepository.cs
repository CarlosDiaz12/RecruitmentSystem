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
    public class DepartamentoRepository: Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(AppDbContext dbContext)
            :base(dbContext)
        {

        }
    }
}
