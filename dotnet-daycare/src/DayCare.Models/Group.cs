using System;

namespace DayCare.Models
{
    public class Group : BaseEntity<Int64>
    {
        public Int32 LocationId { get; set; }
        public Location Location { get; set; }
    }
}
