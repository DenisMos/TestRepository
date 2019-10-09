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
    public class CalendariTests
    {
        [TestMethod()]
        [TestCategory("Unit")]
        public void CalenariTest()
        {
            var per = new Calendari();
            per.calcs.Add(new CalcContext {
                Id = 0,
                DateKey = DateTime.Now,
                Message = "Message 1",
                Title = "title 1"

            });
            per.calcs.Add(new CalcContext
            {
                Id = 1,
                DateKey = DateTime.Now,
                Message = "Message 2",
                Title = "title 2"

            });
            Assert.AreEqual(per.calcs.Count, 2);

        }

        [TestMethod()]
        [TestCategory("Integration.TA")]
        public void TestLoad()
        {
            string path = @"C:/database/database.json";

            if (System.IO.File.Exists(path))
            {
                Calendari kal = Calendari.Load();
                int counter = kal.calcs.Count;

                kal.calcs.Add(new CalcContext
                {
                    Id = counter + 1,
                    DateKey = new DateTime(1, 1, 1, 14, 25, 0),
                    Title = "some title",
                    Message = "some message"
                }
                );
                kal.calcs.Add(new CalcContext
                {
                    Id = counter + 2,
                    DateKey = new DateTime(2, 1, 1, 14, 30, 0),
                    Title = "some title",
                    Message = "some message"
                }
                );
                kal.Safe();
                var res = Calendari.Load();

                Assert.AreEqual(2 + counter, res.calcs.Count);
                Assert.AreEqual(1 + counter, res.calcs[counter].Id);
            }
            else
            {
                Calendari kal = new Calendari();

                kal.calcs.Add(new CalcContext
                {
                    Id = 1,
                    DateKey = new DateTime(1, 1, 1, 14, 25, 0),
                    Title = "some title",
                    Message = "some message"
                }
                );
                kal.calcs.Add(new CalcContext
                {
                    Id = 2,
                    DateKey = new DateTime(2, 1, 1, 14, 30, 0),
                    Title = "some title",
                    Message = "some message"
                }
                );
                kal.Safe();
                var res = Calendari.Load();
                
                Assert.AreEqual(2, res.calcs.Count);
                Assert.AreEqual(1, res.calcs[0].Id);

            }
        }
    }
}