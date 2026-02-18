
using MyCraftHobbyApp.Data.Models.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public abstract class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public string ProjectTypeName { get; set; } = null!;
        public string CraftType { get; set; } = null!;
        public string CraftName =>
            CraftType == "KnitProject" ? "Knit" : "Crochet";
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }
}
