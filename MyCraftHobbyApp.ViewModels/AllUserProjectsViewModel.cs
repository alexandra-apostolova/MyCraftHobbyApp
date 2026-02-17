
using MyCraftHobbyApp.Data.Models.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class AllUserProjectsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public string CraftType { get; set; } = null!;
        public string CraftName =>
            CraftType == "KnitProject" ? "Knit" : "Crochet";

        public Difficulty Difficulty { get; set; }

        public bool IsCreator { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }
}
