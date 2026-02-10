using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.Services.Core
{
    public class KnitService : IKnitService
    {
        public CraftHobbyAppDbContext dbContext;
        public KnitService(CraftHobbyAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync()
        {
            ICollection<AllViewModel> knitProjects = await dbContext.KnitProjects
                .Include(k => k.ProjectType)
                .AsNoTracking()
                .Select(k => new AllViewModel
                {
                    Id = k.Id,
                    Name = k.Name,
                    ImgUrl = k.ImgUrl,
                    Difficulty = k.ProjectType.Difficulty
                })
                .OrderBy(k => k.Name)
                .ToListAsync();

            return knitProjects;
        }
    }
}
