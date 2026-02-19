using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class CrochetController : BaseController
    {
        private readonly ICrochetService crochetService;
        private readonly ICraftService craftService;
        private readonly ILogger<CrochetController> logger;
        public CrochetController(ICrochetService crochetService, ICraftService craftService, ILogger<CrochetController> logger)
        {
            this.crochetService = crochetService;
            this.craftService = craftService;
            this.logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<ProjectType> projectTypes = await craftService.GetAllProjectTypesAsync();
            IEnumerable<StitchPattern> stitchPatterns = await craftService.GetAllStitchPatternAsync();

            CrochetInputModel inputModel = new CrochetInputModel
            {
                StitchPatterns = stitchPatterns,
                ProjectTypes = projectTypes
            };

            return View(inputModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CrochetInputModel inputModel)
        //{
        //    string? currentUserId = GetUserId();
        //    if (!ModelState.IsValid)
        //    {
        //        return View(inputModel);
        //    }

        //    try
        //    {
        //        bool result = await craftService.AddNewProjectAsync(inputModel, currentUserId);
        //        if (!result)
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        logger.LogError("Something went wrong. Try again later.");

        //        ModelState.AddModelError(string.Empty, "Something went wrong. Try again later.");
        //    }

        //    return RedirectToAction(nameof(All));
        //}

    }
}
