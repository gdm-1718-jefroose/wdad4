using System;

namespace DayCare.Models
{
    public class Group : BaseEntity<Int32>
    {
        public Int16 MinCapacity { get; set; }
        public Int16 MaxCapacity { get; set; }

        public Int32 LocationId { get; set; }
        public Location Location { get; set; }
    }
}
