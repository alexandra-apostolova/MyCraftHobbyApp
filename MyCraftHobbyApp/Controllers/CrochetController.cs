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

            await crochetService.AddNewCrochetProject(inputModel);

            return RedirectToAction(nameof(All));
        }
    }
}
