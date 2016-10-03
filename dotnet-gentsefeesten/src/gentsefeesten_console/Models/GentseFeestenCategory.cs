using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class GentseFeestenCategory
    {
        [DataMember(Name="title")]
        public string Category { get; set; }

        public GentseFeestenCategory() {
        }

        public override string ToString()
        {
            return String.Format("Category: {0}", Category);
        }
    }
}
