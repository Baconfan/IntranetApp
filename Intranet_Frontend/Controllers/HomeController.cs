using System.Diagnostics;
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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Help()
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
