using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class KnitProjectConfiguration : IEntityTypeConfiguration<KnitProject>
    {
        public ICollection<KnitProject> knitProjects = new List<KnitProject>
        {
            new KnitProject
            {
                Id = 1,
                Name = "Cozy Winter Scarf",
                ImgUrl = "https://i.etsystatic.com/10585666/r/il/5a53bf/1215929775/il_570xN.1215929775_1lhw.jpg",
                ProjectTypeId = 2,
            },
            new KnitProject
            {
                Id = 2,
                Name = "Cable Knit Sweater",
                ImgUrl = "https://fridayknits.com/cdn/shop/files/Chunkycableknit2.jpg?v=1717565368&width=1946",
                ProjectTypeId = 1,
            },
            new KnitProject
            {
                Id = 3,
                Name = "Chunky Knit Throw Blanket",
                ImgUrl = "https://thrutheloopscreations.com/cdn/shop/files/StrawberrySundae3.heic?v=1719674594&width=1946",
                ProjectTypeId = 5,
            }
        };
        public void Configure(EntityTypeBuilder<KnitProject> entity)
        {
            entity.HasData(knitProjects);
        }
    }
}
