using Microsoft.AspNetCore.Mvc;
using Recruitment_App.Portal.Models;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;
using System.Diagnostics;

namespace Recruitment_App.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobTitleService<JobTitle, Guid> _jobTitleService;
        private readonly IApplicationService<Application, Guid> _applicationService;
        private readonly IService<Skill, int> _skillService;
        private readonly IService<JobCategory, int> _jobCategoryService;
        private readonly IService<Application, Guid> _applicantService;

        public HomeController(ILogger<HomeController> logger, IJobTitleService<JobTitle, Guid> jobTitleService,
            IService<Skill, int> skillService, IService<JobCategory, int> jobCategoryService, IApplicationService<Application, Guid> applicationService,
            IService<Application, Guid> applicantService)
        {
            _jobTitleService = jobTitleService;
            _logger = logger;
            _skillService = skillService;
            _jobCategoryService = jobCategoryService;
            _applicationService = applicationService;
            _applicantService = applicantService;
        }

        [Route("")]
        [Route("Home/Index")]
        [Route("/Home")]
        public async Task<IActionResult> Index()
        {
            var jobTitles = await _jobTitleService.GetAllAvailable();
            return View(jobTitles);
        }

        [HttpGet]
        [Route("/Home/Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            ViewBag.skillsList = await _skillService.GetAll();
            ViewBag.jobCategoriesList = await _jobCategoryService.GetAll();
            Application application = new Application();
            application.JobTitles = await _jobTitleService.GetById(id);
            if (application.JobTitles != null)
                return View(application);
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("/Home/Apply")]
        public async Task<IActionResult> Apply(Application payload)
        {
            if (payload != null)
            {
                payload.ApplicantsId = Guid.NewGuid();
                await _applicationService.Apply(payload);

                var jobTitles = await _jobTitleService.GetAllAvailable();
                return View("Index", jobTitles);
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}