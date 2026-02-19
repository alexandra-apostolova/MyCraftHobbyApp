using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.GCommon.Enums;
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
        public async Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync(string? currentUserId)
        {
            ICollection<AllViewModel> allCrochetProjects = await dbContext.Projects
                .OfType<CrochetProject>()
                .Include(c => c.ProjectType)
                .AsNoTracking()
                .Select(c => new AllViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImgUrl = c.ImgUrl,
                    Difficulty = c.ProjectType.Difficulty,
                    CraftType = CraftType.Crochet,
                    IsCreator = c.UserProjects
                         .Any(up => up.UserId == currentUserId && up.IsCreator)
                })
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Difficulty)
                .ToListAsync();

            return allCrochetProjects;
        }
        public async Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string? currentUserId)
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
                    CraftType = CraftType.Knit,
                    IsCreator = k.UserProjects
                        .Any(up => up.UserId == currentUserId && up.IsCreator)
                })
                .OrderBy(k => k.Name)
                .ThenBy(k => k.Difficulty)
                .ToListAsync();

            return knitProjects;
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
        public async Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync()
        {
            IEnumerable<StitchPattern> allStitchPatterns = await dbContext
                .Patterns
                .AsNoTracking()
                .ToListAsync();

            return allStitchPatterns;
        }

        public async Task<bool> AddNewProjectAsync(InputModel inputModel, string currentUserId)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            if (!isValidProjectType)
            {
                return false;
            }

            CraftProject projectToAdd;
            if (inputModel is CrochetInputModel crochetInput)
            {
                projectToAdd = new CrochetProject
                {
                    Name = crochetInput.Name,
                    Description = crochetInput.Description,
                    ImgUrl = crochetInput.ImgUrl,
                    StitchPatternId = crochetInput.StitchPatternId,
                    ProjectTypeId = crochetInput.ProjectTypeId
                };
            }
            else
            {
                projectToAdd = new KnitProject
                {
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    ImgUrl = inputModel.ImgUrl,
                    ProjectTypeId = inputModel.ProjectTypeId
                };
            }

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

        public async Task<bool> EditExistingProjectAsync(CraftProject craftProject, InputModel inputModel)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            
            if (!isValidProjectType)
            {
                return false;
            }

            if (inputModel is CrochetInputModel crochet &&
                craftProject is CrochetProject crochetProject)
            {
                bool isValidStitchPattern = await CheckIsValidStitchIdAsync(inputModel);
                if (!isValidStitchPattern)
                {
                    return false;
                }
                crochetProject.Name = crochet.Name;
                crochetProject.Description = crochet.Description;
                crochetProject.ImgUrl = crochet.ImgUrl;
                crochetProject.StitchPatternId = crochet.StitchPatternId;
                crochetProject.ProjectTypeId = crochet.ProjectTypeId;
            }
            else
            {
                craftProject.Name = inputModel.Name;
                craftProject.Description = inputModel.Description;
                craftProject.ImgUrl = inputModel.ImgUrl;
                craftProject.ProjectTypeId = inputModel.ProjectTypeId;
            }


            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            CraftProject? project = await GetProjectAsync(id);
            if (project == null)
            {
                return false;
            }

            dbContext.UserProjects.RemoveRange(project.UserProjects);
            dbContext.Projects.Remove(project);

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CraftProject> GetProjectAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException("Id can't be zero or negative!");
            }

            CraftProject? craftProject = await dbContext.Projects
                .Include(c => c.UserProjects)
                .Where(c => c.Id == id).SingleOrDefaultAsync(k => k.Id == id);

            if (craftProject == null)
            {
                return null;
            }

            return craftProject;
        }

        public async Task<bool> CheckIsValidProjectIdAsync(InputModel model)
        {
            return await dbContext.Types.AnyAsync(t => t.Id == model.ProjectTypeId);
        }
        public async Task<bool> CheckIsValidStitchIdAsync(InputModel model)
        {
            if (model is CrochetInputModel crochet)
            {
                return await dbContext.Patterns.AnyAsync(p => p.Id == crochet.StitchPatternId);
            }
            return false;
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

