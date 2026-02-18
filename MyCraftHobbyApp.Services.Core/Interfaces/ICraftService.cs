
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICraftService
    {
        Task<DetailsKnitViewModel> GetDetailsForModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<CraftProject> GetProjectAsync(int id);
        Task<bool> AddNewProjectAsync(KnitInputModel inputModel, string userId);
        Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model);
        Task<bool> EditExistingProjectAsync(CraftProject project, KnitInputModel model);
        Task<bool> DeleteProjectAsync(int id);
        Task<bool> StartProjectAsync(KnitProject project, string? currentUserId);
        Task<bool> FinishProjectAsync(KnitProject project, string? currentUserId);
    }
}
