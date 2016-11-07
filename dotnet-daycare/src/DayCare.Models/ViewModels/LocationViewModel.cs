using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DayCare.Models;

namespace DayCare.Models.ViewModels
{
    public class LocationViewModel
    {
        public Location Location { get; set; }
        public List<SelectListItem> Organisations { get; set; }
    }
}