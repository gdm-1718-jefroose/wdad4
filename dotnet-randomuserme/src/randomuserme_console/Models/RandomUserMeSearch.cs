using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Models
{
    [DataContract]
    public class RandomUserMeSearch
    {
        [DataMember(Name:"resulst")]
        public ICollection<RandomUser> Users {get; set; }

        public RandomUserMeSearch()
        {
        }
    }
}