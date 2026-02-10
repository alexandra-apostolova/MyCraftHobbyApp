using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Data.Models.Enums;
using System;
using System.Collections.Generic;

namespace MyCraftHobbyApp.ViewModels
{
    public class DetailsKnitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public string ProjectTypeName { get; set; } = null!;
    }
}
