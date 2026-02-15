
using Microsoft.AspNetCore.Identity;

namespace MyCraftHobbyApp.Data.Models.Interfaces
{
    public interface ICraftType
    {
        int Id { get; }
        string Name { get; }
        string? ImgUrl { get; }
        ProjectType ProjectType { get; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
