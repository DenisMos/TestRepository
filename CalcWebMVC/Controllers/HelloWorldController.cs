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
            ControllCalendar.Set(cl);
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

            var listen = ControllCalendar.Get(dateTime);
            //(внизу)Иначе я не смог догодаться, хотя и понимаю что можно сделать легче. Это рассчёт дней, что входят
            // в интервал месяца и который попадают на пересечении месяцев.
            int days = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            int loshdatestart = DayNameClass.Right((int)new DateTime(dateTime.Year, dateTime.Month, 1).DayOfWeek-1);//сколько дней надо дополнить c прошлого месяца
            int loshdateend = 6 - DayNameClass.Right((int)new DateTime(dateTime.Year, dateTime.Month, days).DayOfWeek - 1);//сколькло дней дополнить со следующего 

            DayNameClass[] allday = new DayNameClass[days + loshdateend + loshdatestart];//Список всех дней
            //Начало ужаса
            int chis = 0;
            for (int i = loshdatestart; i > 0; i--) {//вычисление дней из прошедшего месяца
                allday[chis] = new DayNameClass(new DateTime(dateTime.Year, dateTime.Month, 1).AddDays(-i));
                chis++;
            }
            for (int i = 0; i < days; i++)
            {//этот месяц
                DateTime dt = new DateTime(dateTime.Year, dateTime.Month, i + 1);
                DayNameClass dayName = new DayNameClass(dt);
                allday[chis] = dayName;
                chis++;
            }//следующий месяц
            for (int i = 1; i <= loshdateend; i++)
            {
                allday[chis] = new DayNameClass(new DateTime(dateTime.Year, dateTime.Month, days).AddDays(i));
                chis++;
            }
            //Конец плохого кода
            ViewBag.nameday = allday; //Дни
            ViewBag.Calc = listen; //список событий
            ViewBag.data = dateTime; //текущяя дата
            ViewBag.next = dateTime.AddMonths(1).ToShortDateString(); //ссылки на след месяц
            ViewBag.innext = dateTime.AddMonths(-1).ToShortDateString(); //ссылка на предыдущий месяц
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete() {
            ViewBag.calcs = Calendari.Load().calcs;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(CalcContext del)
        {
            ControllCalendar.Delete(del);
            
            return RedirectToAction("Calendar");
        }

    }
}