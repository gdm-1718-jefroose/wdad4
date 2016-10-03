using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class GentseFeestenLocation
    {
        [DataMember(Name="naam")]
        public string Location { get; set; }

        public GentseFeestenLocation() {
        }

        public override string ToString()
        {
            return String.Format("Locatie: {0}", Location);
        }
    }
}
