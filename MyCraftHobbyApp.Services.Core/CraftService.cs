using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core
{
    public class CraftService : ICraftService
    {
        public CraftHobbyAppDbContext dbContext;
        public CraftService(CraftHobbyAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DetailsViewModel> GetDetailsForModelAsync(int id)
        {
            CraftProject? craftProject = await dbContext.Projects
                .Where(p => p.Id == id)
                .Include(p => p.ProjectType)
                .Include(p => (p as CrochetProject)!.StitchPattern)
                .SingleOrDefaultAsync();

            if (craftProject == null)
                return null;

            if (craftProject is CrochetProject crochetProject)
            {
                return new DetailsCrochetViewModel
                {
                    Id = id,
                    Name = crochetProject.Name,
                    Description = crochetProject.Description,
                    ImgUrl = crochetProject.ImgUrl,
                    Difficulty = crochetProject.ProjectType.Difficulty,
                    ProjectTypeName = crochetProject.ProjectType.Name,
                    StitchPattern = crochetProject.StitchPattern.Name
                };
            }
            else
            {
                return new DetailsKnitViewModel
                {
                    Id = id,
                    Name = craftProject.Name,
                    Description = craftProject.Description,
                    ImgUrl = craftProject.ImgUrl,
                    Difficulty = craftProject.ProjectType.Difficulty,
                    ProjectTypeName = craftProject.ProjectType.Name
                };
            }
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

        public async Task<bool> StartProjectAsync(KnitProject projectToStart, string? currentUserId)
        {
            if (projectToStart == null)
                return false;

            if (string.IsNullOrEmpty(currentUserId))
                return false;

            UserProject? userProject = await dbContext.UserProjects
                .SingleOrDefaultAsync(up => up.CraftProjectId == projectToStart.Id
                                           && up.UserId == currentUserId);

            if (userProject != null)
            {
                userProject.IsStarted = true;
                userProject.IsFinished = false;
                dbContext.UserProjects.Update(userProject);
            }
            else
            {
                userProject = new UserProject
                {
                    CraftProjectId = projectToStart.Id,
                    UserId = currentUserId,
                    IsCreator = false,
                    IsStarted = true,
                    IsFinished = false
                };

                await dbContext.UserProjects.AddAsync(userProject);
            }

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> FinishProjectAsync(KnitProject project, string? currentUserId)
        {
            UserProject? userProject = await dbContext.UserProjects
                    .SingleOrDefaultAsync(up => up.CraftProjectId == project.Id && up.UserId == currentUserId);

            if (userProject == null)
                return false;

            userProject.IsStarted = false;
            userProject.IsFinished = true;

            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}

