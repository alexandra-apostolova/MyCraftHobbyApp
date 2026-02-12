
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IKnitService
    {
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync();
        Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task AddNewKnitProject(KnitInputModel inputModel);
        Task<KnitProject> GetKnitProject(int id);
        Task<bool> CheckIsValidProjectIdAsync(KnitInputModel model);
        Task EditExistingKnitProject(KnitProject project, KnitInputModel model);
    }
}
