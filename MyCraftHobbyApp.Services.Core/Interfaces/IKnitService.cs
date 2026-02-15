
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IKnitService
    {
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string userId);
        Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<bool> AddNewKnitProjectAsync(KnitInputModel inputModel);
        Task<KnitProject> GetKnitProjectAsync(int id);
        Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model);
        Task<bool> EditExistingKnitProjectAsync(KnitProject project, KnitInputModel model);
        Task<bool> DeleteKnitProjectAsync(int id);
    }
}
