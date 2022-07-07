using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
    public class RandomGeneratorTests
    {

        [Fact]
        public void Basic_Usage()
        {            
            var r = new RandomGenerator();

            // This is a Usage Test only
            for (int i = 0; i < 5; i++)
            {
                Guid guid = r.GetGuid();

                int byteSize = 1000;
                var bytes = r.GetBytes(byteSize);
                Assert.True( bytes.Length == byteSize );
         
                var randDouble = r.GetDouble();
                Assert.True(randDouble < 1.00);

                var randInt = r.GetInt(10, 10);
                Assert.True(randInt == 10);

                randInt = r.GetInt(1000, 1020);
                Assert.True(randInt >= 1000 && randInt < 1020);

            }
        }
    }
}
