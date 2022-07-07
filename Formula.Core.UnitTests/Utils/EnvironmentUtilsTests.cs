using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{
    public class EnvironmentUtilsTests
    {
        [Fact]
        public void Basic_Usage()
        {
          
            string appBaseFolderExpected = System.AppDomain.CurrentDomain.BaseDirectory;
            string executingFolderExpected = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string baseFolder = EnvironmentUtils.ApplicationBaseFolder;
            string executingFolder = EnvironmentUtils.ExecutingFolderPath;

            Assert.True(appBaseFolderExpected.Equals(baseFolder));
            Assert.True(executingFolderExpected.Equals(executingFolder));    
        }
    }
}
