
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class CrochetProjectConfiguration : IEntityTypeConfiguration<CrochetProject>
    {
        public ICollection<CrochetProject> crochetProjects = new List<CrochetProject>
        {
            new CrochetProject
            {
                Id = 1,
                Name = "Granny Square Blanket",
                ImgUrl = "https://www.anniedesigncrochet.com/wp-content/uploads/2024/02/rainbow-harmony-blanket-6-sq-768x768.jpg",
                ProjectTypeId = 5,
                StitchPatternId = 1,
            },
            new CrochetProject
            {
                Id = 2,
                Name = "Classic Crochet Beanie",
                ImgUrl = "https://pukapuka.pl/wp-content/uploads/2023/02/img_20221019_110143476-01.jpeg",
                ProjectTypeId = 6, 
                StitchPatternId = 2
            },
            new CrochetProject
            {
                Id = 3,
                Name = "Cozy Crochet Socks",
                ImgUrl = "https://www.lionbrand.com/cdn/shop/products/Crochet-Pattern-Cozy-Crochet-Socks-90528AD-a_800x.jpg?v=1745090141",
                ProjectTypeId = 4, 
                StitchPatternId = 3
            }
        };
        public void Configure(EntityTypeBuilder<CrochetProject> entity)
        {
            entity.HasData(crochetProjects);
        }
    }
}
