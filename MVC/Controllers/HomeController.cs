using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using BusinessLayer.Services;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGameService _gameService;

    public HomeController(ILogger<HomeController> logger, IGameService gameService)
    {
        _logger = logger;
        _gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        var games = await _gameService.GetAllAsync();
        return View(games);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
