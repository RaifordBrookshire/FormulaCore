using Formula.Core.Loggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Logging.Debug;

namespace Formula.Core.UnitTests.Loggers
{
    public class CoreLoggerTests
    {
        ILogger log = CoreLogger.GetLogger<CoreLoggerTests>();

        [Fact]
        public void Basic_Usage()
        {
            // NOTE: This will create a Default DebugLoggerProvider Logger Provider.
            //          When used in your App you should set the LoggerFactory property
            //          to an instance of your Application defined logger to refer to the same logger

            ILogger log = CoreLogger.GetLogger<CoreLoggerTests>();

            log.LogCritical("CRITICAL Message");
            log.LogError("ERROR Message");
            log.LogInformation("INFORMATION Message");
            log.LogDebug("DEBUG Message");
            log.LogTrace("TRACE Message");

        }

        [Fact]
        public void AssignLoggerFactoryAndLogMessage()
        {
            // NET Core will generally handle this for you
            ILoggerFactory factory = new LoggerFactory();
            factory.AddProvider(new DebugLoggerProvider());

            // This is all you need to do in your start up code !!!
            CoreLogger.LoggerFactory = factory;

            ILogger log = CoreLogger.GetLogger<CoreLoggerTests>();
            log.LogDebug("Test Debug Message !!!");
        }
    }
}
