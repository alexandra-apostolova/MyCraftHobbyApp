using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core
{
    public class MyProjectsService : IMyProjectsService
    {
        private readonly CraftHobbyAppDbContext dbContext;
        public MyProjectsService(CraftHobbyAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ICollection<AllUserProjectsViewModel>> GetAllUserProjectsAsync(string? currentUserId)
        {
            ICollection<AllUserProjectsViewModel> allProjects = await dbContext.UserProjects
                .Where(p => p.UserId == currentUserId)
                .Select(p => new AllUserProjectsViewModel
                {
                    Id = p.CraftProject.Id,
                    Name = p.CraftProject.Name,
                    ImgUrl = p.CraftProject.ImgUrl,
                    CraftType = p.CraftProject.Type,
                    Difficulty = p.CraftProject.ProjectType.Difficulty,
                    IsCreator = p.IsCreator,
                    IsStarted = p.IsStarted,
                    IsFinished = p.IsFinished
                })
                .ToListAsync();

            return allProjects;
        }
    }
}
