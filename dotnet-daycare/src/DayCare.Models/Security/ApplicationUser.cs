using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OpenIddict;
using OpenIddict;

namespace DayCare.Models.Security
{
    public class ApplicationUser : IdentityUser<Guid> 
    {
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}