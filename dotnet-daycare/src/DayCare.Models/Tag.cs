using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Tag : BaseEntity<Int64>
    {
        public string Name{get; set; }
        public string Description{get; set; }
        public List<Post> Posts{get; set; }
    }
}