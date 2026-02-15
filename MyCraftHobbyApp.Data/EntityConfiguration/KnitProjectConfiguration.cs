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
                Description = "This lovely scarf is a soft, insulated, and stylish accessory designed for maximum warmth against cold weather",
                ImgUrl = "https://i.etsystatic.com/10585666/r/il/5a53bf/1215929775/il_570xN.1215929775_1lhw.jpg",
                ProjectTypeId = 2,
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b"
            },
            new KnitProject
            {
                Id = 2,
                Name = "Cable Knit Sweater",
                Description = "The Cable Knit Sweater is an elegant sweater worked from the top down in a simple cable pattern. It has wide raglan increases and edges in a double rib stitch that are integrated with the cables. This sweater is a great project for the knitter who would like to learn how to knit cables.",
                ImgUrl = "https://fridayknits.com/cdn/shop/files/Chunkycableknit2.jpg?v=1717565368&width=1946",
                ProjectTypeId = 1,
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b"
            },
            new KnitProject
            {
                Id = 3,
                Name = "Chunky Knit Throw Blanket",
                Description = "This colorful knit throw blanket features an easy, stunning stitch, along with gorgeous soft yarn to create an heirloom worthy project! And if you like solid color blankets, you can do that too.",
                ImgUrl = "https://thrutheloopscreations.com/cdn/shop/files/StrawberrySundae3.heic?v=1719674594&width=1946",
                ProjectTypeId = 5,
                UserId = "91dd5e7d-d927-4ca6-8bd5-03ea2671362b"
            }
        };
        public void Configure(EntityTypeBuilder<KnitProject> entity)
        {
            entity.HasData(knitProjects);
        }
    }
}
