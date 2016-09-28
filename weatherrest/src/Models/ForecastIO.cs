using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class ForecastIO
    {
        [DataMember(Name="Latitude")]
        public decimal Latitude {get; set; }
        [DataMember(Name="Timezone")]
        public string Timezone {get; set; }
        public ForecastIO()
        {

        }
    }

}