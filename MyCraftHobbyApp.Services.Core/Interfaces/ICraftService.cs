
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICraftService
    {
        Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync(string? currentUserId);
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string? currentUserId);


        Task<DetailsViewModel> GetDetailsForModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync();
        Task<CraftProject> GetProjectAsync(int id);
        Task<bool> AddNewProjectAsync(InputModel inputModel, string userId);
        Task<bool> CheckIsValidProjectIdAsync(InputModel model);
        Task<bool> EditExistingProjectAsync(CraftProject project, InputModel model);
        Task<bool> DeleteProjectAsync(int id);
        Task<bool> StartProjectAsync(KnitProject project, string? currentUserId);
        Task<bool> FinishProjectAsync(KnitProject project, string? currentUserId);
    }
}
