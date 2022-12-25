using Microsoft.AspNetCore.Mvc;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;

namespace Recruitment_App.Web.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IService<Application, Guid> _ApplicationService;
        public ApplicationsController(IService<Application, Guid> applicationService)
        {
            _ApplicationService = applicationService;
        }

        [HttpGet]
        [Route("/Application")]
        public async Task<IActionResult> Index()
        {
            return View(await _ApplicationService.GetAll());
        }
    }
}
