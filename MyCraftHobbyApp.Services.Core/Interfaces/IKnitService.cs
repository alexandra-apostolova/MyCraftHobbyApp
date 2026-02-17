
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IKnitService
    {
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string userId);
        Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<KnitProject> GetKnitProjectAsync(int id);
        Task<bool> AddNewKnitProjectAsync(KnitInputModel inputModel, string userId);
        Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model);
        Task<bool> EditExistingKnitProjectAsync(KnitProject project, KnitInputModel model);
        Task<bool> DeleteKnitProjectAsync(int id);
        Task<bool> StartProjectAsync(KnitProject project, string? currentUserId);
        Task<bool> FinishProjectAsync(KnitProject project, string? currentUserId);
    }
}
