using System;

namespace DayCare.Models
{
    public enum GenderType : byte {
        Unknown = 0,
        Male = 1,
        Female = 2,
        NotApplicable = 9
    }

    public enum MartialStatusType : byte {
        Unknown = 1,
        Single = 2,
        LivingTogether = 3,
        Engaged = 4,
        Married = 5,
        Seperated = 6,
        Divorced = 7,
        Widow = 8
    }

    public class Person
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public GenderType Gender { get; set; }
        public Nullable<DateTime> DayOfBirth { get; set; }
        public Nullable<MartialStatusType> MartialStatus { get; set; }

        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
