using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
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

            DetailsKnitViewModel viewModel = await knitService.GetDetailsForKnitModelAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<ProjectType> allProjectTypes = await knitService.GetAllProjectTypesAsync();
            KnitInputModel inputModel = new KnitInputModel()
            {
                ProjectTypes = allProjectTypes,
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KnitInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await knitService.AddNewKnitProjectAsync(inputModel);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            KnitProject knitProject = await knitService.GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            var projectTypes = await knitService.GetAllProjectTypesAsync();
            KnitInputModel model = new KnitInputModel()
            {
                Id = id,
                Name = knitProject.Name,
                Description = knitProject.Description,
                ImgUrl = knitProject.ImgUrl,
                ProjectTypeId = knitProject.ProjectTypeId,
                ProjectTypes = projectTypes
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, KnitInputModel inputModel)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            KnitProject knitProject = await knitService.GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            bool isValidProjectType = await knitService.CheckIsValidProjectIdAsync(inputModel);
            if (!isValidProjectType)
            {
                return BadRequest();
            }

            await knitService.EditExistingKnitProjectAsync(knitProject, inputModel);

            return RedirectToAction(nameof(Details), new {id});
        }
    }
}
