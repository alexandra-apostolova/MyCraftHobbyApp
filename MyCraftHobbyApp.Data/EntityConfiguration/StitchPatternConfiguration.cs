
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class StitchPatternConfiguration : IEntityTypeConfiguration<StitchPattern>
    {
        public ICollection<StitchPattern> stitchPatterns = new List<StitchPattern>
        {
            new StitchPattern
            {
                Id = 1,
                Name = "Granny Square"
            },
            new StitchPattern
            {
                Id = 2,
                Name = "Shell"
            },
            new StitchPattern
            {
                Id = 3,
                Name = "Wave Stitch"
            },
            new StitchPattern
            {
                Id = 4,
                Name = "Alpine"
            }
        };
        public void Configure(EntityTypeBuilder<StitchPattern> entity)
        {
            entity.HasData(stitchPatterns);
        }
    }
}
