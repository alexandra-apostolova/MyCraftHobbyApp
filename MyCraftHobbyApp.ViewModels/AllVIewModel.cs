
using MyCraftHobbyApp.Data.Models.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class AllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public string UserId { get; set; } = null!;
    }
}
