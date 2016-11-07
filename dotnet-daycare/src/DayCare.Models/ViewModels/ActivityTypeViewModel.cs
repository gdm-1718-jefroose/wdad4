using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DayCare.Models;

namespace DayCare.Models.ViewModels
{
    public class ActivityTypeViewModel
    {
        public ActivityType ActivityType { get; set; }
        public List<SelectListItem> ActivityTypes { get; set; }
    }
}