using Formula.Core.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoreTool
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Setup the Standard App Logger
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });

            // Assign and Call Logger Methods via the Standard App Logger
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Info Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            Console.ReadLine();

            // Setup the CoreLogger
           CoreLogger.LoggerFactory = loggerFactory;

            // Assign and Call Logger Methods via the CoreLogger
            ILogger coreLogger = CoreLogger.GetLogger<Program>();
            coreLogger.LogInformation("Core -> Info Log");
            coreLogger.LogWarning("Core -> Warning Log");
            coreLogger.LogError("Core -> Error Log");
            coreLogger.LogCritical("Core -> Critical Log");
            Console.ReadLine();


            //setup our DI
            //var serviceProvider = new ServiceCollection()
            //    .AddLogging()
            //    .AddSingleton<IFooService, FooService>()
            //    .AddSingleton<IBarService, BarService>()
            //    .BuildServiceProvider();

            ////configure console logging
            //ILoggerFactory factory = serviceProvider.GetService<ILoggerFactory>();


            Console.WriteLine("Thank you for enjoying the CoreTool");
        }
    }
}