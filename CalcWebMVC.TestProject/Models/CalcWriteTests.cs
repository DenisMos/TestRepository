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
    public class CalcWriteTests
    {
        [TestMethod()]
        public void SerializationWriteTest()
        {

            CalcWrite.SerializationWrite(new CalcContext(DateTime.Today, "title", "message"),true, "C:/database/test/database.json");
            bool right = System.IO.File.Exists(@"C:/database/test/database.json");
            Assert.IsTrue(right);
           
        }
    }
}