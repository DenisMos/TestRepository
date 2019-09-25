using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcWebMVC.Models;
using System.Web.Mvc;

namespace CalcWebMVC.Controllers
{
    public class HomeController : Controller
    {
        EventRequest ev = new EventRequest();

        public ActionResult Index()
        {
            ViewBag.Cals = ev.CalcContexts;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}