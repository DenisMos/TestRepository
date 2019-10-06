using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CalcWebMVC.Models;
using System.Data.Entity;

namespace CalcWebMVC.Controllers
{
    public class HelloWorldController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(int day)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CalcContext cl)
        {

            CalcWrite.SerializationWrite(cl);
            return RedirectToAction("Calendar");
        }

        public ActionResult Calendar(string datetime)
        {
            DateTime dateTime;
            if (datetime == null) { dateTime = DateTime.Today; }
            else
            {
                dateTime = DateTime.Parse(datetime);
            }
            ViewBag.Calc = CalcRead.DeserializationComponents();
            int days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            DateTime[] dates = new DateTime[days];
            for (int i = 0; i<days; i++) {
                DateTime dt = new DateTime(dateTime.Year, dateTime.Month, i+1);
                dates[i] = dt;
            }
            
            ViewBag.dates = dates;
           
            ViewBag.data = dateTime;
            ViewBag.days = days;
            ViewBag.next = dateTime.AddMonths(1).ToShortDateString();
            ViewBag.innext = dateTime.AddMonths(-1).ToShortDateString();
            return View();
        }

        public ActionResult Welcome()
        {
            ViewBag.Calc = CalcRead.DeserializationComponents();
            DateTime dateTime = DateTime.Now;
            int days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            DateTime[] dates = new DateTime[days];
            for (int i = 0; i < days; i++)
            {
                DateTime dt = new DateTime(dateTime.Year, dateTime.Month, i + 1);
                dates[i] = dt;
            }

            ViewBag.dates = dates;
            
            ViewBag.days = days;
            ViewBag.data = dateTime;
            ViewBag.next = dateTime.AddMonths(1);
            ViewBag.innext = dateTime.AddMonths(-1);
            return View();
        }

        [HttpGet]
        public ActionResult Delete() {
            ViewBag.calcs = CalcRead.DeserializationComponents() as List<CalcContext>;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(CalcContext del)
        {
            
            del = SupportCalc.Find(del.DateKey, del.Title);
            if (del != null)
                SupportCalc.DeleteCalcFromJSON(del);
            
            return RedirectToAction("Calendar");
        }

    }
}