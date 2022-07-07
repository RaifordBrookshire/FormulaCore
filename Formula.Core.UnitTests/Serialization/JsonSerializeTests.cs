using Formula.Core.Serialization;
using Formula.Core.Utils;
using Xunit;


namespace Formula.Core.UnitTests.Serialization
{
    internal class TestData
	{
		public int? IntValue { get; set; }
		public double? DoubleValue { get; set; }
		public bool? BoolValue { get; set; }
		public string StringValue { get; set; }
	}

	public class JsonSerializeTests
	{
		/// <summary>
		/// Provides basic usage of how to perform most operations using the serializer
		/// </summary>
		[Fact]
		public void JsonSerialize_BasicUsage()
		{
			TestData truthData = new TestData
			{
				BoolValue = true,
				IntValue = 777777777,
				DoubleValue = 777777.777777,
				StringValue = "My String Data 7777"
			};

			// Serilize and Deserialize
			string serializedData = JsonSerialize.Serialize(truthData);
			TestData deserializedData = JsonSerialize.Deserialize(serializedData, typeof(TestData)) as TestData;

			// Compare they should be the same
			CompareObjects comparer = new CompareObjects();
			Assert.True(comparer.Compare(truthData, deserializedData));



			// USING GENERICS! Serilize and Deserialize
			serializedData = JsonSerialize.Serialize(truthData);
			deserializedData = JsonSerialize.Deserialize<TestData>(serializedData);

			// Compare they should be the same
			comparer = new CompareObjects();
			Assert.True(comparer.Compare(truthData, deserializedData));
		}
	}
}
