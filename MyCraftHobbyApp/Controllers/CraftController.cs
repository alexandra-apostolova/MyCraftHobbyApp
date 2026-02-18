using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class CraftController : BaseController
    {
        private readonly ICraftService craftService;
        private readonly ILogger<CraftController> logger;
        public CraftController(ICraftService craftService, ILogger<CraftController> logger)
        {
            this.craftService = craftService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            string? currentUserId = GetUserId();
            ICollection<AllViewModel> viewModel 
                = await craftService.GetAllProjectsAsync(currentUserId);

            return View(viewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            DetailsViewModel viewModel = await craftService.GetDetailsForModelAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<ProjectType> allProjectTypes = await craftService.GetAllProjectTypesAsync();
            KnitInputModel inputModel = new KnitInputModel()
            {
                ProjectTypes = allProjectTypes,
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KnitInputModel inputModel)
        {
            string? currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                bool result = await craftService.AddNewKnitProjectAsync(inputModel, currentUserId);
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

            KnitProject knitProject = await craftService.GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            var projectTypes = await craftService.GetAllProjectTypesAsync();
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

            KnitProject knitProject = await craftService.GetKnitProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await craftService.EditExistingKnitProjectAsync(knitProject, inputModel);
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

            KnitProject projectToDelete = await craftService.GetKnitProjectAsync(id);
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
                bool result = await craftService.DeleteKnitProjectAsync(id);
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

        public async Task<IActionResult> StartProject(int id)
        {
            string? currentUserId = GetUserId();
            if (id <= 0)
            {
                return BadRequest();
            }
            KnitProject? projectToStart = await craftService.GetKnitProjectAsync(id);
            if (projectToStart == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await craftService.StartProjectAsync(projectToStart, currentUserId);
                if (!result)
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                logger.LogError("Something went wrong. Try again later.");
                ModelState.AddModelError(String.Empty, "Something went wrong. Try again later.");
            }

            return Ok("Started!");
        }

        public async Task<IActionResult> FinishProject(int id)
        {
            string? currentUserId = GetUserId();
            if (id <= 0)
            {
                return BadRequest();
            }

            KnitProject? projectToFinish = await craftService.GetKnitProjectAsync(id);
            if (projectToFinish == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await craftService.FinishProjectAsync(projectToFinish, currentUserId);
                if (!result)
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                logger.LogError("Something went wrong. Try again later.");
                ModelState.AddModelError(String.Empty, "Something went wrong. Try again later.");
            }
            return Ok("Finished!");
        }

    }
}
