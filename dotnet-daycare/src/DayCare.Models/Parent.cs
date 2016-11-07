using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Parent : Person
    {
        public List<ParentChild> Children { get; set; }
    }
}
