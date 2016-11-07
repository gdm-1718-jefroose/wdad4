using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DayCare.Db;
using DayCare.Models;
using DayCare.Models.Security;

namespace  DayCare.WWW.Areas.Backoffice.Controllers 
{
    [Area("Backoffice")]
    public class HomeController : BaseController 
    {
        public HomeController():base()
        {
        }

        public IActionResult Index() 
        {
            return View();
        }
    }
}