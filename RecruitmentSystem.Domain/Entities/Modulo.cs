using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Modulo: BaseEntity
    {
        public string Descripcion { get; set; }
        public virtual ICollection<UsuarioModulo> Usuarios { get; set; }
    }
}
