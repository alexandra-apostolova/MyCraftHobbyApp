using Microsoft.EntityFrameworkCore;
using MyCraftHobbyApp.Data;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;
using System.Web.Mvc;

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

        public async Task<DetailsCrochetViewModel> GetDetailsForCrochetModelAsync(int id)
        {
            CrochetProject? crochetProject = await dbContext.CrochetProjects
                .Include(c => c.ProjectType)
                .Include(c => c.StitchPattern)
                .SingleOrDefaultAsync(c => c.Id == id);
            if (crochetProject == null)
            {
                return null;
            }

            DetailsCrochetViewModel viewModel = new DetailsCrochetViewModel();
            viewModel.Id = id;
            viewModel.Name = crochetProject.Name;
            viewModel.Description = crochetProject.Description;
            viewModel.ImgUrl = crochetProject.ImgUrl;
            viewModel.Difficulty = crochetProject.ProjectType.Difficulty;
            viewModel.StitchPattern = crochetProject.StitchPattern.Name;
            viewModel.ProjectTypeName = crochetProject.ProjectType.Name;

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

        public async Task AddNewCrochetProjectAsync(CrochetInputModel inputModel)
        {
            try
            {
                CrochetProject projectToAdd = new CrochetProject
                {
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    ImgUrl = inputModel.ImgUrl,
                    StitchPatternId = inputModel.StitchPatternId,
                    ProjectTypeId = inputModel.ProjectTypeId
                };

                await dbContext.CrochetProjects.AddAsync(projectToAdd);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CrochetProject> GetCrochetProjectAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException("Id can't be zero or negative!");
            }

            CrochetProject? crochetProject = await dbContext.CrochetProjects.SingleOrDefaultAsync(k => k.Id == id);
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

        public async Task<bool> CheckIsValidStitchIdAsync(CrochetInputModel model)
        {
            return await dbContext.Patterns.AnyAsync(p => p.Id == model.StitchPatternId);
        }

       public async Task EditExistingCrochetProjectAsync(CrochetProject crochetProject, CrochetInputModel inputModel)
        {
            try
            {
                crochetProject.Name = inputModel.Name;
                crochetProject.Description = inputModel.Description;
                crochetProject.ImgUrl = inputModel.ImgUrl;
                crochetProject.StitchPatternId = inputModel.StitchPatternId;
                crochetProject.ProjectTypeId = inputModel.ProjectTypeId;

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteCrochetProjectAsync(CrochetProject crochetProject)
        {

            try
            {
                dbContext.CrochetProjects.Remove(crochetProject);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
