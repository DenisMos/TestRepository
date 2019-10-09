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
    public class ControllCalendarTests
    {
        [TestMethod()]
        [TestCategory("Integration.TA")]
        public void GetTest()
        {
            var calc = new Calendari();
            calc.calcs.Add(new CalcContext
            {
                Id = 0,
                DateKey = DateTime.Now.AddMonths(2),
                Message = "dad",
                Title = "title 1"
            });
            calc.calcs.Add(new CalcContext
            {
                Id = 1,
                DateKey = DateTime.Now,
                Message = "Push",
                Title = "title 2"
            });
            calc.Safe();
            var calcspisok = ControllCalendar.Get(DateTime.Now);
            Assert.AreEqual(calc.calcs[1].Id, calcspisok[0].Id);
        }

        [TestMethod()]
        [TestCategory("Integration.TA")]
        public void SetTest()
        {
            var calc = new Calendari();
            calc.calcs.Add(new CalcContext
            {
                Id = 0,
                DateKey = DateTime.Now.AddMonths(1),
                Message = "dad",
                Title = "title 1"
            });
            calc.calcs.Add(new CalcContext
            {
                Id = 1,
                DateKey = DateTime.Now,
                Message = "Push",
                Title = "title 2"
            });
            calc.Safe();
            ControllCalendar.Set(new CalcContext
            {
                Id = 2,
                DateKey = DateTime.Now.AddDays(-4),
                Message = "Pop",
                Title = "title 3"
            });
            var calc2 = Calendari.Load();

            Assert.AreEqual(calc2.calcs.Count, 3);
        }

        [TestMethod()]
        [TestCategory("Integration.TA")]
        public void DeleteTest()
        {
            var calc = new Calendari();

            CalcContext cl = new CalcContext
            {
                Id = 0,
                DateKey = DateTime.Now.AddMonths(1),
                Message = "dad",
                Title = "title 1"
            };
            

            calc.calcs.Add(cl);
            calc.calcs.Add(new CalcContext
            {
                Id = 1,
                DateKey = DateTime.Now,
                Message = "Push",
                Title = "title 2"
            });
            calc.Safe();
            ControllCalendar.Delete(cl);
            var calc2 = Calendari.Load();
            Assert.AreEqual(calc2.calcs.Count, 1);
        }
    }
}