
using MyCraftHobbyApp.Data.Models.Enums;
using MyCraftHobbyApp.GCommon.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public string ProjectTypeName { get; set; } = null!;
        public string? StitchPattern { get; set; }
        public CraftType CraftType { get; set; }
        public string CraftName =>
            CraftType.ToString();
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }
}
