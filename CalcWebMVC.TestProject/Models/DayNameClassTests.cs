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
    public class DayNameClassTests
    {
        [TestMethod()]
        [TestCategory("Unit")]
        public void DayNameClassTest()
        {
            DayNameClass day = new DayNameClass(new DateTime(2019,10,15));
            Assert.AreEqual(day.DayInMonth, new DateTime(2019, 10, 15).Day);
            
           
            Assert.AreEqual(day.DayInWeek, (int)new DateTime(2019, 10, 15).DayOfWeek);  
            Assert.AreEqual(DayNameClass.Right(day.DayInWeek + 10), 5);
            
        }
    }
}