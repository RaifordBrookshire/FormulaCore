using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Formula.Core.Utils
{
	/// <summary>
	/// Useful utilities that can be applied to your objects such as Reflection, Serializing etc.
	/// </summary>
	public class ObjectUtils
	{
		/// <summary>
		/// Copies the Public Instance based properties from a [source] object to a [destination] object.
		/// This is done via .Net Type Reflection
		/// </summary>
		/// <param name="source"></param>
		/// <param name="destination"></param>
		/// <returns></returns>
		public static object MergeObjects(object source, object destination)
		{
			if (source != null && destination != null)
			{
				var t = source.GetType();

				foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
				{
					/////////////////////////////////////////////////
					// Handle Strings
					/////////////////////////////////////////////////
					if (pi.PropertyType == typeof(string))
					{
						// Seting Property
						string v = (string)pi.GetValue(source);
						if (!string.IsNullOrWhiteSpace(v))
						{
							pi.SetValue(destination, v);
						}

					}

					/////////////////////////////////////////////////
					// Handle Nullables
					/////////////////////////////////////////////////
					if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
					{
						var v = pi.GetValue(source, null);
						if (v != null)
						{
							pi.SetValue(destination, pi.GetValue(source));
						}
					}

					/////////////////////////////////////////////////
					// Handle objects
					/////////////////////////////////////////////////
					if (pi.GetValue(source, null) != null)
					{
						var v = pi.GetValue(source, null);
						if (v != null)
						{
							pi.SetValue(destination, pi.GetValue(source));
						}
					}
				}
			}
			return destination;
		}

		private bool IsNullableType(Type type)
		{
			return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
		}

	}

}





