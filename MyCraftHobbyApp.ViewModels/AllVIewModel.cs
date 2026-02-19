
using MyCraftHobbyApp.Data.Models.Enums;
using MyCraftHobbyApp.GCommon.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class AllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public CraftType CraftType { get; set; }
        public string CraftName =>
            CraftType.ToString();
        public bool IsCreator { get; set; }
    }
}
