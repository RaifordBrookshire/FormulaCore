using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
    public class DateTimeUtilsTests
    {    
        [Fact]
        public void ToDateTimeTest()
        {
            DateTime expectedDateTime = DateTime.Now;
            DateTime? nullableDateTime = new Nullable<DateTime>(expectedDateTime);

            List<object> testValues = new List<object>
            {
                expectedDateTime.ToString(),
                nullableDateTime
                // Add test string here
            };

            foreach(var v in testValues)
            {
                var dt = DateTimeUtils.ToDateTime(v);
                Assert.True(DateTimeUtils.IsDateTimeEqual(expectedDateTime, dt), $"Failed to convert '{v}'. expected:{expectedDateTime} actual:{dt} ");
            }
		}

		[Fact]
        public void IsDateTimeEqualTest()
        {
            DateTime expectedDateTime = DateTime.Now;
            DateTime testDateTimeNoMilliseconds = DateTime.Parse(expectedDateTime.ToString());

            // NOTE: - Comparing in .NET will fail since it accounts for milliseconds.
            //         IsDateTimeEqual method will ignore milliseconds by default.
            //         You can override the default behavior by passing in false for ignoreMilliseconds param.
            Assert.False(DateTime.Compare(expectedDateTime, testDateTimeNoMilliseconds)==0);
            Assert.True(DateTimeUtils.IsDateTimeEqual(expectedDateTime, testDateTimeNoMilliseconds));
            Assert.False(DateTimeUtils.IsDateTimeEqual(expectedDateTime, expectedDateTime.AddSeconds(1)));
        }

		[Fact]
		public void IsDatePartEqualTest()
		{
			DateTime dt1 = DateTime.Now;
			DateTime dt2 = dt1.AddDays(1);
            DateTime dt3 = dt1.AddMinutes(1);
			Assert.False(DateTimeUtils.IsDatePartEqual(dt1, dt2));
			Assert.True(DateTimeUtils.IsDatePartEqual(dt1, dt3));
		}

		[Fact]
		public void IsTimePartEqualTest()
		{
			DateTime dt1 = DateTime.Now;
			DateTime dt2 = dt1.AddSeconds(1);
			DateTime dt3 = dt1.AddDays(1);
			Assert.False(DateTimeUtils.IsTimePartEqual(dt1, dt2));
			Assert.True(DateTimeUtils.IsTimePartEqual(dt1, dt3));
		}
	}

   
}
