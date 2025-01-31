using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Domain.Entities;

namespace Clean.Infrastructure.Models
{
    public class Persona : PersonaBase
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}