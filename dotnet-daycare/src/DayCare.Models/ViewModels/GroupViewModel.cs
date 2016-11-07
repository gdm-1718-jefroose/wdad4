using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using DayCare.Models;

namespace DayCare.Models.ViewModels
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
        public List<SelectListItem> Locations { get; set; }
    }
}