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
     public class PostsController : BaseController 
     {       
        private const string FAILGETENTITIES = "Failed to get posts from the API";
        private const string FAILGETENTITYBYID = "Failed to get post from the API by Id: {0}";


        public PostsController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager):base(applicationDbContext, userManager) 
        {
        }

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

        [HttpGet(Name = "GetPosts")]
        public async Task<IActionResult> GetPosts([FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Posts.Include(p => p.Tags).Include(p => p.Category).ToListAsync():await ApplicationDbContext.Posts.ToListAsync();
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITIES);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }

        [HttpGet("{postId:int}", Name = "GetPostById")]
        public async Task<IActionResult> GetPostById(Int16 postId, [FromQuery] Nullable<bool> withChildren)
        {
            var model = (withChildren != null && withChildren == true)?await ApplicationDbContext.Posts.Include(p => p.Tags).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == postId):await ApplicationDbContext.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (model == null)
            {
                var msg = String.Format(FAILGETENTITYBYID, postId);
                return NotFound(msg);
            }
            return new OkObjectResult(model);
        }
    }
}
