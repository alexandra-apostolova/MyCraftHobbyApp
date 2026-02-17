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
                    IsCreator = k.UserProjects
                        .Any(up => up.UserId == currentUserId && up.IsCreator)
                })
                .OrderBy(k => k.Name)
                .ThenBy(k => k.Difficulty)
                .ToListAsync();

            return knitProjects;
        }

        public async Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id)
        {
            KnitProject? knitProject = await dbContext.Projects
                .OfType<KnitProject>()
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

        public async Task<bool> AddNewKnitProjectAsync(KnitInputModel inputModel, string currentUserId)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            if (!isValidProjectType)
            {
                return false;
            }

            KnitProject projectToAdd = new KnitProject
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                ImgUrl = inputModel.ImgUrl,
                ProjectTypeId = inputModel.ProjectTypeId
            };

            await dbContext.Projects.AddAsync(projectToAdd);
            await dbContext.SaveChangesAsync();

            if (!String.IsNullOrEmpty(currentUserId))
            {
                UserProject userProject = new UserProject
                {
                    UserId = currentUserId,
                    CraftProjectId = projectToAdd.Id,
                    IsCreator = true
                };

                await dbContext.UserProjects.AddAsync(userProject);
                await dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> EditExistingKnitProjectAsync(KnitProject knitProject, KnitInputModel inputModel)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            if (!isValidProjectType)
            {
                return false;
            }

            knitProject.Name = inputModel.Name;
            knitProject.Description = inputModel.Description;
            knitProject.ImgUrl = inputModel.ImgUrl;
            knitProject.ProjectTypeId = inputModel.ProjectTypeId;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteKnitProjectAsync(int id)
        {
            KnitProject? knitProject = await GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return false;
            }

            dbContext.UserProjects.RemoveRange(knitProject.UserProjects);
            dbContext.Projects.Remove(knitProject);

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<KnitProject> GetKnitProjectAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException("Id can't be zero or negative!");
            }

            KnitProject? knitProject = await dbContext.Projects
                .Include(k => k.UserProjects)
                .OfType<KnitProject>().SingleOrDefaultAsync(k => k.Id == id);

            if (knitProject == null)
            {
                return null;
            }

            return knitProject;
        }

        public async Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model)
        {
            return await dbContext.Types.AnyAsync(t => t.Id == model.ProjectTypeId);
        }
    }
}
