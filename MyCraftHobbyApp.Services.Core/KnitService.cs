using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core
{
    public class KnitService : IKnitService
    {
        public CraftHobbyAppDbContext dbContext;
        public KnitService(CraftHobbyAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string currentUserId)
        {

            ICollection<AllViewModel> knitProjects = await dbContext.Projects
                .OfType<KnitProject>()
                .Include(k => k.ProjectType)
                .AsNoTracking()
                .Select(k => new AllViewModel
                {
                    Id = k.Id,
                    Name = k.Name,
                    ImgUrl = k.ImgUrl,
                    Difficulty = k.ProjectType.Difficulty,
                    CraftType = k.GetType().Name,
                    IsCreator = k.UserProjects
                        .Any(up => up.UserId == currentUserId && up.IsCreator)
                })
                .OrderBy(k => k.Name)
                .ThenBy(k => k.Difficulty)
                .ToListAsync();

            return knitProjects;
        }
    }
}
