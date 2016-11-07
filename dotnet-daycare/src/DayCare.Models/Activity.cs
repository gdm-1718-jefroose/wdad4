using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Activity : BaseEntity<Int64>
    {
        public Int16 ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        public Nullable<Int64> ChildId { get; set; }
        public Child Child { get; set; }
        public Nullable<Int32> GroupId { get; set; }
        public Group Group { get; set; } 
        public Nullable<Int32> LocationId { get; set; }
        public Location Location { get; set; }
        public Nullable<Int16> OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
    }
}
