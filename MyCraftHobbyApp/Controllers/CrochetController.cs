using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core;
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await crochetService.AddNewCrochetProjectAsync(inputModel);

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

            CrochetProject knitProject = await crochetService.GetCrochetProjectAsync(id);
            if (knitProject == null)
            {
                return NotFound();
            }

            bool isValidProjectType = await crochetService.CheckIsValidProjectIdAsync(inputModel);
            bool isValidStitchPattern = await crochetService.CheckIsValidStitchIdAsync(inputModel);

            if (!isValidProjectType || !isValidStitchPattern)
            {
                return BadRequest();
            }

            await crochetService.EditExistingCrochetProjectAsync(knitProject, inputModel);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
