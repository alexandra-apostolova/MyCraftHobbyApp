
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IKnitService
    {
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync();
        Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task AddNewKnitProjectAsync(KnitInputModel inputModel);
        Task<KnitProject> GetKnitProjectAsync(int id);
        Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model);
        Task EditExistingKnitProjectAsync(KnitProject project, KnitInputModel model);
    }
}
