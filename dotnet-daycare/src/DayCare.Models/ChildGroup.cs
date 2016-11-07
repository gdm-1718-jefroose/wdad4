using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class ChildGroup
    {
        public Int64 ChildId { get; set; }
        public Child Child { get; set; }
        public Int32 GroupId { get; set; }
        public Group Group { get; set; }
        public Nullable<DateTime> StartedAt { get; set; }
        public Nullable<DateTime> StoppedAt { get; set; }

        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
