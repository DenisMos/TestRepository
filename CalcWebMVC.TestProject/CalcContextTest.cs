using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcWebMVC.Models;

namespace CalcWebMVC.TestProject
{
    [TestClass]
    public class CalcContextTest
    {
        [TestMethod]
        public void NormalData()
        {
            CalcContext calcContext = new CalcContext(DateTime.Now,"p","t");

            Assert.AreEqual(calcContext.DateKey, DateTime.Now);
            Assert.AreEqual(calcContext.Title, "p");
            Assert.AreEqual(calcContext.Message, "t");
        }
    }
}
