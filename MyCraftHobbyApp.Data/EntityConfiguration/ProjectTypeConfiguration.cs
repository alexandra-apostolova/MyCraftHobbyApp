using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Data.Models.Enums;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectType>
    {
        public ICollection<ProjectType> projectTypes = new List<ProjectType>
        {
            new ProjectType
            {
                Id = 1,
                Name = "Sweater",
                Difficulty = Difficulty.Advanced
            },
            new ProjectType
            {
                Id = 2,
                Name = "Scarf",
                Difficulty = Difficulty.Beginner
            },
            new ProjectType
            {
                Id = 3,
                Name = "Mittens",
                Difficulty = Difficulty.Intermediate
            },
            new ProjectType
            {
                Id = 4,
                Name = "Socks",
                Difficulty = Difficulty.Intermediate
            },
            new ProjectType
            {
                Id = 5,
                Name = "Blanket",
                Difficulty = Difficulty.Advanced
            },
            new ProjectType
            {
                Id = 6,
                Name = "Hat",
                Difficulty = Difficulty.Beginner
            }
        };
        public void Configure(EntityTypeBuilder<ProjectType> entity)
        {
            entity.HasData(projectTypes);
        }
    }
}
