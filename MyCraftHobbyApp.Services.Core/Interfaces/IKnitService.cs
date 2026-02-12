
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface IKnitService
    {
        Task<ICollection<AllViewModel>> GetAllKnitProjectsAsync();
        Task<DetailsKnitViewModel> GetDetailsForKnitModelAsync(int id);
    }
}
