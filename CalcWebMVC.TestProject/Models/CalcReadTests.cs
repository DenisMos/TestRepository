using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWebMVC.Models.Tests
{
    [TestClass()]
    public class CalcReadTests
    {
        [TestMethod()]
        public void DeserializationComponentsTest()
        {
            IList<CalcContext> calcs = new List<CalcContext>();
            calcs = CalcRead.DeserializationComponents(@"C:/database/test/database.json") as List<CalcContext>;
            CalcContext calccon = calcs[0];
            CalcContext caltest = new CalcContext(DateTime.Today, "title", "message");
            if (calccon.isEquel(calccon.DateKey, caltest.DateKey) && caltest.Message == calccon.Message && caltest.Title == calccon.Title)
            {

            }
            else Assert.Fail();
        }

        [TestMethod()]
        public void SerializationReadTest()
        {

            Object calc = CalcRead.SerializationRead(DateTime.Today, @"C:/database/test/database.json");
            CalcContext calccon = calc as CalcContext;
            CalcContext caltest = new CalcContext(DateTime.Today, "title", "message");
            if (calccon.isEquel(calccon.DateKey, caltest.DateKey) && caltest.Message == calccon.Message && caltest.Title == calccon.Title) {

            }
            else Assert.Fail();

        }
    }
}