using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
    public class TransformerTests
    {
        [Fact]
        public void Basic_Usage()
        {
            const string InputString = "This is the test input text";
            byte[] bytes = Transformer.StringToBytes(InputString);
            string hexString = Transformer.BytesToHexString(bytes);
            string newString = Transformer.BytesToString(bytes);

            Assert.True(newString == InputString);

        }
    }
}
