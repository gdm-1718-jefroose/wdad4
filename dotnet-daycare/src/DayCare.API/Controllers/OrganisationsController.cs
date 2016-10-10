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
     public class OrganisationsController : BaseController {
        public OrganisationsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) {
        }

        [HttpGet(Name = "GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            var model = await ApplicationDbContext.Organisations.ToListAsync();
            if (model == null)
            {
                var msg = String.Format("Failed to get organisations from the API");
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{organisationId:int}", Name = "GetOrganisationById")]
        public async Task<IActionResult> GetOrganisationById(Int16 organisationId)
        {
            var model = await ApplicationDbContext.Organisations.FirstOrDefaultAsync(o => o.Id == organisationId);
            if (model == null)
            {
                var msg = String.Format("Failed to get organisations from the API");
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpPost(Name = "CreateOrganisation")]
        public async Task<IActionResult> CreateOrganisation([FromBody] Organisation item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            ApplicationDbContext.Organisations.Add(item);
            await ApplicationDbContext.SaveChangesAsync();

            return this.CreatedAtRoute("GetOrganisationById", new { Controller = "OrganisationsController", organisationId = item.Id }, item);
        }
    }
}
