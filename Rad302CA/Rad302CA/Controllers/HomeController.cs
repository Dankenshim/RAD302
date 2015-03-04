﻿using Rad302CA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rad302CA.Controllers
{
    public class HomeController : Controller
    {
        public northwndEntities db = new northwndEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(db.Orders);
        }
    }
}