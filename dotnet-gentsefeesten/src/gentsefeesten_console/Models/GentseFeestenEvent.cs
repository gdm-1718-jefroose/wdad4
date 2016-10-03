using System;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class GentseFeestenEvent
    {
        [DataMember(Name="id")]
        public string Id { get; set; }
        [DataMember(Name="titel")]
        public string Title { get; set; }
        [DataMember(Name="periode")]
        public string Period { get; set; }
        [DataMember(Name="startuur")]
        public string StartTime { get; set; }
        [DataMember(Name="einduur")]
        public string EndTime { get; set; }
        [DataMember(Name="organisatie")]
        public string Organisation { get; set; }
        [DataMember(Name="prijs")]
        public string Price { get; set; }
        [DataMember(Name="prijs_vvk")]
        public string PricePresale { get; set; }
        [DataMember(Name="categorie_naam")]
        public string Category { get; set; }
        [DataMember(Name="locatie")]
        public string Location { get; set; }
        [DataMember(Name="straat")]
        public string Street { get; set; }
        [DataMember(Name="huisnummer")]
        public string HouseNr { get; set; }
        [DataMember(Name="postcode")]
        public string PostalCode { get; set; }
        [DataMember(Name="gemeente")]
        public string City { get; set; }

        public GentseFeestenEvent() {
        }

        public override string ToString()
        {
            return String.Format("{0}\n\nTijd:\t\t{1} tot {2}\nDoor:\t\t{3}\nPrijs:\t\t{4} ({5} VVK)\nCategorie:\t{6}\nLocatie:\t{7} {8}\n\t\t{9} {10}",
                                Title,StartTime,EndTime,Organisation, Price, PricePresale, Category, Street, HouseNr, PostalCode, City);
        }
    }
}
