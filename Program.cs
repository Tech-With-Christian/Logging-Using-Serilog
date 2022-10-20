using Microsoft.Extensions.Configuration;

using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

var logger = new LoggerConfiguration()

    .ReadFrom.Configuration(configuration)
    // Create the actual logger
    .CreateLogger();

logger.ForContext<Program>().Information("Hello World");
logger.ForContext(Constants.SourceContextPropertyName, "TWC").Warning("Hola, I'm a Warning!");
logger.ForContext(Constants.SourceContextPropertyName, "Microsoft").Error("Hello. This is Microsoft greeting!");


Log.CloseAndFlush();

