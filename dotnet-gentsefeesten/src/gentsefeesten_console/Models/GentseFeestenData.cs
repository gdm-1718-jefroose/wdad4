using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class GentseFeestenData
    {
        [DataMember(Name="day")]
        public string Datum { get; set; }

        public GentseFeestenData() {
        }

        public override string ToString()
        {
            return String.Format("Data: {0}", Datum);
        }
    }
}
