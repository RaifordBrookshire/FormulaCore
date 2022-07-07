using Formula.Core.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xunit;

namespace Formula.Core.UnitTests.Utils
{


    internal class TestEmployee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Dob { get; set; }
    }

    internal class TestEmployeeSerializable : ISerializable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }



    public class ObjectUtilsTests
    {

        [Fact]
        public void Basic_Usage()
        {
            TestEmployee employee = new TestEmployee()
            {
                Id = Guid.NewGuid(),
                Dob = DateTime.Now.AddYears(-40),
                Name = "Raiford Brookshire"
            };

            TestEmployee employee2 = new TestEmployee() { Id = Guid.NewGuid() };

            var copyEmployee = ObjectUtils.MergeObjects(employee, employee2);
            
            var objCompare = new CompareObjects();
            Assert.True(objCompare.Compare(employee, employee2));
        }
    }
}
