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
                .ThenBy(k => k.Difficulty)
                .ToListAsync();

            return knitProjects;
        }

        public async Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id)
        {
            KnitProject? knitProject = await dbContext.KnitProjects
                .Include(k => k.ProjectType)
                .SingleOrDefaultAsync(k => k.Id == id);
            if (knitProject == null)
            {
                return null;
            }

            DetailsKnitViewModel viewModel = new DetailsKnitViewModel();
            viewModel.Id = id;
            viewModel.Name = knitProject.Name;
            viewModel.Description = knitProject.Description;
            viewModel.ImgUrl = knitProject.ImgUrl;
            viewModel.Difficulty = knitProject.ProjectType.Difficulty;
            viewModel.ProjectTypeName = knitProject.ProjectType.Name;

            return viewModel;
        }

        public async Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync()
        {
            IEnumerable<ProjectType> allProjectTypes = await dbContext
                .Types
                .AsNoTracking()
                .ToListAsync();

            return allProjectTypes;
        }

        public async Task AddNewKnitProjectAsync(KnitInputModel inputModel)
        {
            try
            {
                KnitProject projectToAdd = new KnitProject
                {
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    ImgUrl = inputModel.ImgUrl,
                    ProjectTypeId = inputModel.ProjectTypeId
                };

                await dbContext.KnitProjects.AddAsync(projectToAdd);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<KnitProject> GetKnitProjectAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException("Id can't be zero or negative!");
            }

            return await dbContext.KnitProjects.SingleOrDefaultAsync(k => k.Id == id);
        }

        public async Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model)
        {
            return await dbContext.Types.AnyAsync(t => t.Id == model.ProjectTypeId);
        }

        public async Task EditExistingKnitProjectAsync(KnitProject knitProject, KnitInputModel inputModel)
        {
            try
            {
                knitProject.Name = inputModel.Name;
                knitProject.Description = inputModel.Description;
                knitProject.ImgUrl = inputModel.ImgUrl;
                knitProject.ProjectTypeId = inputModel.ProjectTypeId;

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
