using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
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
                    IsCreator = c.UserProjects
                         .Any(up => up.UserId == currentUserId && up.IsCreator)
                })
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Difficulty)
                .ToListAsync();

            return allCrochetProjects;
        }

        public async Task<DetailsCrochetViewModel> GetDetailsForCrochetModelAsync(int id)
        {
            CrochetProject? crochetProject = await dbContext.Projects
                .OfType<CrochetProject>()
                .Include(c => c.ProjectType)
                .Include(c => c.StitchPattern)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (crochetProject == null)
            {
                return null;
            }

            //UserProject? userProject = await dbContext.UserProjects
            //    .SingleOrDefaultAsync(p => p.CraftProjectId == id);

            //if (userProject == null)
            //{
            //    return null;
            //}

            DetailsCrochetViewModel viewModel = new DetailsCrochetViewModel();
            viewModel.Id = id;
            viewModel.Name = crochetProject.Name;
            viewModel.Description = crochetProject.Description;
            viewModel.ImgUrl = crochetProject.ImgUrl;
            viewModel.Difficulty = crochetProject.ProjectType.Difficulty;
            viewModel.StitchPattern = crochetProject.StitchPattern.Name;
            viewModel.ProjectTypeName = crochetProject.ProjectType.Name;
            //viewModel.IsStarted = userProject.IsStarted;
            //viewModel.IsFinished = userProject.IsFinished;

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

        public async Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync()
        {
            IEnumerable<StitchPattern> allStitchPatterns = await dbContext
                .Patterns
                .AsNoTracking()
                .ToListAsync();

            return allStitchPatterns;
        }

        public async Task<bool> AddNewCrochetProjectAsync(CrochetInputModel inputModel, string? currentUserId)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            bool isValidStitchPattern = await CheckIsValidStitchIdAsync(inputModel);

            if (!isValidProjectType || !isValidStitchPattern)
            {
                return false;
            }

            CrochetProject projectToAdd = new CrochetProject
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                ImgUrl = inputModel.ImgUrl,
                StitchPatternId = inputModel.StitchPatternId,
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

        public async Task<bool> CheckIsValidStitchIdAsync(CrochetInputModel model)
        {
            return await dbContext.Patterns.AnyAsync(p => p.Id == model.StitchPatternId);
        }

        public async Task<bool> EditExistingCrochetProjectAsync(CrochetProject crochetProject, CrochetInputModel inputModel)
        {
            bool isValidProjectType = await CheckIsValidProjectIdAsync(inputModel);
            bool isValidStitchPattern = await CheckIsValidStitchIdAsync(inputModel);

            if (!isValidProjectType || !isValidStitchPattern)
            {
                return false;
            }

            crochetProject.Name = inputModel.Name;
            crochetProject.Description = inputModel.Description;
            crochetProject.ImgUrl = inputModel.ImgUrl;
            crochetProject.StitchPatternId = inputModel.StitchPatternId;
            crochetProject.ProjectTypeId = inputModel.ProjectTypeId;

            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCrochetProjectAsync(int id)
        {
            CrochetProject? crochetProject = await GetCrochetProjectAsync(id);
            if (crochetProject == null)
            {
                return false;
            }

            dbContext.UserProjects.RemoveRange(crochetProject.UserProjects);
            dbContext.Projects.Remove(crochetProject);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CrochetProject> GetCrochetProjectAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException("Id can't be zero or negative!");
            }

            CrochetProject? crochetProject = await dbContext.Projects
                .Include(c => c.UserProjects)
                .OfType<CrochetProject>().SingleOrDefaultAsync(k => k.Id == id);
            if (crochetProject == null)
            {
                return null;
            }

            return crochetProject;
        }

        public async Task<bool> CheckIsValidProjectIdAsync(CrochetInputModel model)
        {
            return await dbContext.Types.AnyAsync(t => t.Id == model.ProjectTypeId);
        }

        public async Task<bool> StartProjectAsync(CrochetProject projectToStart, string? currentUserId)
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
    }
}
