using Microsoft.VisualStudio.TestTools.UnitTesting;

using psLib.ProximitySearch;
using System.IO;
using System.Diagnostics;

namespace psTests.ProximitySearch
{
    [TestClass]
    public class SimpleSearch
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

        [TestMethod]
        [TestCategory("performance")]
        public void ComplexTest6_PerformanceFast()
        {
            int i = 0;
            var search = new SimpleIndexProximitySearch();
            search.SetSearcheableText(File.ReadAllText(@"../../../psconsole/texts/complex.txt"));
            while (i < 100000)
            {
                Assert.IsTrue(search.CountInstances("the", "canal", 6) == 11);
                i++;
            }

        }

        [TestMethod]
        [TestCategory("performance")]
        public void ComplexTest6_PerformanceSlow()
        {
            int i = 0;
            var search = new SimpleIndexProximitySearch();
            string data = File.ReadAllText(@"../../../psconsole/texts/complex.txt");
            while (i < 100000)
            {
                search.SetSearcheableText(data);
                Assert.IsTrue(search.CountInstances("the", "canal", 6) == 11);
                i++;
            }
        }

        [TestMethod]
        [TestCategory("performance")]
        public void ComplexTest6_PerformanceDifference()
        {

            var sw = new Stopwatch();
            sw.Start();
            ComplexTest6_PerformanceFast();
            long fast = sw.ElapsedMilliseconds;
            sw.Reset(); sw.Start();
            ComplexTest6_PerformanceSlow();
            long slow = sw.ElapsedMilliseconds;

            Assert.IsTrue(fast < slow);
        }
    }
}
