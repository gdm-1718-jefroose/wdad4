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
     public class LocationsController : BaseController 
     {
        private const string FAILGETENTITIES = "Failed to get locations from the API";
        private const string FAILGETENTITYBYID = "Failed to get location from the API by Id: {0}";

        public LocationsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        [HttpGet(Name = "Get Locations")]
        public async Task<IActionResult> GetLocations([FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Locations.Include(o => o.Groups).ToListAsync():await ApplicationDbContext.Locations.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{locationId:int}", Name = "GetLocationById")]
        public async Task<IActionResult> GetLocationById(Int16 locationId, [FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Locations.Include(o => o.Groups).FirstOrDefaultAsync(o => o.Id == locationId):await ApplicationDbContext.Locations.FirstOrDefaultAsync(o => o.Id == locationId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
