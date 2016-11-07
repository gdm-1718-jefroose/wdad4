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
    public abstract class BaseController : Controller 
    {
        public ApplicationDbContext ApplicationDbContext { get; set; }
        public UserManager<ApplicationUser>  ApplicationUserManager  { get; set; }
        public RoleManager<ApplicationRole>  ApplicationRoleManager  { get; set; }
        
        public BaseController() 
        {
        }

        public BaseController([FromServices]ApplicationDbContext applicationDbContext) 
        {
            ApplicationDbContext = applicationDbContext;
        }

        public BaseController([FromServices]ApplicationDbContext applicationDbContext, [FromServices]UserManager<ApplicationUser>  ApplicationUserManager, [FromServices]RoleManager<ApplicationRole>  ApplicationRoleManager) 
        {
            ApplicationDbContext = applicationDbContext;
        }
    }
}