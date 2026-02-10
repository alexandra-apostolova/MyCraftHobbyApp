using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class CrochetController : Controller
    {
        private readonly ICrochetService crochetService;
        public CrochetController(ICrochetService crochetService)
        {
            this.crochetService = crochetService;
        }
        public async Task<IActionResult> All()
        {
            ICollection<AllViewModel> viewModel 
                = await crochetService.GetAllCrochetProjectsAsync();

            return View(viewModel);
        }
    }
}
