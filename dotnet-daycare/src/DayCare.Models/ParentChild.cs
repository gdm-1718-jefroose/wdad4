using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class ParentChild
    {
        public Int64 ParentId { get; set; }
        public Parent Parent { get; set; }

        public Int64 ChildId { get; set; }
        public Child Child { get; set; }
    }
}
