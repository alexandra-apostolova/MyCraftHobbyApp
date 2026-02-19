
using MyCraftHobbyApp.Data.Models.Enums;
using MyCraftHobbyApp.GCommon.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class AllUserProjectsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public CraftType CraftType { get; set; }
        public string CraftName =>
            CraftType.ToString();

        public Difficulty Difficulty { get; set; }

        public bool IsCreator { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }
}
