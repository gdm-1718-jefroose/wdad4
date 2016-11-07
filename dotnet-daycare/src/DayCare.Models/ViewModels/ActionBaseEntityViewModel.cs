using System;
using DayCare.Models;

namespace DayCare.Models.ViewModels
{
    public class ActionBaseEntityViewModel<T>: ActionViewModel
    {
        public BaseEntity<T> BaseEntity { get; set; }
    }
}