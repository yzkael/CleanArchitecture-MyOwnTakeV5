using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }


        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Cargo> Cargos { get; set; } = null!;
        public DbSet<CargoAsignado> CargosAsignados { get; set; } = null!;
    }
}