using System.Diagnostics;
using CarWorkshopMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshopMVC.Controllers;

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

    public IActionResult About()
    {
        var model = new AboutModel()
        {
            Title = "CarWorkshop application",
            Description = "Some Description",
            Tags = new List<string> { "car", "app", "free" }
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
