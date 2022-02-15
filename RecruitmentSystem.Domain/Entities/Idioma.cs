using RecruitmentSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class Idioma: BaseEntity
    {
        [Required]
        public string Nombre { get; set; }
        public bool Estado { get; set; } = true;
        public virtual ICollection<CandidatoIdioma> Candidatos { get; set; }
    }
}
