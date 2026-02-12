using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCraftHobbyApp.Services.Core.Interfaces
{
    public interface ICrochetService
    {
        Task<ICollection<AllViewModel>> GetAllCrochetProjectsAsync();

        Task<DetailsCrochetViewModel> GetDetailsForCrochetModelAsync(int id);
        Task<IEnumerable<ProjectType>> GetAllProjectTypesAsync();
        Task<IEnumerable<StitchPattern>> GetAllStitchPatternAsync();
        Task AddNewCrochetProject(CrochetInputModel inputModel);
        Task<CrochetProject> GetCrochetProjectAsync(int id);
    }
}
