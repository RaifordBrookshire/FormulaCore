using System.IO;
using System.Reflection;

namespace Formula.Core.Utils
{
	/// <summary>
	/// Environment related helper and utility methods to make client code more readable.
	/// This will also abstract a specific implmentation should .NET change for diferrent 
	/// Platforms or versions.
	/// 
	/// NOTE: This is mainly for backwards compatibility for my existing .NET Framework Apps.
	/// </summary>
	public class EnvironmentUtils
	{
		/// <summary>
		/// Returns the Folder Path of the executing assembly.
		/// </summary>
		public static string ExecutingFolderPath
		{
			get
			{
				return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			}
		}

	}
}
