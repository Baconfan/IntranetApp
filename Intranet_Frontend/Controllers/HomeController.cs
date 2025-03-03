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

    [HttpGet("search")]
    [Consumes(MediaTypeNames.Application.Json)]
    public JsonResult GetElementsForTypeahead([FromQuery] string? searchTerm)
    {
        // No search term, no search.
        if (searchTerm is null or "")
        {
            return new JsonResult(new List<string>());
        }

        // TODO: Implement search logic.
        // var matchingElements = new List<string> { "Alice", "Bob", "Jack" };
        var matchingElements = new List<Select2ListItem>()
        {
            new () { Id = 1, Text = "Alice" },
            new () { Id = 2, Text = "Bob" },
            new () { Id = 3, Text = "Jack" }
        };

        return new JsonResult(matchingElements);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
