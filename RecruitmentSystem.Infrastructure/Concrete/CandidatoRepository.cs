using Microsoft.EntityFrameworkCore;
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
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        private readonly AppDbContext _context;
        public CandidatoRepository(AppDbContext dbContext) 
            : base(dbContext)
        {
            _context = dbContext;
        }

        public Candidato GetByIdNoTracking(int Id)
        {
            try
            {
                var data = _context.Candidatos.Find(Id);
                if (data == null)
                {
                    return data;
                }
                _context.Entry(data).State = EntityState.Detached;
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
