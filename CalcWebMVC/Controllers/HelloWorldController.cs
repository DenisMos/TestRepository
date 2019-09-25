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

        //EventRequest ev = new EventRequest();
        //CalcContext[] calcmass;//Иниц бд

        public ActionResult Index()
        {
            //ViewBag.Calc = ev.CalcContexts;
            //calcmass = CalcContext.SSerializationReads2();
            //ViewBag.calcmass = calcmass;
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

            cl.SerializationWrite();
            //ev.Entry(cl).State = EntityState.Added;
            //ev.SaveChanges();

            return RedirectToAction("Welcome");
        }

        public ActionResult Calendar(int day, int month, int year)
        {

            //ViewBag.Calc = ev.CalcContexts;/database
            ViewBag.Calc = CalcContext.DeserializationComponents();
            DateTime dateTime;
                if (month <= 12 && month >= 1 && day > 0 && day <= DateTime.DaysInMonth(year, month))
                    dateTime = new DateTime(year, month, day);
                else
                    dateTime = DateTime.Today;

            int days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            DateTime[] dates = new DateTime[days];
            for (int i = 0; i<days; i++) {
                DateTime dt = new DateTime(dateTime.Year, dateTime.Month, i+1);
                dates[i] = dt;
            }
            
            ViewBag.dates = dates;
           
            ViewBag.data = dateTime;
            ViewBag.days = days;
            ViewBag.next = dateTime.AddMonths(1);
            ViewBag.innext = dateTime.AddMonths(-1);
            return View();
        }

        public ActionResult Welcome()
        {

            //ViewBag.Calc = ev.CalcContexts;/database
            ViewBag.Calc = CalcContext.DeserializationComponents();
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
            ViewBag.calcs = CalcContext.DeserializationComponents() as List<CalcContext>;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(CalcContext del)
        {

            del = CalcContext.Find(del.DateKey, del.Title);
            if (del != null)
                CalcContext.DeleteCalcFromJSON(del);
            
            return RedirectToAction("Welcome");
        }

        
        public string Test()
        {
            CalcContext calcmass = CalcContext.SerializationRead(new DateTime(22,9,2019));
            Random rnd = new Random();
            CalcContext cl = new CalcContext(DateTime.Now, "titul" + rnd.Next(1000).ToString() , "message");
            cl.SerializationWrite();
            
            return "Добавление завершено ... " + CalcContext.SerializationRead(DateTime.Now);
        }
    }
}