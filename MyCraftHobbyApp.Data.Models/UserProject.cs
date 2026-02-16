
namespace MyCraftHobbyApp.Data.Models
{
    public class UserProject
    {
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;

        public int CraftProjectId { get; set; }
        public CraftProject CraftProject { get; set; } = null!;

        public bool IsCreator { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
    }
}
