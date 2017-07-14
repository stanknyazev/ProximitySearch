using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using psLib;
using System.IO;

namespace psTests
{
    [TestClass]
    public class psLib
    {
        [TestMethod]
        public void SimpleTest6and3()
        {
            var search = new SimpleIndexProximitySearch();
            search.SetSearcheableText(File.ReadAllText(@"../../../psconsole/texts/simple.txt"));
            Assert.IsTrue(search.CountInstances("the", "canal", 6) == 3);
            Assert.IsTrue(search.CountInstances("the", "canal", 3) == 1);
        }
        [TestMethod]
        public void ComplexTest6()
        {
            var search = new SimpleIndexProximitySearch();
            search.SetSearcheableText(File.ReadAllText(@"../../../psconsole/texts/complex.txt"));
            Assert.IsTrue(search.CountInstances("the", "canal", 6) == 11);
        }   
    }
}
