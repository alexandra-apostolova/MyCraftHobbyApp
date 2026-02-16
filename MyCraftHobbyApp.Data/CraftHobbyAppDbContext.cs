using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data.EntityConfiguration;
using MyCraftHobbyApp.Data.Models;

namespace MyCraftHobbyApp.Data
{
    public class CraftHobbyAppDbContext : IdentityDbContext<AppUser>
    {
        public CraftHobbyAppDbContext(DbContextOptions<CraftHobbyAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CraftProject> Projects { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }
        public DbSet<ProjectType> Types { get; set; }
        public DbSet<StitchPattern> Patterns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CraftProject>()
                .HasDiscriminator<string>("ProjectKind")
                .HasValue<KnitProject>("Knit")
                .HasValue<CrochetProject>("Crochet");

            builder.ApplyConfiguration(new ProjectTypeConfiguration());
            builder.ApplyConfiguration(new StitchPatternConfiguration());
            builder.ApplyConfiguration(new KnitProjectConfiguration());
            builder.ApplyConfiguration(new CrochetProjectConfiguration());

            builder.Entity<UserProject>()
                .HasKey(up => new { up.UserId, up.CraftProjectId })
                .IsClustered(false);

            builder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserProject>()
                .HasOne(up => up.CraftProject)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.CraftProjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
