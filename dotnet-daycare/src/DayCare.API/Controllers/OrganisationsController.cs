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
     public class OrganisationsController : BaseController 
     {       
        private const string FAILGETENTITIES = "Failed to get organisations from the API";
        private const string FAILGETENTITYBYID = "Failed to get organisation from the API by Id: {0}";


        public OrganisationsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        [HttpGet(Name = "GetOrganisations")]
        public async Task<IActionResult> GetOrganisations([FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Organisations.Include(o => o.Locations).ToListAsync():await ApplicationDbContext.Organisations.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{organisationId:int}", Name = "GetOrganisationById")]
        public async Task<IActionResult> GetOrganisationById(Int16 organisationId, [FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Organisations.Include(o => o.Locations).FirstOrDefaultAsync(o => o.Id == organisationId):await ApplicationDbContext.Organisations.FirstOrDefaultAsync(o => o.Id == organisationId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, organisationId);
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

        [HttpPut("{organisationId:int}", Name = "UpdateOrganisation")]
        public async Task<IActionResult> UpdateOrganisation(Int16 organisationId, [FromBody] Organisation item)
        {
            if(item == null || item.Id != organisationId)
            {
                return BadRequest();
            }

            var model = await ApplicationDbContext.Organisations.FirstOrDefaultAsync(o => o.Id == organisationId);

            if(model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, organisationId);
                return NotFound(msg);
            }

            model.Name = item.Name;
            model.Description = item.Description;

            ApplicationDbContext.Organisations.Attach(model);
            ApplicationDbContext.Entry(model).State = EntityState.Modified;
            await ApplicationDbContext.SaveChangesAsync();

            return new NoContentResult();
        }

        [HttpDelete("{organisationId:int}", Name = "DeleteOrganisation")]
        public async Task<IActionResult> DeleteOrganisation(Int16 organisationId, [FromQuery] string softDelete)
        {
            var model = await ApplicationDbContext.Organisations.FirstOrDefaultAsync(o => o.Id == organisationId);

            if(model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, organisationId);
                return NotFound(msg);
            }

            if(!string.IsNullOrEmpty(softDelete))
            {
                ApplicationDbContext.Organisations.Attach(model);
                model.DeletedAt = (softDelete == "delete")?DateTime.Now:(Nullable<DateTime>)null;
                ApplicationDbContext.Entry(model).State = EntityState.Modified;
                await ApplicationDbContext.SaveChangesAsync();
            }
            else
            {
                ApplicationDbContext.Organisations.Remove(model);
                await ApplicationDbContext.SaveChangesAsync();
            }

            return new NoContentResult();
        }
    }
}
