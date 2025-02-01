using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(c => c.Carnet).IsUnique();
            builder.Property(p => p.Nombre).IsRequired();
            builder.Property(p => p.ApellidoPaterno).IsRequired();
            builder.Property(p => p.ApellidoMaterno).IsRequired();
            builder.Property(p => p.Carnet).IsRequired();
        }
    }
}