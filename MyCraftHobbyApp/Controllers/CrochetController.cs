using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class CrochetController : BaseController
    {
        private readonly ICrochetService crochetService;
        private readonly ILogger<CrochetController> logger;
        public CrochetController(ICrochetService crochetService, ILogger<CrochetController> logger)
        {
            this.crochetService = crochetService;
            this.logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            string? currentUserId = GetUserId();
            ICollection<AllViewModel> viewModel 
                = await crochetService.GetAllCrochetProjectsAsync(currentUserId);

            return View(viewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            DetailsCrochetViewModel viewModel = await crochetService.GetDetailsForCrochetModelAsync(id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<ProjectType> projectTypes = await crochetService.GetAllProjectTypesAsync();
            IEnumerable<StitchPattern> stitchPatterns = await crochetService.GetAllStitchPatternAsync();

            CrochetInputModel inputModel = new CrochetInputModel
            {
                StitchPatterns = stitchPatterns,
                ProjectTypes = projectTypes
            };

            return View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrochetInputModel inputModel)
        {
            string? currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                bool result = await crochetService.AddNewCrochetProjectAsync(inputModel, currentUserId);
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

            CrochetProject crochetProject = await crochetService.GetCrochetProjectAsync(id);
            if (crochetProject == null)
            {
                return NotFound();
            }

            var projectTypes = await crochetService.GetAllProjectTypesAsync();
            var stitchPatterns = await crochetService.GetAllStitchPatternAsync();

            CrochetInputModel model = new CrochetInputModel()
            {
                Id = id,
                Name = crochetProject.Name,
                Description = crochetProject.Description,
                ImgUrl = crochetProject.ImgUrl,
                ProjectTypeId = crochetProject.ProjectTypeId,
                ProjectTypes = projectTypes,
                StitchPatternId = crochetProject.StitchPatternId,
                StitchPatterns = stitchPatterns
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CrochetInputModel inputModel)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            CrochetProject knitProject = await crochetService.GetCrochetProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await crochetService.EditExistingCrochetProjectAsync(knitProject, inputModel);
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


            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            CrochetProject projectToDelete = await crochetService.GetCrochetProjectAsync(id);
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
        public async Task<IActionResult> Delete(int id, CrochetInputModel model)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                bool result = await crochetService.DeleteCrochetProjectAsync(id);
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
            CrochetProject? projectToStart = await crochetService.GetCrochetProjectAsync(id);
            if (projectToStart == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await crochetService.StartProjectAsync(projectToStart, currentUserId);
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
    }
}
