using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public ICollection<UserProject> userProjects = new List<UserProject>()
        {
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 1,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 2,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 3,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 1,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 4,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 5,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
            new UserProject
            {
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b",
                CraftProjectId = 6,
                IsCreator = true,
                IsStarted = false,
                IsFinished = false
            },
        };
        public void Configure(EntityTypeBuilder<UserProject> entity)
        {
            entity.HasData(userProjects);
        }
    }
}
