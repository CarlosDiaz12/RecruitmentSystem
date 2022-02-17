using Microsoft.AspNetCore.Identity;
using RecruitmentSystem.Domain.Abstract;
using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Infrastructure.Concrete
{
    public class UsuarioIdentityRepository: IUsuarioIdentityRepository
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IUsuarioModuloRepository _usuarioModuloRepository;
        public UsuarioIdentityRepository(IModuloRepository moduloRepository, IUsuarioModuloRepository usuarioModuloRepository)
        {
            _moduloRepository = moduloRepository;
            _usuarioModuloRepository = usuarioModuloRepository;
        }

        public bool UsuarioTienePermiso(string usuarioId, string nombreModulo)
        {
            try
            {
                var modulo = _moduloRepository.GetByName(nombreModulo);
                if (modulo == null)
                    throw new Exception("Modulo no encontrado.");

                var existeUsuarioModulo = _usuarioModuloRepository.BuscarUsuarioModulo(usuarioId, modulo.Id);
                return existeUsuarioModulo != null;
            }
            catch
            {
                throw;
            }

        }
    }
}
