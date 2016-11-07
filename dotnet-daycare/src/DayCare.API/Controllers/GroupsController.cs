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
     public class GroupsController : BaseController 
     {
        private const string FAILGETENTITIES = "Failed to get groups from the API";
        private const string FAILGETENTITYBYID = "Failed to get group from the API by Id: {0}";

        public GroupsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

        [HttpGet(Name = "GetGroups")]
        public async Task<IActionResult> GetGroups()
        {
            var model = await ApplicationDbContext.Groups.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{groupId:int}", Name = "GetGroupById")]
        public async Task<IActionResult> GetGroupById(Int16 groupId)
        {
            var model = await ApplicationDbContext.Groups.FirstOrDefaultAsync(o => o.Id == groupId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, groupId);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
