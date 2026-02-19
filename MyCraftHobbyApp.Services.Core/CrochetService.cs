using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core
{
    //public class CrochetService : ICrochetService
    //{
    //    private readonly CraftHobbyAppDbContext dbContext;
    //    public CrochetService(CraftHobbyAppDbContext dbContext)
    //    {
    //        this.dbContext = dbContext;
    //    }
        
        

    //    public async Task<bool> StartProjectAsync(CrochetProject projectToStart, string? currentUserId)
    //    {
    //        if (projectToStart == null)
    //            return false;

    //        if (string.IsNullOrEmpty(currentUserId))
    //            return false;

    //        UserProject? userProject = await dbContext.UserProjects
    //            .SingleOrDefaultAsync(up => up.CraftProjectId == projectToStart.Id
    //                                       && up.UserId == currentUserId);

    //        if (userProject != null)
    //        {
    //            userProject.IsStarted = true;
    //            userProject.IsFinished = false;
    //            dbContext.UserProjects.Update(userProject);
    //        }
    //        else
    //        {
    //            userProject = new UserProject
    //            {
    //                CraftProjectId = projectToStart.Id,
    //                UserId = currentUserId,
    //                IsCreator = false,
    //                IsStarted = true,
    //                IsFinished = false
    //            };

    //            await dbContext.UserProjects.AddAsync(userProject);
    //        }

    //        await dbContext.SaveChangesAsync();
    //        return true;
    //    }
    //}
}
