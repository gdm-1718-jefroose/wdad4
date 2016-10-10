using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Post : BaseEntity<Int32>
    {
        public string Title 
        {
            get
            {
                return Name;
            }
        }
        public string ThumbnailURL { get; set; }
        public string Body { get; set; }

        public Nullable<Int16> CategoryId { get; set; }
        public Category Category { get; set; }

        public List<PostTag> Tags { get; set; }
    }
}
