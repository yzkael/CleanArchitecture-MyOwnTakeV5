using Clean.Infrastructure;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override(nameof(Microsoft), LogEventLevel.Information)
    .WriteTo.Console()
    .WriteTo.File(
        path: "./logs/bootstrap/log-.json",
        rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();


try
{

    // Add services to the container.
    {
        builder.Services.AddControllers();
        builder.AddInfrastructure();
    }

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    {

        app.UseHttpsRedirection();
        app.UseSerilogRequestLogging();
        app.UseAuthorization();

        app.MapControllers();


    }
    app.Run();
}
catch (System.Exception exception)
{
    Log.Fatal(exception, "Application terminated unexpectedly");
    throw;
}
finally
{
    Log.Information("Closing and flushing logger");
    Log.CloseAndFlush();
}
