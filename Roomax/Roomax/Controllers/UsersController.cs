﻿using Roomax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomax.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }
    }
}