﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

    }
}
