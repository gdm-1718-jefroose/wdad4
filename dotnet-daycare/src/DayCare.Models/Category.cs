using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Category : BaseEntity<Int16>
    {
        public Nullable<Int16> ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }

        public List<Post> Posts { get; set; }
    }
}
