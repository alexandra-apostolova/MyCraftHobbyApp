using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.GCommon.Enums;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICraftService
    {
        Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync(string? currentUserId);
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync(string? currentUserId);


        Task<DetailsViewModel> GetDetailsForModelAsync(int id, string? currentUserId);

        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync();

        Task<CraftProject> GetProjectAsync(int id);
        Task<CraftType> GetCraftType(int id);

        Task<bool> CheckIsValidProjectIdAsync(InputModel model);
        Task<bool> CheckIsValidStitchIdAsync(InputModel model);

        Task<bool> AddNewProjectAsync(InputModel inputModel, string userId);
        Task<bool> EditExistingProjectAsync(CraftProject project, InputModel model);
        Task<bool> DeleteProjectAsync(int id);

        Task<bool> ToggleStartFinishAsync(CraftProject project, string? currentUserId);
    }
}
