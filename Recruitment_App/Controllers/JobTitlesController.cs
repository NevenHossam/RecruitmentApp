using Microsoft.AspNetCore.Mvc;
using Recruitment_App.Models;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;
using System.Diagnostics;

namespace Recruitment_App.Web.Controllers
{
    public class JobTitlesController : Controller
    {
        private readonly IService<JobTitle, Guid> _jobTitleService;
        private readonly IService<Skill, int> _skillService;
        private readonly IService<JobCategory, int> _jobCategoryService;
        public JobTitlesController(IService<JobTitle, Guid> jobTitleService, IService<Skill, int> skillService, IService<JobCategory, int> jobCategoryService)
        {
            _jobTitleService = jobTitleService;
            _skillService = skillService;
            _jobCategoryService = jobCategoryService;
        }
        [Route("")]
        [Route("JobTitles/Index")]
        [Route("/JobTitles")]
        public async Task<IActionResult> Index()
        {
            var jobTitles = await _jobTitleService.GetAll();
            return View(jobTitles);
        }

        [HttpGet]
        [Route("/JobTitles/Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.skillsList = await _skillService.GetAll();
            ViewBag.jobCategoriesList = await _jobCategoryService.GetAll();
            var results = await _jobTitleService.GetById(id);
            if (results != null)
                return View(results);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/JobTitles/Edit")]
        public async Task<IActionResult> EditJobTitle(JobTitle payload)
        {
            var results = await _jobTitleService.Edit(payload.Id, payload);
            if (results == Microsoft.EntityFrameworkCore.EntityState.Modified) return RedirectToAction("Index");

            return View("Details", payload.Id);
        }

        [HttpGet]
        [Route("/JobTitles/Add")]
        public async Task<IActionResult> AddJobTitle()
        {
            ViewBag.skillsList = await _skillService.GetAll();
            ViewBag.jobCategoriesList = await _jobCategoryService.GetAll();
            return View();
        }

        [HttpPost("/JobTitles/Add")]
        public async Task<IActionResult> AddJobTitle(JobTitle payload)
        {
            var results = await _jobTitleService.Add(payload);
            if (results != null) return RedirectToAction("Index");

            return View("AddJobTitle");
        }

        [HttpGet]

        public async Task<JsonResult> DeleteJobTitle(Guid id)
        {
            var results = await _jobTitleService.Delete(id);
            if (results == Microsoft.EntityFrameworkCore.EntityState.Deleted)
                return Json(new { success = true });
            return Json(new { success = false });
        }
    }
}
