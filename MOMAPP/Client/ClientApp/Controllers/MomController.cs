﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class MomController : Controller
    {
        //
        // GET: /Mom/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult History()
        {
            return View();
        }
    }
}