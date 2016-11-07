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
     public class PersonsController : BaseController 
     {       
        private const string FAILGETENTITIES = "Failed to get persons from the API";
        private const string FAILGETENTITYBYID = "Failed to get person from the API by Id: {0}";


        public PersonsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IActionResult> GetPersons()
        {
            var model = await ApplicationDbContext.Persons.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{personId:int}", Name = "GetPersonById")]
        public async Task<IActionResult> GetPersonById(Int16 personId)
        {
            var model = await ApplicationDbContext.Persons.FirstOrDefaultAsync(o => o.Id == personId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, personId);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
