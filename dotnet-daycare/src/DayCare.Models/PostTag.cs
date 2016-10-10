using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class PostTag
    {
       public Int32 PostId { get; set; }
       public Post Post { get; set; }

       public Int64 TagId { get; set; }
       public Tag Tag { get; set; }
    }
}
