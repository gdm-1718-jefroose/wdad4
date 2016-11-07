using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class ActivityType : BaseEntity<Int16>
    {
        public string ThumbnailURL  { get; set; }

        public Nullable<Int16> ParentActivityTypeId { get; set; }
        public ActivityType ParentActivityType { get; set; }
        public List<ActivityType> ChildActivityTypes { get; set; }
    }
}
