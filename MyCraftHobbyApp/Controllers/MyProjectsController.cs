using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class MyProjectsController : BaseController
    {
        private readonly IMyProjectsService myProjectsService;
        private readonly ILogger<MyProjectsController> logger;

        public MyProjectsController(IMyProjectsService myProjectsService, ILogger<MyProjectsController> logger)
        {
            this.myProjectsService = myProjectsService;
            this.logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            string? currentUserId = GetUserId();
            ICollection<AllUserProjectsViewModel> allProjects 
                = await myProjectsService.GetAllUserProjectsAsync(currentUserId);

            return View(allProjects);
        }
    }
}
