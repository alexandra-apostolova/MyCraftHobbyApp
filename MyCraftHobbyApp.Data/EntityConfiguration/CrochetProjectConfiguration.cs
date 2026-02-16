using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class CrochetProjectConfiguration : IEntityTypeConfiguration<CrochetProject>
    {
        public ICollection<CrochetProject> allProjects = new List<CrochetProject>
        {
            new CrochetProject
            {
                Id = 4,
                Name = "Granny Square Blanket",
                Description = "A classic granny square blanket created by crocheting individual, decorative square motifs in rounds, starting from the center and expanding outward with sets of 3-double crochet clusters (granny clusters). ",
                ImgUrl = "https://www.anniedesigncrochet.com/wp-content/uploads/2024/02/rainbow-harmony-blanket-6-sq-768x768.jpg",
                ProjectTypeId = 5,
                StitchPatternId = 1
            },
            new CrochetProject
            {
                Id = 5,
                Name = "Classic Crochet Beanie",
                Description = "Crochet a warm and comfortable ribbed beanie, ensuring a snug fit without extra fabric bunching.",
                ImgUrl = "https://pukapuka.pl/wp-content/uploads/2023/02/img_20221019_110143476-01.jpeg",
                ProjectTypeId = 6,
                StitchPatternId = 2
            },
            new CrochetProject
            {
                Id = 6,
                Name = "Cozy Crochet Socks",
                Description = "These Crochet Cotton Slipper Socks are easy to make with any cotton yarn. Make a pair and wear them in any season.",
                ImgUrl = "https://www.lionbrand.com/cdn/shop/products/Crochet-Pattern-Cozy-Crochet-Socks-90528AD-a_800x.jpg?v=1745090141",
                ProjectTypeId = 4,
                StitchPatternId = 3
            }
        };
        public void Configure(EntityTypeBuilder<CrochetProject> entity)
        {
            entity.HasData(allProjects);
        }
    }
}
