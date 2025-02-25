using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View("Projects");
        }
    }
}
