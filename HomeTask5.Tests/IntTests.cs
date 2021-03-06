using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTask5.Tests
{
    public class IntTests
    {

        [Test]
        public void TestReverse()
        {
            int source = 125;
            int result = source.Reverse();
            Assert.AreEqual(521, result);
        }
    }

    
}
