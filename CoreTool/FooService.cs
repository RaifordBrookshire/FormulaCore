﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTool
{

    public interface IFooService
    {
        void DoThing(int number);
    }

    public class FooService : IFooService
    {
        private readonly ILogger<FooService> _logger;
        public FooService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooService>();
        }

        public void DoThing(int number)
        {
            _logger.LogInformation($"Doing the thing {number}");
        }
    }
}
