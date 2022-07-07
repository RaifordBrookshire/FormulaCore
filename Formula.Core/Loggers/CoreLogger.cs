using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Core.Loggers
{
	/// <summary>
	/// CoreLogger is a simple Wrapper / Facade to the build in .NET Core 3.1 Logging infrastructure.
	/// 
	/// This is meant to Create a new logger instance for each class you want to log for example:
	/// 
	///		ILogger _log = CoreLogger.GetLogger<T>();
	/// 
	/// IMPORTANT: You must Set the LoggerFactory to an instance of your application LoggerFactory in your application if you 
	///				want to inherit the Application defined Logger setup and configuration.
	/// </summary>
	public static class CoreLogger
    {
		private static ILoggerFactory _loggerFactory;

        public static ILogger<T> GetLogger<T>()
        {
			return LoggerFactory.CreateLogger<T>();
		}
		/// <summary>
		/// Gets the Logger Factory
		/// Sets the Logger Factory
		/// 
		/// IMPORTANT: You must Set the LoggerFactory to an instance of your application LoggerFactory in your application if you 
		/// want to inherit the Application defined Logger setup and configuration.
		/// </summary>
		public static ILoggerFactory LoggerFactory
		{
			get
			{
				if (_loggerFactory == null)
				{
					// Create a reasonable Default Logger Factory
					_loggerFactory = new LoggerFactory();
					_loggerFactory.AddProvider(new DebugLoggerProvider());
				}
				return _loggerFactory;
			}
			set 
			{
				_loggerFactory = value; 
			}
		}
	}
}

