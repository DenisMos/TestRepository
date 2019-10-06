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
            CalcContext calc = new CalcContext(DateTime.Today, "title", "message");
            bool testresult = true;
            if (calc.DateKey == DateTime.Today && calc.Title == "title" && calc.Message == "message") {
                testresult = false;
            }
            Assert.IsFalse(testresult);
            Assert.IsTrue(calc.isEquel(calc.DateKey,DateTime.Today));
        }
    }
}
