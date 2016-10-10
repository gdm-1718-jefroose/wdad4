using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DayCare.Db;
using DayCare.Models.Security;

namespace DayCare.API.Controllers {
    public class BaseController : Controller {
        protected ApplicationDbContext ApplicationDbContext { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public BaseController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager) {
            ApplicationDbContext = applicationDbContext;
            UserManager = userManager;
        }
    }
}