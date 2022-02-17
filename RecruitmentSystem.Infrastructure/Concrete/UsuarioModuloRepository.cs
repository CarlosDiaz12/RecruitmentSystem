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
    public class UsuarioModuloRepository: Repository<UsuarioModulo>,IUsuarioModuloRepository
    {
        private readonly AuthDbContext _authDbContext;
        public UsuarioModuloRepository(AuthDbContext authDbContext)
            : base(authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public UsuarioModulo BuscarUsuarioModulo(string usuarioId, int moduloId)
        {
            try
            {
                return _authDbContext.UsuariosModulos.FirstOrDefault(x => x.ModuloId == moduloId && x.UsuarioId == usuarioId.Trim());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
