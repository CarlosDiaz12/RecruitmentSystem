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
    public class ModuloRepository: Repository<Modulo>, IModuloRepository
    {
        private readonly AuthDbContext _authDbContext;
        public ModuloRepository(AuthDbContext authDbContext)
            :base(authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public Modulo GetByName(string name)
        {
            try
            {
                return _authDbContext.Modulos.FirstOrDefault(x => x.Descripcion.ToUpper() == name.ToUpper());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
