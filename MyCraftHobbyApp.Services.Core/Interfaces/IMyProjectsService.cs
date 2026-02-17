
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IMyProjectsService
    {
        Task<ICollection<AllUserProjectsViewModel>> GetAllUserProjectsAsync(string? currentUserId);
    }
}
