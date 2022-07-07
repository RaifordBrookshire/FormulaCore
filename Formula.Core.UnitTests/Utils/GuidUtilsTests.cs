using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
    public class GuidUtilsTests
    {

        [Fact]
        public void Basic_Usage()
        {
            Guid newGuid = GuidUtils.NewGuid();
            string guidString = newGuid.ToString();

            Guid copyGuid = GuidUtils.ToGuid(guidString);
            Assert.True(newGuid.Equals(copyGuid));

            Guid emptyGuid = GuidUtils.Empty;
            Assert.True(GuidUtils.IsEmpty(emptyGuid));
            Assert.False(GuidUtils.IsEmpty(newGuid));
        }
    }
}
