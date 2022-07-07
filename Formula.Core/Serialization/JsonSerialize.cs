
using System;
using System.IO;
using System.Text.Json;

namespace Formula.Core.Serialization
{
	/// <summary>
	/// Provides a centralized place for all serialization code with EASY to use methods. This also abstracts any dependencies 
	/// from your application should you need to change the implementation down the road or future versions
	/// of .NET
	/// </summary>
	public class JsonSerialize	{		
		public static T Deserialize<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json);
		}
		public static object Deserialize(string json, Type type)
		{
			return JsonSerializer.Deserialize(json, type);		
		}

		public static string Serialize(object obj)
		{
			return JsonSerializer.Serialize(obj);	
		}
		public static string Serialize<T>(T obj, JsonSerializerOptions options)
        {
			return JsonSerializer.Serialize(obj, options);
		}
	}
}

