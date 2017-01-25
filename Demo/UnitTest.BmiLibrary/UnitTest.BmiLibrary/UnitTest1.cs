using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BmiLibrary;

namespace UnitTest.BmiLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BMITestMethod1()
        {
            Service service = new Service();
            string test = service.CalcBMI("73,180");

            Assert.AreEqual<string>("22.53", test);
        }

    }
}
