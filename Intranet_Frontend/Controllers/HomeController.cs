using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Intranet_Frontend.Models;

namespace Intranet_Frontend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetMatchingElements(string? searchTerm)
    {
        string[] matchingElements = ["Alice","Bob","Jack"];

        if (searchTerm is null or "")
        {
            return BadRequest();
        }

        return Ok(matchingElements);
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    public JsonResult GetElementsForTypeahead(string? searchTerm)
    {
        var matchingElements = new List<string> { "Alice", "Bob", "Jack" };

        return new JsonResult(matchingElements);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
