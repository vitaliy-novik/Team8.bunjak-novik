﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wunderlist.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Inbox()
        {
            return View();
        }
    }
}
