using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Core.DependencyInjection
{



	/// <summary>
	/// 
	/// NOTE: CORESERVICES IS STILL UNDER DEVELOPMENT AND NOT READY FOR PRIME TIME
	/// 
	/// CoreServices is a simple Wrapper / Facade to the built in .NET Core 3.1 Dependency Injection infrastructure.
	/// 
	/// This is need to create dependencies in your Class Libraries where you do not have an instance of the IServiceProvider
	/// and you prefer not to pollute you classes with constructor injectors.
	/// 
	///		ILogger _log = CoreLogger.GetLogger<T>();
	/// 
	/// IMPORTANT: You must Set the ServiceProvider to an instance of your application ServiceProvider in your application if you 
	///				want to inherit the Application defined Service setup and configuration.
	/// </summary>
	public static class CoreServices
	{
		private static IServiceProvider _provider;

		public static T GetService<T>()
		{
			return ServiceProvider.GetService<T>();
		}

		public static T GetRequiredService<T>()
		{
			return ServiceProvider.GetRequiredService<T>();
		}
		public static IEnumerable<T> GetServices<T>()
		{
			return ServiceProvider.GetServices<T>();
		}
		
		public static IServiceProvider ServiceProvider
		{
			get
			{
				if (_provider == null)
				{
					throw new NullReferenceException("CoreService -> ServiceProvider property is NULL. You must set this in your Application Startup code");
				}
				return _provider;
			}
			set
			{
				_provider = value;
			}
		}
	}
}