using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCraftHobbyApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.Data.EntityConfiguration
{
    public class KnitProjectConfiguration : IEntityTypeConfiguration<KnitProject>
    {
        public void Configure(EntityTypeBuilder<KnitProject> entity)
        {
            entity.HasData();
        }
    }
}
