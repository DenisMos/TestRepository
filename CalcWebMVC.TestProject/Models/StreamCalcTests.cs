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
    public class StreamCalcTests
    {
        [TestMethod()]
        public void ExitsFilesTest()
        {
            StreamCalc.ExitsFiles("C:/database/test/metest/supertest/database.json");
            bool truepath = System.IO.File.Exists("C:/database/test/metest/supertest/database.json");
            Assert.IsTrue(truepath);
        }
    }
}