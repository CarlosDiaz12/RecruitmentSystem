using RecruitmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Abstract
{
    public interface IUsuarioIdentityRepository
    {
        public bool UsuarioTienePermiso(string usuarioId, string nombreModulo);
    }
}
