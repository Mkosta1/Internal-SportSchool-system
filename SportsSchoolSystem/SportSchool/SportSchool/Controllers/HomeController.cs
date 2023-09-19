using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportSchool.Models;

namespace SportSchool.Controllers;

/// <inheritdoc />
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /// <inheritdoc />
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}