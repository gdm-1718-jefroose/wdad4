using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Post : BaseEntity<Int64>
    {
        public string Title{get; set; }
        public string Subtitle{get; set; }
        public string Content{get; set; }
        public string Tag{get; set; }
        public List<Category> Categories{get; set;}
    }
}