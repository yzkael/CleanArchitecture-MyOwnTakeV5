using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Clean.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Main Seeder
            var personaSudo = new Persona
            {
                Id = 1,
                Nombre = "sudoName",
                ApellidoPaterno = "sudoApPaterno",
                ApellidoMaterno = "sudoApMaterno",
                Carnet = "123456",
                Telefono = "123456"
            };

            var passwordHasher = new PasswordHasher<Usuario>();
            var hashedPassword = passwordHasher.HashPassword(null!, "123456");
            var usuarioSudo = new Usuario
            {
                Id = "dk-2dk-2kd-012kd-012kd-012k0=12kd=dk12=dk12=0dk12=0k1d2=0k12d=012",
                UserName = "sudo",
                Email = "sudo@hotmail.com",
                PasswordHash = hashedPassword,
                PersonaId = personaSudo.Id
            };

            var cargoSudo = new Cargo
            {
                Id = "asdasdoqwkdpoqwdpokqwdkoqwdkpoqwodk",
                Name = "Sudo",
                NormalizedName = "SUDO"
            };

            var cargoAsignadoSudo = new CargoAsignado
            {
                RoleId = "asdasdoqwkdpoqwdpokqwdkoqwdkpoqwodk",
                UserId = "dk-2dk-2kd-012kd-012kd-012k0=12kd=dk12=dk12=0dk12=0k1d2=0k12d=012"
            };

            // Seed data
            builder.Entity<Persona>().HasData(personaSudo);
            builder.Entity<Usuario>().HasData(usuarioSudo);
            builder.Entity<Cargo>().HasData(cargoSudo);
            builder.Entity<CargoAsignado>().HasData(cargoAsignadoSudo);



            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Cargo> Cargos { get; set; } = null!;
        public DbSet<CargoAsignado> CargosAsignados { get; set; } = null!;
    }
}