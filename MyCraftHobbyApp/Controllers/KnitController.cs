using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class KnitController : Controller
    {
        private readonly IKnitService knitService;
        public KnitController(IKnitService knitService)
        {
            this.knitService = knitService;
        }
        public async Task<IActionResult> All()
        {
            ICollection<AllViewModel> viewModel 
                = await knitService.GetAllKnitProjectsAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            DetailsKnitViewModel viewModel = await knitService.GetDetailsForModelAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
    }
}
