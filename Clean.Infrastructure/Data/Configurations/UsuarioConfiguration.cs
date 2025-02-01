using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasOne(u => u.Persona)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey<Usuario>(u => u.PersonaId);
        }
    }
}