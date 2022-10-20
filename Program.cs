using Serilog;

Log.Logger = new LoggerConfiguration()

                            // Add console (Sink) as logging target
                            .WriteTo.Console()

                            // Set default minimum log level
                            .MinimumLevel.Debug()

                            // Create the actual logger
                            .CreateLogger();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Log.CloseAndFlush();

