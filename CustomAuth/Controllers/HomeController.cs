﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomAuth.Utility;

namespace CustomAuth.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}