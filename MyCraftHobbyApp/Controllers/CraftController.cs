using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core;
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
        public async Task<IActionResult> KnitAll()
        {
            string? currentUserId = GetUserId();
            ICollection<AllViewModel> viewModel
                = await craftService.GetAllKnitProjectsAsync(currentUserId);

            return View("All", viewModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> CrochetAll()
        {
            string? currentUserId = GetUserId();
            ICollection<AllViewModel> viewModel
                = await craftService.GetAllCrochetProjectsAsync(currentUserId);

            return View("All", viewModel);
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
        public async Task<IActionResult> CreateKnit()
        {
            IEnumerable<ProjectType> allProjectTypes = await craftService.GetAllProjectTypesAsync();

            InputModel inputModel = new KnitInputModel()
            {
                ProjectTypes = allProjectTypes,
            };

            return View("CreateKnit", inputModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCrochet()
        {
            IEnumerable<ProjectType> projectTypes = await craftService.GetAllProjectTypesAsync();
            IEnumerable<StitchPattern> stitchPatterns = await craftService.GetAllStitchPatternAsync();

            InputModel inputModel = new CrochetInputModel
            {
                StitchPatterns = stitchPatterns,
                ProjectTypes = projectTypes
            };

            return View("CreateCrochet", inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKnit(KnitInputModel inputModel)
        {
            string? currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                bool result = await craftService.AddNewProjectAsync(inputModel, currentUserId);
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


            return RedirectToAction(nameof(KnitAll));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCrochet(CrochetInputModel inputModel)
        {
            string? currentUserId = GetUserId();
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            try
            {
                bool result = await craftService.AddNewProjectAsync(inputModel, currentUserId);
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

            return RedirectToAction(nameof(CrochetAll));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            CraftProject craftProject = await craftService.GetProjectAsync(id);
            if (craftProject == null)
            {
                return NotFound();
            }

            InputModel model;
            var projectTypes = await craftService.GetAllProjectTypesAsync();
            var stitchPatterns = await craftService.GetAllStitchPatternAsync();

            if (craftProject is CrochetProject crochet)
            {
                model = new CrochetInputModel()
                {
                    Id = id,
                    Name = crochet.Name,
                    Description = crochet.Description,
                    ImgUrl = crochet.ImgUrl,
                    ProjectTypeId = crochet.ProjectTypeId,
                    ProjectTypes = projectTypes,
                    StitchPatternId = crochet.StitchPatternId,
                    StitchPatterns = stitchPatterns
                };
            }
            else
            {
                model = new KnitInputModel()
                {
                    Id = id,
                    Name = craftProject.Name,
                    Description = craftProject.Description,
                    ImgUrl = craftProject.ImgUrl,
                    ProjectTypeId = craftProject.ProjectTypeId,
                    ProjectTypes = projectTypes
                };
            }

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, InputModel inputModel)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            CraftProject craftProject = await craftService.GetProjectAsync(id);
            if (craftProject == null)
            {
                return NotFound();
            }

            try
            {
                bool result = await craftService.EditExistingProjectAsync(craftProject, inputModel);
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

            CraftProject projectToDelete = await craftService.GetProjectAsync(id);
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
        public async Task<IActionResult> Delete(int id, InputModel model)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                bool result = await craftService.DeleteProjectAsync(id);
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
           

            return View("All");
        }

        //public async Task<IActionResult> StartProject(int id)
        //{
        //    string? currentUserId = GetUserId();
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }
        //    CraftProject? projectToStart = await craftService.GetProjectAsync(id);
        //    if (projectToStart == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        bool result = await craftService.StartProjectAsync(projectToStart, currentUserId);
        //        if (!result)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        logger.LogError("Something went wrong. Try again later.");
        //        ModelState.AddModelError(String.Empty, "Something went wrong. Try again later.");
        //    }

        //    return Ok("Started!");
        //}

        //public async Task<IActionResult> FinishProject(int id)
        //{
        //    string? currentUserId = GetUserId();
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    KnitProject? projectToFinish = await craftService.GetKnitProjectAsync(id);
        //    if (projectToFinish == null)
        //    {
        //        return NotFound();
        //    }

        //    try
        //    {
        //        bool result = await craftService.FinishProjectAsync(projectToFinish, currentUserId);
        //        if (!result)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        logger.LogError("Something went wrong. Try again later.");
        //        ModelState.AddModelError(String.Empty, "Something went wrong. Try again later.");
        //    }
        //    return Ok("Finished!");
        //}

    }
}
