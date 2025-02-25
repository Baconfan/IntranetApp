using Microsoft.AspNetCore.Mvc;

namespace Intranet_Frontend.Controllers
{
    public class WikiController : Controller
    {
        public IActionResult Index()
        {
            return View("Wiki");
        }
    }
}
