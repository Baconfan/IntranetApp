using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            // Get the projects from the database

            return View("Projects");
        }

        public IActionResult Details(int id)
        {
            // Get the project details from the database
            return View("ProjectDetails");
        }
    }
}
