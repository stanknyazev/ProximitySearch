using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using psLib.Extensions;

namespace psTests.Extensions
{
    [TestClass]
    public class ParamsMap
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "A missing parameter in input")]
        [TestCategory("exceptions")]
        public void TestOutOfRange()
        {
            Assert.IsTrue(new string[] { "" }.InputFileName() == "input.txt");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "Missing all parameter in input")]
        [TestCategory("exceptions")]
        public void TestEmptyInput()
        {
            Assert.IsTrue(new string[] { }.InputFileName() == "input.txt");
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException),
        "Invalit integer input for Proximity")]
        [TestCategory("exceptions")]
        public void TestIntInput()
        {
            Assert.IsTrue(new string[] { "keyword","keywordTwo","Proximity" }.Proximity() == 3);
        }
        [TestMethod]
        
        public void TestCorrectIntInput()
        {
            Assert.IsTrue(new string[] { "keyword", "keywordTwo", "3" }.Proximity() == 3);
        }
    }
}
