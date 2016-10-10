using System;

namespace DayCare.Models
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime CreatedAt { get; set; }
        Nullable<DateTime> UpdatedAt { get; set; }
        Nullable<DateTime> DeletedAt { get; set; }
    }
}
