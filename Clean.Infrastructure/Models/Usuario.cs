using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Clean.Infrastructure.Models
{
    public class Usuario : IdentityUser
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = null!;
    }
}