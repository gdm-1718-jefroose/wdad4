using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Child : Person
    {
        public List<ParentChild> Parents { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
