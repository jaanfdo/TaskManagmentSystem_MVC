﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    public class PermissionController : Controller
    {
        // GET: Permission
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePermission()
        {
            return View();
        }
    }
}