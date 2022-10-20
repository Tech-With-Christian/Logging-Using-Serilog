using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

Log.Logger = new LoggerConfiguration()

    // Add console (Sink) as logging target
    .WriteTo.Console()

    // Write logs to a file for warning and logs with a higher severity
    // Logs are written in JSON
    .WriteTo.File(new JsonFormatter(),
        "important-logs.json",
        restrictedToMinimumLevel: LogEventLevel.Warning)

    // Add a log file that will be replaced by a new log file each day
    .WriteTo.File("all-daily-.logs",
        rollingInterval: RollingInterval.Day)

    // Set default minimum log level
    .MinimumLevel.Debug()

    // Create the actual logger
    .CreateLogger();

Console.WriteLine("Hello, World!");

Log.CloseAndFlush();

