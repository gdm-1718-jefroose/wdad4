using System;
using OpenIddict;

namespace DayCare.Models.Security
{
    public class ApplicationUser : OpenIddictUser<Guid> 
    {
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}