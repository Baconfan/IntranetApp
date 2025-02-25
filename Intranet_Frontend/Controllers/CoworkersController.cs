using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class CoworkersController: Controller
    {
        public IActionResult Index()
        {
            return View("Coworkers");
        }
    }
}
