using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ByteUtils
    {

		private static Random _random = new Random();

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

		static public bool CompareBytes(byte[] bytes1, byte[] bytes2)
		{
			// This might not be needed and based on performace could be refactored out
			if (bytes1.Length != bytes2.Length)
				return false;

			return bytes1.SequenceEqual(bytes2);
		}

		static public string ToHashString(byte[] bytes)
		{
			// Convert bytes to string. NOTE: the string will contain dashes whihich we wil remove
			string hash = BitConverter.ToString(bytes);

			// Remove the dashes
			return hash.Replace("-", "");
		}

		//// Needs Testing and refactoring
		//public static void PrintByteArray(byte[] array)
		//{
		//    int i;
		//    for (i = 0; i < array.Length; i++)
		//    {
		//        Console.Write(String.Format("{0:X2}", array[i]));
		//        if ((i % 4) == 3) Console.Write(" ");
		//    }
		//    Console.WriteLine();
		//}

		public static byte[] Combine(byte[] first, byte[] second)
		{
			byte[] buffer = new byte[first.Length + second.Length];
			Buffer.BlockCopy(first, 0, buffer, 0, first.Length);
			Buffer.BlockCopy(second, 0, buffer, first.Length, second.Length);
			return buffer;
		}

		public  static byte[] GetBytes(int size)
		{
			byte[] bytes = new byte[size];
			_random.NextBytes(bytes);
			return bytes;
		}

	}
}
