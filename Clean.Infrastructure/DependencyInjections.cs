using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Clean.Infrastructure
{
    public static class DependencyInjections
    {
        public static void AddInfrastructure(this IHostApplicationBuilder builder)
        {
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
        }
    }
}