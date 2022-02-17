using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class UsuarioModulo
    {
        public string UsuarioId { get; set; }
        public virtual UsuarioIdentity Usuario { get; set; }
        public int ModuloId { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
