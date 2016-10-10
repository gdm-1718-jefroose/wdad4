using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DayCare.Db;
using DayCare.Models;
using DayCare.Models.Security;

namespace DayCare.API.Controllers
{
    [Route("api/[controller]")]
     public class LocationsController : BaseController {
        public LocationsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) {
        }

        [HttpGet(Name = "Get Locations")]
        public async Task<IActionResult> GetLocations()
        {
            var model = await ApplicationDbContext.Locations.ToListAsync();
            if (model == null)
            {
                var msg = String.Format("Failed to get locations from the API");
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{locationId:int}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(Int16 locationId)
        {
            var model = await ApplicationDbContext.Locations.FirstOrDefaultAsync(o => o.Id == locationId);
            if (model == null)
            {
                var msg = String.Format("Failed to get location from the API");
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
