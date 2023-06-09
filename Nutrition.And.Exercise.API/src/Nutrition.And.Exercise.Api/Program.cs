using Nutrition.And.Exercise.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

try
{
    string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();

    var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

    logger.Information("Starting the Log!");

    builder.Host.UseSerilog(logger);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

builder.UseStartup<Startup>();