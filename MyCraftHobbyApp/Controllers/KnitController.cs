using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class KnitController : BaseController
    {
        private readonly IKnitService knitService;
        private readonly ILogger<CraftController> logger;
        public KnitController(IKnitService knitService, ILogger<CraftController> logger)
        {
            this.knitService = knitService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            string? currentUserId = GetUserId();
            ICollection<AllViewModel> viewModel
                = await knitService.GetAllKnitProjectsAsync(currentUserId);

            return View(viewModel);
        }
    }
}
