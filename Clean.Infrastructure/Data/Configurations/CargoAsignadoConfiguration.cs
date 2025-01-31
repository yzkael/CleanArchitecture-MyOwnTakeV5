using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations
{
    public class CargoAsignadoConfiguration : IEntityTypeConfiguration<CargoAsignado>
    {
        public void Configure(EntityTypeBuilder<CargoAsignado> builder)
        {
            builder.ToTable("CargoAsignado");
            var cargoAsignadoSudo = new CargoAsignado
            {
                RoleId = "cargo-sudo",
                UserId = "sudo-user-id"
            };
            builder.HasData(cargoAsignadoSudo);
        }
    }
}