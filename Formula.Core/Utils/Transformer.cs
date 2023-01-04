using System;
using System.Collections.Generic;
using System.Text;

namespace Formula.Core.Utils
{
    /// <summary>
    /// Helper utility that Transforms any type of data to another with easy to remember conventions. 
	/// This comes in handy to abstract the underlying Api should one would want to change the implementation.
	/// 
	/// Transformer.InputToOutput
	/// 
	/// Ex.
	/// Transformer.StringToBytes("string");
    /// </summary>
    public class Transformer
    {
		/// <summary>
		/// Transforms a String to a Byte Array
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static byte[] StringToBytes(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			return bytes;
		}

		/// <summary>
		/// Transforms a Byte Array to a String
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static string BytesToString(byte[] bytes)
		{
			string text = Encoding.UTF8.GetString(bytes); ;
			return text;
		}

		/// <summary>
		/// Transforms a Byte Array to a Hexidecimal representation in a String
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static string BytesToHexString(byte[] bytes)
		{
			StringBuilder builder = new StringBuilder();
			foreach (Byte b in bytes)
			{
				builder.Append(b.ToString("x2"));
			}
			return builder.ToString();
		}
	}
}
