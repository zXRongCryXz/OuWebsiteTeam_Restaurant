﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OuWebsiteTeam_RestaurantWebUI.Areas.HomePage.Controllers
{
    public class MediaController : Controller
    {
        // GET: HomePage/Media
        public ActionResult Media()
        {
            ViewBag.Title = "Media";
            return View();            
        }

        public ActionResult Image()
        {
            return View();
        }
    }
}