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
        public void Basic_Usage()
        {
            DateTime now = DateTimeUtils.GetUtcNow();

            string stringNow = now.ToString();
            DateTime newNow = DateTimeUtils.CoherceToDateTime(stringNow);
            Assert.Equal(now, newNow);

            DateTime emptyDateTime = DateTimeUtils.Empty;
            Assert.True(DateTimeUtils.IsEmpty(emptyDateTime));

        }
    }
}
