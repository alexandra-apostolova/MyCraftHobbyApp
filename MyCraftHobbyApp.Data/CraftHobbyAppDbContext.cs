using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyCraftHobbyApp.Data
{
    public class CraftHobbyAppDbContext : IdentityDbContext
    {
        public CraftHobbyAppDbContext(DbContextOptions<CraftHobbyAppDbContext> options)
            : base(options)
        {
        }
    }
}
