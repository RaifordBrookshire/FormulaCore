using System;

namespace Formula.Core.Utils
{
	/// <summary>
	/// Useful wrapper around a Guid can be used in your application.
	/// </summary>
	public class GuidUtils
	{
		public static readonly Guid Empty = new Guid("{00000000-0000-0000-0000-000000000000}");

		/// <summary>
		/// converts a nullable Guid to a guid
		/// </summary>
		/// <param name="nullableGuid"></param>
		/// <returns></returns>
		public static Guid ToGuid(Guid? nullableGuid)
		{
			if (nullableGuid == null || !nullableGuid.HasValue)
			{
				return Guid.Empty;
			}
			return nullableGuid.Value;

		}

		/// <summary>
		/// Creates a Guid from an existing Guid in string representation. The format can be anything
		/// that Guid.Parse() will convert.
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public static Guid ToGuid(string guid)
		{
			return Guid.Parse(guid);
		}


		/// <summary>
		/// returns True if the Guid is equal to the value of GuidUtils.Empty
		/// returns False if the Guid is any other value, for example and existing Guid
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public static bool IsEmpty(Guid guid)
		{
			return guid.Equals(Guid.Empty);
		}
				
		
		/// <summary>
		/// Returns a new Guid. This will generally return the same as Guid.NewGuid()
		/// </summary>
		/// <returns></returns>
		public static Guid NewGuid()
		{
			return Guid.NewGuid();
		}

		/// <summary>
		/// Returns the prefix of a Guid with a with a string length equal to the value of 
		/// the count argument.
		/// </summary>
		/// <param name="guid"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GetPrefixString(Guid guid, int count = 4)
		{
			string prefix = guid.ToString().Substring(0, count);
			return prefix;
		}
	}
}
