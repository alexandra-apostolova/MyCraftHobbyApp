using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core
{
    public class CrochetService : ICrochetService
    {
        private readonly CraftHobbyAppDbContext dbContext;
        public CrochetService(CraftHobbyAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync()
        {
            ICollection<AllViewModel> allCrochetProjects = await dbContext.CrochetProjects
                .Include(c => c.ProjectType)
                .AsNoTracking()
                .Select(c => new AllViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImgUrl = c.ImgUrl,
                    Difficulty = c.ProjectType.Difficulty,
                })
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Difficulty)
                .ToListAsync();

            return allCrochetProjects;
        }
    }
}
