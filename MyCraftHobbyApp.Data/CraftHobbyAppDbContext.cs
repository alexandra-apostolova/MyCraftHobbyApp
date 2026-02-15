using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data
{
    public class CraftHobbyAppDbContext : IdentityDbContext<IdentityUser>
    {
        public CraftHobbyAppDbContext(DbContextOptions<CraftHobbyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<KnitProject> KnitProjects { get; set; }
        public DbSet<CrochetProject> CrochetProjects { get; set; }
        public DbSet<ProjectType> Types { get; set; }
        public DbSet<StitchPattern> Patterns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CraftHobbyAppDbContext).Assembly);
        }
    }
}
