﻿using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View("Help");
        }
    }
}
