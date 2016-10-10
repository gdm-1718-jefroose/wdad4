using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Organisation : BaseEntity<Int16>
    {
        public List<Location> Locations { get; set; }
    }
}
