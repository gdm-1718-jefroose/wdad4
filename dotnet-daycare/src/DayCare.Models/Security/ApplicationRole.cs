using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DayCare.Models.Security
{
    public class ApplicationRole : IdentityRole<Guid> 
    {
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}