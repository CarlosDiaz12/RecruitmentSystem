using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentSystem.Domain.Entities
{
    public class UsuarioIdentity: IdentityUser
    {
        //[PersonalData]
        [StringLength(100)]
        public string Firstname { get; set; }
        //[PersonalData]
        [StringLength(100)]
        public string LastName { get; set; }
    }
}
