using Microsoft.AspNetCore.Identity;

namespace MyCraftHobbyApp.Data.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<UserProject> UserProjects { get; set; } = new HashSet<UserProject>();
    }
}
