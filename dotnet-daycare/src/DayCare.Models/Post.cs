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

        public Nullable<Int32> GroupId { get; set; }
        public Group Group { get; set; } 
        public Nullable<Int32> LocationId { get; set; }
        public Location Location { get; set; }
        public Nullable<Int16> OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
    }
}
