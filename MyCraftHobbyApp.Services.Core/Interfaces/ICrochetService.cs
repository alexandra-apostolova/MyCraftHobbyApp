using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;


namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICrochetService
    {
        Task<bool> StartProjectAsync(CrochetProject project, string? currentUserId);
    }
}
