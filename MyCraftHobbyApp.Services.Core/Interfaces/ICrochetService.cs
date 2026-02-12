using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;


namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICrochetService
    {
        Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync();

        Task<DetailsCrochetViewModel> GetDetailsForCrochetModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync();
        Task AddNewCrochetProjectAsync(CrochetInputModel inputModel);
        Task<CrochetProject> GetCrochetProjectAsync(int id);
        Task<bool> CheckIsValidProjectIdAsync(CrochetInputModel model);
        Task<bool> CheckIsValidStitchIdAsync(CrochetInputModel model);
        Task EditExistingCrochetProjectAsync(CrochetProject project, CrochetInputModel model);
        Task DeleteCrochetProjectAsync(CrochetProject project);
    }
}
