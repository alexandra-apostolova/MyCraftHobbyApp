using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;


namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICrochetService
    {
        Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync(string? currentUserId);

        Task<DetailsCrochetViewModel> GetDetailsForCrochetModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync();
        Task<bool> AddNewCrochetProjectAsync(CrochetInputModel inputModel, string? currentUserId);
        Task<CrochetProject> GetCrochetProjectAsync(int id);
        Task<bool> CheckIsValidProjectIdAsync(CrochetInputModel model);
        Task<bool> CheckIsValidStitchIdAsync(CrochetInputModel model);
        Task<bool> EditExistingCrochetProjectAsync(CrochetProject project, CrochetInputModel model);
        Task<bool> DeleteCrochetProjectAsync(int id);
    }
}
