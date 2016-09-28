using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Category : BaseEntity<Int64>
    {
        public string Name{get; set; }
        public string Description{get; set; }
        public string Post{get; set; }
    }
}