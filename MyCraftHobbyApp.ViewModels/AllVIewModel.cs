
using MyCraftHobbyApp.Data.Models.Enums;

namespace MyCraftHobbyApp.ViewModels
{
    public class AllVIewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImgUrl { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
