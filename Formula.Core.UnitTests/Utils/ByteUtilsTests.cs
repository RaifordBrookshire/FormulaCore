using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
	public class ByteUtilsTests
	{
		[Fact]
		public void Basic_Usage()
		{
			const string InputString = "This is the test input text";
			byte[] bytes = ByteUtils.StringToBytes(InputString);
			string hexString = ByteUtils.BytesToHexString(bytes);
			string newString = ByteUtils.BytesToString(bytes);

			Assert.True(newString == InputString);
		}

		[Fact]
		public void CompareBytesTest()
		{
			// ARRANGE
			///////////////////////////////////////////////
			const string testData = "abcd";
			byte[] testBytes1 = Encoding.UTF8.GetBytes(testData);
			byte[] testBytes2 = Encoding.UTF8.GetBytes(testData + "additional text");
			byte[] testBytes3 = Encoding.UTF8.GetBytes(testData);

			// ACT
			///////////////////////////////////////////////
			bool equalityTestSuccess = ByteUtils.CompareBytes(testBytes1, testBytes3) == true;
			bool equalityTestFail = ByteUtils.CompareBytes(testBytes1, testBytes2) == false;

			// ASSERT
			///////////////////////////////////////////////
			Assert.True(equalityTestSuccess, "CryptoUtils.CompareBytes() - success compare FAILED test");
			Assert.True(equalityTestFail, "CryptoUtils.CompareBytes() - fail compare FAILED test");
		}

		[Fact]
		public void BytesToStringTest()
		{
			// ARRANGE
			const string testData = "abcd";
			byte[] testBytes = Encoding.UTF8.GetBytes(testData);

			// ACT
			string result = ByteUtils.BytesToString(testBytes);

			// ASSERT
			Assert.True(string.Equals(result, testData));
		}

		[Fact]
		public void GetRandomBytesTest()
		{
			int bufferSize = 1000;
			byte[] bytes = ByteUtils.GetBytes(bufferSize);
			Assert.True(bytes.Count() == bufferSize);
		}
	}
}