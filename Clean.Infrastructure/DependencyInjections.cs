using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Application.Services;
using Clean.Infrastructure.Data;
using Clean.Infrastructure.Models;
using Clean.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;

namespace Clean.Infrastructure
{
    public static class DependencyInjections
    {
        public static void AddInfrastructure(this IHostApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
            });

            builder.Services.AddIdentity<Usuario, Cargo>(options =>
            {
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SudoPolicy", p => p.RequireRole("Sudo"));
            });


            builder.Services.AddSerilog(options =>
            {
                options.MinimumLevel.Information()
                  .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug,
                  outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                  .WriteTo.File("Logs/log-.txt",
                  rollOnFileSizeLimit: true,
                  rollingInterval: RollingInterval.Day,
                  fileSizeLimitBytes: 1000000,
                  outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                  restrictedToMinimumLevel: LogEventLevel.Warning);
            });

            builder.Services.AddSingleton<ILoggerServices, LoggerServices>();
        }
    }
}