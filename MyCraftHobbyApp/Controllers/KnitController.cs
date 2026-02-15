using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class KnitController : BaseController
    {
        private readonly IKnitService knitService;
        private readonly ILogger<KnitController> logger;
        public KnitController(IKnitService knitService, ILogger<KnitController> logger)
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

        [AllowAnonymous]
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
                return View(inputModel);
            }

            try
            {
                bool result = await knitService.AddNewKnitProjectAsync(inputModel);
                if (!result)
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                logger.LogError("Something went wrong. Try again later.");

                ModelState.AddModelError(string.Empty, "Something went wrong. Try again later.");
            }


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
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            KnitProject knitProject = await knitService.GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await knitService.EditExistingKnitProjectAsync(knitProject, inputModel);
                if (!result)
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                logger.LogError("Something went wrong. Try again later.");

                ModelState.AddModelError(string.Empty, "Something went wrong. Try again later.");
            }

            return RedirectToAction(nameof(Details), new {id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            KnitProject projectToDelete = await knitService.GetKnitProjectAsync(id);
            if (projectToDelete == null)
            {
                return NotFound();
            }

            DeleteViewModel model = new DeleteViewModel
            {
                Id = projectToDelete.Id,
                Name = projectToDelete.Name,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, KnitInputModel model)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                bool result = await knitService.DeleteKnitProjectAsync(id);
                if (!result)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                logger.LogError("Something went wrong. Try again later.");

                ModelState.AddModelError(string.Empty, "Something went wrong. Try again later.");
            }
           

            return RedirectToAction(nameof(All));
        }
    }
}
