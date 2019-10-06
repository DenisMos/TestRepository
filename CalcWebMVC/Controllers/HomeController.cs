﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalcWebMVC.Models;
using System.Web.Mvc;

namespace CalcWebMVC.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
           
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