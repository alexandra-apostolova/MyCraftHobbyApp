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
            ICollection<AllViewModel> viewModel = await knitService.GetAllKnitProjectsAsync();

            return View(viewModel);
        }
    }
}
