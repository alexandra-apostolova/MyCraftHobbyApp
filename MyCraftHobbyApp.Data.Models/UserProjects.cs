using MyCraftHobbyApp.Data.Models.Interfaces;

namespace MyCraftHobbyApp.Data.Models
{
    public class UserProjects
    {
        public ICollection<ICraftType> CreatedProjects { get; set; } = new HashSet<ICraftType>();
        public ICollection<ICraftType> StartedProjects { get; set; } = new HashSet<ICraftType>();
        public ICollection<ICraftType> FinishedProjects { get; set; } = new HashSet<ICraftType>();
    }
}
