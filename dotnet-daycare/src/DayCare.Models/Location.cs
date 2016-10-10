using System;
using System.Collections.Generic;

namespace DayCare.Models
{
    public class Location : BaseEntity<Int32>
    {
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Int16 OrganisationId { get; set; }
        public Organisation Organisation { get; set; }

        public List<Group> Groups { get; set; }
    }
}
