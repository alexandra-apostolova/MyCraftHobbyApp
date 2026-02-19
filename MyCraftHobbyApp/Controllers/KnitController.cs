using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCraftHobbyApp.Data.Models;
using MyCraftHobbyApp.Services.Core;
using MyCraftHobbyApp.Services.Core.Interfaces;
using MyCraftHobbyApp.ViewModels;

namespace MyCraftHobbyApp.Controllers
{
    public class KnitController : BaseController
    {
        private readonly ICraftService craftService;
        private readonly ILogger<CraftController> logger;
        public KnitController(ICraftService craftService, ILogger<CraftController> logger)
        {
            this.craftService = craftService;
            this.logger = logger;
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

        //[HttpPost]
        //public async Task<IActionResult> Create(KnitInputModel inputModel)
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
