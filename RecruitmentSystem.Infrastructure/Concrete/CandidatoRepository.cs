using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Entities.Helper;
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

        public void CrearCandidato(CandidatoViewModel _object)
        {
            try
            {

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
